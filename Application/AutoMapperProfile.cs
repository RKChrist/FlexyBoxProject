using AutoMapper;
using Domain.Models;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateResturantMappings();
        }

        private void CreateResturantMappings()
        {
            CreateMap<Resturant, ResturantDTO>().ReverseMap();
            CreateMap<Images, ImageDTO>().ReverseMap();
            CreateMap<Openings, OpeningsDTO>().ReverseMap();
            CreateMap<DaysOpen, DaysDTO>().ReverseMap();
        }
    }
}
