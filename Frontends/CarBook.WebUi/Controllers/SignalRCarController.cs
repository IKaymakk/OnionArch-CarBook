using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUi.Controllers
{
    public class SignalRCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
