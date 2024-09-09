using CarBook.DTO.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUi.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Rezervasyon";
            ViewBag.v2 = "Araç Kiralama Formu";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7149/api/Locations");
            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<RentACarLocationDto>>(jsondata);
                List<SelectListItem> LocationList = (from location in values
                                                     select new SelectListItem
                                                     {
                                                         Text = location.Name,
                                                         Value = location.LocationId.ToString()
                                                     }).ToList();
                ViewBag.locations = LocationList;
            }

            return View();
        }
    }
}
