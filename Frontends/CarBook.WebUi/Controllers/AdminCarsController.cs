using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUi.Controllers;

public class AdminCarsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}
