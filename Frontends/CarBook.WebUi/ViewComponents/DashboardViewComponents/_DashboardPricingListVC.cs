using CarBook.DTO.CarPricingsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUi.ViewComponents.DashboardViewComponents
{
    public class _DashboardPricingListVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DashboardPricingListVC(IHttpClientFactory factory)
        {
            _httpClientFactory = factory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.v1 = "Fiyatlandırma";
            ViewBag.v2 = "Araç Fiyatları";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7149/api/CarPricings/CarsListForRent\r\n");
            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CarsListForRentDto>>(jsondata);
                return View(values.TakeLast(5).Reverse());
            }
            return View();
        }
    }
}
