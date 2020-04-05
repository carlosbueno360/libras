using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TecLibras.UI.Web.Clients;

namespace TecLibras.UI.Web.Controllers
{
    [Authorize]
    public class PointsController : BaseController
    {
        private readonly IPointsClientApi _pointsClientApi;

        public PointsController(IPointsClientApi pointsClientApi) : base()
        {
            _pointsClientApi = pointsClientApi;
        }

        [HttpGet]
        [Route("points/list-all")]
        public async Task<IActionResult> Index()
        {
            var user = HttpContext.User;
            var userId = user.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                   .Select(c => new Guid(c.Value)).SingleOrDefault();
            var points = await _pointsClientApi.GetPointsByUserId(userId);
            return View(points);
        }

        [HttpGet]
        [Route("points/rank")]
        public async Task<IActionResult> Rank()
        {
            var points = await _pointsClientApi.GetPointsRank();
            return View(points);
        }
    }
}
