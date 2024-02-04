using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOS.Requests;
using FormulaOne.Entities.DTOS.Responces;

namespace FormulaOne.MappingProfiles
{
    public class domainToResponse:Profile
    {
        public domainToResponse()
        {

            CreateMap<Achivment, DriverAchivmentResponse>()
                .ForMember(dest => dest.Wins,
                opt => opt.MapFrom(src => src.RaceWins)
                );

            CreateMap<Driver, DriverResponse>()
                .ForMember(des=>des.DriverId,opt=>opt.MapFrom(src=>src.Id))
                .ForMember(des=>des.FullName,opt=>opt.MapFrom(src=>$"{src.FirstName} {src.LastName}"));
        }
    }
}
