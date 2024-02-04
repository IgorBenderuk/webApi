using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOS.Requests;
namespace FormulaOne.MappingProfiles
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            CreateMap<CreateDriveAchivmentRequest, Achivment>()
                .ForMember(dest => dest.RaceWins,
                opt => opt.MapFrom(src => src.Wins)
                )
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1))
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdationDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateDriveAchivmentRequest, Achivment>()
               .ForMember(dest => dest.RaceWins,
               opt => opt.MapFrom(src => src.Wins)
               )
               .ForMember(dest => dest.UpdationDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<CreateDriverRequest, Driver>()
                .ForMember(dest=>dest.Status,opt =>opt.MapFrom(src => 1)
                )
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdationDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateDriverRequest, Driver>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1)
                )
                .ForMember(dest => dest.UpdationDate, opt => opt.MapFrom(src => DateTime.UtcNow));

        }
    }
}
