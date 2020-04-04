using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TecLibras.Services.Api.ViewModels;
using TecLibras.Services.Api.Repositories;
using AutoMapper;
using TecLibras.Services.Api.Model;

namespace TecLibras.Services.Api.Controllers
{
    [Authorize]
    public class PointsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IPointEventRepository _pointsRepository;

        public PointsController(IMapper mapper,
            IPointEventRepository pointsRepository) : base()
        {
            _pointsRepository = pointsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("points")]
        public IActionResult Get()
        {
            return Response(_pointsRepository.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("points/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var pointsViewModel = _pointsRepository.GetById(id);

            return Response(pointsViewModel);
        }     

        [HttpPost]
        //[Authorize(Policy = "CanWritePointsData")]
        [AllowAnonymous]
        [Route("points")]
        public IActionResult Post([FromBody]PointsViewModel pointsViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(pointsViewModel);
            }
            var pointEvent = _mapper.Map<PointEvent>(pointsViewModel);
            _pointsRepository.Add(pointEvent);
            _pointsRepository.SaveChanges();

            return Response(pointsViewModel);
        }
    }
}
