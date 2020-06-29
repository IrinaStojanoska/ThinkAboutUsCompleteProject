using AutoMapper;
using ThinkAboutUs.API.Data.Entities;
using ThinkAboutUs.API.Dtos;

namespace ThinkAboutUs.API.Data.Mapping
{
    public class ThinkAboutUsMappingProfile : Profile
    {
        public ThinkAboutUsMappingProfile()
        {
            CreateMap<DogEntity, DogDto>().ReverseMap();
            CreateMap<ReportEntity, ReportDto>();
            CreateMap<DogEntity, CreateDogDto>().ReverseMap();
        }
    }
}
