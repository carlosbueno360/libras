using AutoMapper;
using TecLibras.Services.Api.Models;
using TecLibras.Services.Api.ViewModels;

namespace TecLibras.Services.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Points, PointsViewModel>();
        }
    }
}
