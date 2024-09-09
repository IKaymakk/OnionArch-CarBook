using CarBook.DTO.StatsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUi.ViewComponents.DefaultViewComponents;

public class _DefaultStatsVC : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    public _DefaultStatsVC(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
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
        var response9 = await client.GetAsync("https://localhost:7149/api/Stats/BlogCount");
        if (response9.IsSuccessStatusCode)
        {
            var jsonData = await response9.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<CountStatsDto>(jsonData);
            ViewBag.BlogCount = value.count;
        }
        var response7 = await client.GetAsync("https://localhost:7149/api/Stats/BrandCount");
        if (response7.IsSuccessStatusCode)
        {
            var jsonData = await response7.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<CountStatsDto>(jsonData);
            ViewBag.BrandCount = value.count;
        }
        return View();
    }
}
