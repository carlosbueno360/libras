using AutoMapper;
using TecLibras.Application.ViewModels;
using TecLibras.Domain.Commands;

namespace TecLibras.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PointsViewModel, RegisterNewPointsCommand>()
                .ConstructUsing(c => new RegisterNewPointsCommand(c.Id, c.Points));
        }
    }
}
