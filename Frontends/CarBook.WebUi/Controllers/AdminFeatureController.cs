using CarBook.DTO.BrandDtos;
using CarBook.DTO.CarDtos;
using CarBook.DTO.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text;

namespace CarBook.WebUi.Controllers;

public class AdminFeatureController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminFeatureController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7149/api/Features\r\n");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<FeatureDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    public IActionResult CreateFeatue()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateFeatue(FeatureDto featuredto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(featuredto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7149/api/Features", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateFeature(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response2 = await client.GetAsync($"https://localhost:7149/api/Features/{id}");
        if (response2.IsSuccessStatusCode)
        {
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            var car = JsonConvert.DeserializeObject<FeatureDto>(jsonData2);
            return View(car);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateFeature(FeatureDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7149/api/Features", content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View();
    }

    public async Task<IActionResult> RemoveFeature(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"https://localhost:7149/api/Features?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

}
