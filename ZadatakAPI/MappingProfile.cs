using AutoMapper;
using ZadatakAPI.Models;
using ZadatakAPI.Models.DTO;


namespace ZadatakAPI
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
         //KUPAC
            CreateMap<Kupac, KupacDTO>();
            CreateMap<Kupac, KupacBezIdDTO>();
            CreateMap<KupacForCreationDTO, Kupac>();
            CreateMap<KupacForUpdateDTO, Kupac>();

         //PROIZVOD
            CreateMap<Proizvod, ProizvodDTO>();
            CreateMap<ProizvodForCreationDTO, Proizvod>();
            CreateMap<ProizvodForUpdateDTO, Proizvod>();

         //PROIZVOD
            CreateMap<Zaglavlje_racuna, RacunDTO>();
            CreateMap<RacunForCreationDTO, Zaglavlje_racuna>();
            CreateMap<RacunFroUpdateDTO, Zaglavlje_racuna>();

         //PROIZVOD
            CreateMap<Stavke_racuna, StavkaDTO>();
            CreateMap<StavkaForCreationDTO, Stavke_racuna>();
            CreateMap<StavkaForUpdateDTO, Stavke_racuna>();
        }   
    }    
}
