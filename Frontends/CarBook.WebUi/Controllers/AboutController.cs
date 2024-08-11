using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUi.Controllers;

public class AboutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
