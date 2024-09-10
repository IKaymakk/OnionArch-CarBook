using CarBook.DTO.CarFeaturesDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUi.Controllers
{
    public class AdminCarFeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> CarDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7149/api/CarFeatures/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CarFeatureListDto>>(jsondata);
                ViewBag.carid = id;
                var firstItem = values?.FirstOrDefault();
                if (firstItem != null)
                {
                    ViewBag.BrandName = firstItem.brandName;
                    ViewBag.CarModel = firstItem.carModel;
                }
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CarDetail(List<CarFeatureListDto> dto)
        {
          
            return View();
        }
    }
}
