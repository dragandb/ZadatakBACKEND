using AutoMapper;
using ZadatakAPI.Models;
using ZadatakAPI.Models.DTO;


namespace ZadatakAPI
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Kupac, KupacDTO>();
            CreateMap<Kupac, KupacBezIdDTO>();
            CreateMap<KupacForCreationDTO, Kupac>();
            CreateMap<KupacForUpdateDTO, Kupac>();
        }   
    }    
}
