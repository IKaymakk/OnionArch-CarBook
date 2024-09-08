using CarBook.DTO.RentACarDtos;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUi.Controllers
{
    public class RentACarController : Controller
    {
        private readonly IHttpClientFactory _client;

        public RentACarController(IHttpClientFactory client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index(int id)
        {
            var locationid = TempData["locationid"];
            id = int.Parse(locationid.ToString());
            ViewBag.pickdate = TempData["pickdate"];
            ViewBag.offdate = TempData["offdate"];
            ViewBag.picktime = TempData["picktime"];
            ViewBag.offtime = TempData["offtime"];
            ViewBag.locationid = TempData["locationid"];

            var client = _client.CreateClient();
            var response = await client.GetAsync($"https://localhost:7149/api/RentACars?LocationId={id}&IsAvaible=true");
            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
