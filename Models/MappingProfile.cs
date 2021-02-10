using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Starset.Models;

namespace Starset.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<ApplicationUser, RegisterViewModel>();
            Mapper.CreateMap<object, RegisterViewModel>();
            Mapper.CreateMap<RegisterViewModel, ApplicationUser >();
            Mapper.CreateMap<RegisterViewModel, object>();
        }
    }
}