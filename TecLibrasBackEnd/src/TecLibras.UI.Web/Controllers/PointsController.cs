using System;
using TecLibras.Application.Interfaces;
using TecLibras.Application.ViewModels;
using TecLibras.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TecLibras.UI.Web.Controllers
{
    [Authorize]
    public class PointsController : BaseController
    {
        private readonly IPointsAppService _pointsAppService;

        public PointsController(IPointsAppService pointsAppService, 
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _pointsAppService = pointsAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("points/list-all")]
        public IActionResult Index()
        {
            return View(_pointsAppService.GetAll());
        }
    }
}
