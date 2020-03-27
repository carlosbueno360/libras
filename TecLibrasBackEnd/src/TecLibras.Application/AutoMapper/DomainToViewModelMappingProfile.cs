using AutoMapper;
using TecLibras.Application.ViewModels;
using TecLibras.Domain.Models;

namespace TecLibras.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Points, PointsViewModel>();
        }
    }
}
