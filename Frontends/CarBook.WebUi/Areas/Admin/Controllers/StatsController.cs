using CarBook.DTO.BlogDtos;
using CarBook.DTO.StatsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatsController : Controller
    {
        IHttpClientFactory _httpClientFactory;

        public StatsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7149/api/Stats/CarCount");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CountStatsDto>(jsonData);
                ViewBag.count = value.count;
            }
            var response2 = await client.GetAsync("https://localhost:7149/api/Stats/LocationCount");
            if (response2.IsSuccessStatusCode)
            {
                var jsonData = await response2.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CountStatsDto>(jsonData);
                ViewBag.locationcount = value.count;
            }
            var response3 = await client.GetAsync("https://localhost:7149/api/Stats/AverageDailyCarPrice");
            if (response3.IsSuccessStatusCode)
            {
                var jsonData = await response3.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CountStatsDto>(jsonData);
                ViewBag.AverageDailyCarPrice = (int)Math.Round(value.count);
            }
            var response4 = await client.GetAsync("https://localhost:7149/api/Stats/AverageMonthlyCarPrice");
            if (response4.IsSuccessStatusCode)
            {
                var jsonData = await response4.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CountStatsDto>(jsonData);
                ViewBag.AverageMonthlyCarPrice = (int)Math.Round(value.count);
            }
            var response5 = await client.GetAsync("https://localhost:7149/api/Stats/AverageWeeklyCarPrice");
            if (response5.IsSuccessStatusCode)
            {
                var jsonData = await response5.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CountStatsDto>(jsonData);

                ViewBag.AverageWeeklyCarPrice = (int)Math.Round(value.count);
            }
            var response6 = await client.GetAsync("https://localhost:7149/api/Stats/AverageHourlyCarPrice");
            if (response6.IsSuccessStatusCode)
            {
                var jsonData = await response6.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CountStatsDto>(jsonData);
                ViewBag.AverageHourlyCarPrice = (int)Math.Round(value.count);
            }
            var response7 = await client.GetAsync("https://localhost:7149/api/Stats/BrandCount");
            if (response7.IsSuccessStatusCode)
            {
                var jsonData = await response7.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CountStatsDto>(jsonData);
                ViewBag.BrandCount = value.count;
            }
            var response8 = await client.GetAsync("https://localhost:7149/api/Stats/AuthorCount");
            if (response8.IsSuccessStatusCode)
            {
                var jsonData = await response8.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CountStatsDto>(jsonData);
                ViewBag.AuthorCount = value.count;
            }
            var response9 = await client.GetAsync("https://localhost:7149/api/Stats/BlogCount");
            if (response9.IsSuccessStatusCode)
            {
                var jsonData = await response9.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CountStatsDto>(jsonData);
                ViewBag.BlogCount = value.count;
            }
            var response10 = await client.GetAsync("https://localhost:7149/api/Stats/BrandWithMostCarAndCount");
            if (response10.IsSuccessStatusCode)
            {
                var jsonData = await response10.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<BrandWithMostCarDto>(jsonData);
                ViewBag.BrandWithMostCarAndCount = value.Count;
                ViewBag.BrandWithMostCarAndCount2 = value.brandName;
            }
            var response11 = await client.GetAsync("https://localhost:7149/api/Stats/BlogWithMostCommentAndCount\r\n");
            if (response11.IsSuccessStatusCode)
            {
                var jsonData = await response11.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<BlogWithMostCommentAndCountDto>(jsonData);
                ViewBag.BlogWithMostCommentAndCount = value.count;
                ViewBag.BlogWithMostCommentAndCount2 = value.title.Substring(0,18);
            }

            var response12 = await client.GetAsync("https://localhost:7149/api/Stats/LessThan50000KmCarCount\r\n");
            if (response12.IsSuccessStatusCode)
            {
                var jsonData = await response12.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CountStatsDto>(jsonData);
                ViewBag.LessThan50000KmCarCount = value.count;
            }
            var response13 = await client.GetAsync("https://localhost:7149/api/Stats/GetGasolineOrDieselCount\r\n");
            if (response13.IsSuccessStatusCode)
            {
                var jsonData = await response13.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CountStatsDto>(jsonData);
                ViewBag.GetGasolineOrDieselCount = value.count;
            }
            var response14 = await client.GetAsync("https://localhost:7149/api/Stats/GetDailyMostExpensiveCar\r\n");
            if (response14.IsSuccessStatusCode)
            {
                var jsonData = await response14.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ChapAndExpensiveCarDto>(jsonData);
                ViewBag.GetDailyMostExpensiveCar = value.carName;
                ViewBag.GetDailyMostExpensiveCarBrand = value.carBrand;
                ViewBag.GetDailyMostExpensiveCarImage = value.image;
                ViewBag.GetDailyMostExpensiveCarPrice = value.price;
            }
            var response15 = await client.GetAsync("https://localhost:7149/api/Stats/GetDailyCheapestCar\r\n");
            if (response15.IsSuccessStatusCode)
            {
                var jsonData = await response15.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ChapAndExpensiveCarDto>(jsonData);
                ViewBag.GetDailyCheapestCar = value.carName;
                ViewBag.GetDailyCheapestCarBrand = value.carBrand;
                ViewBag.GetDailyCheapestCarImage = value.image;
                ViewBag.GetDailyCheapestCarPrice = value.price;
            }
            return View();
        }
    }
}
