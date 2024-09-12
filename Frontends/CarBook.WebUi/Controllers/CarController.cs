using CarBook.DTO.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUi.Controllers;

public class CarController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CarController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responsemessage = await client.GetAsync("https://localhost:7149/api/CarPricings");
        if (responsemessage.IsSuccessStatusCode)
        {
            var jsondata = await responsemessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CarResultDto>>(jsondata);
            return View(values);
        }
        return View();
    }
    public async Task<IActionResult> CarDetail(int id)
    {
        ViewBag.v1 = "Araç Detayı";
        ViewBag.v2 = id + "Numaralı Araç";
        ViewBag.carid = id;
       
        return View();
    }
}
