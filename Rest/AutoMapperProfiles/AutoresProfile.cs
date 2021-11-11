using AutoMapper;
using Domain;
using Rest.Controllers.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.AutoMapperProfiles
{
    public class AutoresProfile : Profile
    {
        public AutoresProfile()
        {
            CreateMap<Autores, AutoresResponse>();
            CreateMap<AutoresRequest, Autores>();
        }
    }
}
