using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUi.Controllers;

public class DefaultController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
