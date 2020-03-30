using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TecLibras.Services.Api.ViewModels;
using TecLibras.Services.Api.Repositories;

namespace TecLibras.Services.Api.Controllers
{
    [Authorize]
    public class PointsController : ApiController
    {
        private readonly IPointsRepository _pointsRepository;

        public PointsController(
            IPointsRepository pointsRepository) : base()
        {
            _pointsRepository = pointsRepository;
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
        [Authorize(Policy = "CanWritePointsData")]
        [Route("points")]
        public IActionResult Post([FromBody]PointsViewModel pointsViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(pointsViewModel);
            }

            //_pointsRepository.Add(pointsViewModel); TODO

            return Response(pointsViewModel);
        }
    }
}
