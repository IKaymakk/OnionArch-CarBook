using CarBook.DTO.BrandDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text;

namespace CarBook.WebUi.Controllers;

public class AdminBrandController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminBrandController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7149/api/Brands");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var brands = JsonConvert.DeserializeObject<List<CreateCarBrandListDto>>(jsonData);
            return View(brands);
        }
        return View();
    }
    [HttpGet]
    public IActionResult CreateBrand()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateCarBrandListDto createCarBrandListDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createCarBrandListDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7149/api/Brands", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> UpdateBrand(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var resposenMessage = await client.GetAsync($"https://localhost:7149/api/Brands/{id}");
        if (resposenMessage.IsSuccessStatusCode)
        {
            var jsonData = await resposenMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateBrandDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7149/api/Brands/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    public async Task<IActionResult> RemoveBrand(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"https://localhost:7149/api/Brands?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> CarListByBrand(int id)
    {
        ViewBag.brandid = id;
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:7149/api/Brands/carsbybrand{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var cars = JsonConvert.DeserializeObject<List<CarListByBrand>>(jsonData);
            return View(cars);
        }
        return View();
    }
}
