﻿using AutoMapper;
using Example.Services.Catalog.Dtos;
using Example.Services.Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Services.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Course, CourseDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Feature, FeatureDto>().ReverseMap();
          
            CreateMap<Course, CourseCreateDto>().ReverseMap();
            
            CreateMap<Course, CourseUpdateDto>().ReverseMap();


        }
    }
}
