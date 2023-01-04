using IntegrationAPI.DTO;
using IntegrationLibrary.BloodBank;

using AutoMapper;
using Profile = AutoMapper.Profile;
using IntegrationLibery.News;

namespace IntegrationAPI.Mapper
{
    public class BloodBankProfile : Profile
    {
        public BloodBankProfile(){
            CreateMap<BloodBank, BloodBankDTO>().ReverseMap();
            CreateMap<ReportDTO, ReporttDTO>().ReverseMap();
            CreateMap<Message, NewsDTO>().ReverseMap();
        }
        
    }
}
