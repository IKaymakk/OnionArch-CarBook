using CarBook.DTO.StatsDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace CarBook.WebUi.ViewComponents.DashboardViewComponents
{
    public class _DashboardStatsVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardStatsVC(IHttpClientFactory factory)
        {
            _httpClientFactory = factory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7149/api/Stats/CarCount");
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<CountStatsDto>(jsonData);
            ViewBag.count = value.count;

            var response2 = await client.GetAsync("https://localhost:7149/api/Stats/LocationCount");
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            var value2 = JsonConvert.DeserializeObject<CountStatsDto>(jsonData2);
            ViewBag.locationcount = value2.count;

            var response3 = await client.GetAsync("https://localhost:7149/api/Stats/AverageDailyCarPrice");
            var jsonData3 = await response3.Content.ReadAsStringAsync();
            var value3 = JsonConvert.DeserializeObject<CountStatsDto>(jsonData3);
            ViewBag.AverageDailyCarPrice = (int)Math.Round(value3.count);

            var response7 = await client.GetAsync("https://localhost:7149/api/Stats/BrandCount");
            var jsonData4 = await response7.Content.ReadAsStringAsync();
            var value4 = JsonConvert.DeserializeObject<CountStatsDto>(jsonData4);
            ViewBag.BrandCount = value4.count;

            return View();
        }
    }
}
