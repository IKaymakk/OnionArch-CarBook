using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUi.Controllers
{
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
