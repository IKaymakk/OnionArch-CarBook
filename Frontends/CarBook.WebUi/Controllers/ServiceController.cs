using CarBook.DTO.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUi.Controllers;

public class ServiceController : Controller
{

    public IActionResult Index()
    {
        ViewBag.v1 = "Hizmetler";
        ViewBag.v2 = "Hizmetlerimiz";
        return View();
    }
}
