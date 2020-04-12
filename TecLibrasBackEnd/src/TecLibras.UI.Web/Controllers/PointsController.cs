using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TecLibras.UI.Web.Clients;
using TecLibras.UI.Web.ViewComponents;

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
            var user = HttpContext.User;// Get user Context 

            // Get userId from user Claims
            var userId = user.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                   .Select(c => new Guid(c.Value)).SingleOrDefault();

            // Get all history of point to this user by Id
            var points = await _pointsClientApi.GetPointsByUserId(userId);

            //Pass the points 
            RankChartView rankChart = new RankChartView(points);
            return View(rankChart);
        }

        [HttpGet]
        [Route("points/rank")]
        public async Task<IActionResult> Rank()
        {
            var points = await _pointsClientApi.GetPointsRank();
            return View(points);
        }
    }

    public class RankChartView
    {
        public RankChartView(List<PointsViewModel> pointsViewModels)
        {
            Dates = new List<String>();
            Points = new List<Decimal>();
            pointsViewModels.GroupBy(x => x.DateTime.ToShortDateString())
                .ToList()
                .ForEach(x =>
                {
                    Dates.Add(x.Key);
                    Points.Add(x.Sum(x => x.Points));
                });
        }
        public List<Decimal> Points { get; set; }

        public List<String> Dates { get; set; }
    }
}
