﻿using AutoMapper;
using TecLibras.Services.Api.Model;
using TecLibras.Services.Api.Models;
using TecLibras.Services.Api.ViewModels;

namespace TecLibras.Services.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<PointEvent, PointsViewModel>().ReverseMap();
            CreateMap<Rank, RankViewModel>().ReverseMap();
            CreateMap<Question, QuestionViewModel>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserViewModel>().ReverseMap();
        }
    }
}
