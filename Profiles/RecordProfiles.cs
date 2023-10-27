using AutoMapper;
using MediPortal_Records.Models;
using MediPortal_Records.Models.Dtos;

namespace MediPortal_Records.Profiles
{
    public class RecordProfiles:Profile
    {
        public RecordProfiles()
        {
            CreateMap<Record, RecordRequestDto>().ReverseMap();
            CreateMap<Record, RecordDto>().ReverseMap();
        }
    }
}
