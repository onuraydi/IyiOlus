using IyiOlus.Application.Features.ProfileTypes.Dtos.Responses;
using IyiOlus.Domain.Entities;
using OWBAlgorithm.Services.ProfileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Statistics.UserProfilesStatistics.Dtos.Responses
{
    public class UserProfilesStatisticResponse
    {
        public Profile Profile { get; set; }  // buradaki profile enum'u algoritma dll'den geliyor
        public List<Profile?> OldProfile { get; set; } = default!;
        public DateTime ProfileTestDate { get; set; }
        public ProfileTypeResponse ProfileType { get; set; } = default!;
    }
}
