using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TecLibras.UI.Web.Controllers
{
    [Authorize]
    public class PointsController : BaseController
    {

        public PointsController() : base()
        {
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("points/list-all")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
