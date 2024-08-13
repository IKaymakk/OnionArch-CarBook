using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUi.Controllers;

public class AboutController : Controller
{
    public IActionResult Index()
    {
        ViewBag.v1 = "Hakkımızda";
        ViewBag.v2 = "CarBook";
        return View();
    }
}
