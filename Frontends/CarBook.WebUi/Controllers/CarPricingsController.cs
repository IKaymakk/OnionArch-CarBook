using CarBook.DTO.BrandDtos;
using CarBook.DTO.CarPricingsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace CarBook.WebUi.Controllers
{
    public class CarPricingsController : Controller
    {
        private readonly IHttpClientFactory _factory;

        public CarPricingsController(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Fiyatlandırma";
            ViewBag.v2 = "Araç Fiyatları";

            var client = _factory.CreateClient();
            var response = await client.GetAsync("https://localhost:7149/api/CarPricings/CarsListForRent\r\n");
            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CarsListForRentDto>>(jsondata);
                return View(values);
            }
            return View();
        }


       
    }
}
