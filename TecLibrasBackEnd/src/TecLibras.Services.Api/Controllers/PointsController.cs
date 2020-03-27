using System;
using TecLibras.Application.Interfaces;
using TecLibras.Application.ViewModels;
using TecLibras.Domain.Core.Bus;
using TecLibras.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TecLibras.Services.Api.Controllers
{
    [Authorize]
    public class PointsController : ApiController
    {
        private readonly IPointsAppService _pointsAppService;

        public PointsController(
            IPointsAppService pointsAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _pointsAppService = pointsAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("points")]
        public IActionResult Get()
        {
            return Response(_pointsAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("points/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var pointsViewModel = _pointsAppService.GetById(id);

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

            _pointsAppService.Register(pointsViewModel);

            return Response(pointsViewModel);
        }
    }
}
