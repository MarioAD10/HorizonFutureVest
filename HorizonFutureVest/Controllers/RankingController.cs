using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HorizonFutureVest.Web.Controllers
{
    [Authorize]
    public class RankingController : Controller
    {
        private readonly IRankingService _rankingService;

        public RankingController(IRankingService rankingService)
        {
            _rankingService = rankingService;
        }

        // GET: Ranking/Index?year=2024
        public IActionResult Index(int year = 2024)
        {
            var ranking = _rankingService.GetRanking(year);
            ViewBag.Year = year;
            return View(ranking);
        }
    }
}

