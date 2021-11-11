using AutoMapper;
using Domain;
using Rest.Controllers.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.AutoMapperProfiles
{
    public class LivrosProfile : Profile
    {
        public LivrosProfile()
        {
            CreateMap<Livros, LivrosResponse>();
            CreateMap<LivrosRequest, Livros>();
        }
    }
}
