using AutoMapper;
using SirSearchALotBusinessLogic.Models;
using SirSearchALotPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirSearchALotBusinessLogic
{
    public static class AutoMapperInitializer
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => 
                {
                    cfg.CreateMap<Person, PersonDTO>().ReverseMap();
                    cfg.CreateMap<Interest, InterestDTO>().ReverseMap();
                });
        }
    }
}
