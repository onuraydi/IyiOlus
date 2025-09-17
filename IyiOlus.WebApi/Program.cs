using Hangfire;
using IyiOlus.Application;
using IyiOlus.Application.Hangfire;
using IyiOlus.Core;
using IyiOlus.Core.CrossCuttingConcerns.Exceptions.MiddleWares;
using IyiOlus.Persistence;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddCoreServices(builder.Configuration);
builder.Services.AddPersistanceServices(builder.Configuration);

// Enum value'lerin g�z�kmesi i�in eklendi.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "IyiOlus Api", Version = "v1", Description = "Iyi Olus Projesi swagger client." });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Bearer yaz�p bo�luk b�rak�n ard�ndan tokeni girebilirsiniz \r\n\r\n �rne�in Bearer eyJhbGciOiJIUzI1NiI..."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseCustomExceptionMiddleWare();
app.UseAuthentication();
app.UseAuthorization();
app.UseHangfireDashboard();

var scheduler = app.Services.GetRequiredService<NotificationScheduler>();
scheduler.DispatchDueNotifications();

RecurringJob.AddOrUpdate(
    "dispatch-notifications",
    () => app.Services.GetRequiredService<NotificationScheduler>().DispatchDueNotifications(),
    Cron.Minutely
);

app.MapControllers();

app.Run();
