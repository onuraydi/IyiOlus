using Google.Apis.Auth.OAuth2;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Domain.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IyiOlus.Persistence.Repositories
{

    public sealed class FcmOptions
    {
        public string ProjectId { get; set; } = default!;
        public string ServiceAccountJsonPath { get; set; } = default!;
    }

    public class NotificationSenderRepository : INotificationSenderRepository
    {
        private readonly HttpClient _http;
        private readonly FcmOptions _options;

        public NotificationSenderRepository(HttpClient http, IOptions<FcmOptions> options)
        {
            _http = http;
            _options = options.Value;
        }

        public async Task SendAsync(NotificationPayload notificationPayload, CancellationToken cancellationToken)
        {
            var credentials = GoogleCredential.FromFile(_options.ServiceAccountJsonPath)
                .CreateScoped("https://www.googleapis.com/auth/firebase.messaging");

            var token = await credentials.UnderlyingCredential.GetAccessTokenForRequestAsync();

            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var url = $"https://fcm.googleapis.com/v1/projects/{_options.ProjectId}/messages:send";

            var body = new
            {
                message = new
                {
                    token = notificationPayload.FcmToken,
                    notification = new { title = notificationPayload.Title, body = notificationPayload.Body },
                    data = notificationPayload.Data
                }
            };

            var json = JsonSerializer.Serialize(body);
            var response = await _http.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"), cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync(cancellationToken);
                throw new Exception($"FCM ERROR: {error}");
            }
        }
    }
}
