using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TecLibras.Application.Interfaces;
using TecLibras.Application.ViewModels;
using TecLibras.Domain.Commands;
using TecLibras.Domain.Core.Bus;
using TecLibras.Domain.Interfaces;
using TecLibras.Infra.Data.Repository.EventSourcing;

namespace TecLibras.Application.Services
{
    public class PointsAppService : IPointsAppService
    {
        private readonly IMapper _mapper;
        private readonly IPointsRepository _pointsRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public PointsAppService(IMapper mapper,
                                  IPointsRepository pointsRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _pointsRepository = pointsRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<PointsViewModel> GetAll()
        {
            return _pointsRepository.GetAll().ProjectTo<PointsViewModel>(_mapper.ConfigurationProvider);
        }

        public PointsViewModel GetById(Guid id)
        {
            return _mapper.Map<PointsViewModel>(_pointsRepository.GetById(id));
        }

        public void Register(PointsViewModel pointsViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewPointsCommand>(pointsViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
