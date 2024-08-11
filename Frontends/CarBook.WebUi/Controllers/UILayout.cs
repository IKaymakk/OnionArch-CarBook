using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUi.Controllers
{
    public class UILayout : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
