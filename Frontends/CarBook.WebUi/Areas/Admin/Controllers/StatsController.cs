using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
