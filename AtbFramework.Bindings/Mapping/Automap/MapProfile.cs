using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Application.DTOs;
using AtbFramework.Domain.Entities;
using AtbFramework.Application.Interfaces.DTO;
using AtbFramework.Domain.Commons.Entity;

namespace AtbFramework.Bindings.Mapping.Automap
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<ExampleClass,ExampleDto> ();
            CreateMap<ExampleDto, ExampleClass> ();
        }

      
    }
}
