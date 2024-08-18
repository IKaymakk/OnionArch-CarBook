using CarBook.DTO.BannerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUi.Areas.Admin.Controllers;

[Area("Admin")]
public class BannerController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public BannerController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7149/api/Banners");
        if (response != null && response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var banner = JsonConvert.DeserializeObject<List<BannerCoverDto>>(jsonData);
            return View(banner);
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateBanner()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7149/api/Banners/2");
        if (response.IsSuccessStatusCode)
        {

            var jsonData = await response.Content.ReadAsStringAsync();
            var banner = JsonConvert.DeserializeObject<BannerCoverDto>(jsonData);
            return View(banner);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateBanner(BannerCoverDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("https://localhost:7149/api/Banners", content);
        if (response.IsSuccessStatusCode)
        {
            ViewBag.Success = "alert alert-success";
            TempData["Message"] = "İşlem Başarıyla Gerçekleşti";
            return RedirectToAction("UpdateBanner");
        }
        else
        {
            ViewBag.Fail = "alert alert-danger";
            TempData["Message2"] = "İşlem Gerçekleştirilmedi, Kontrol Ediniz";
            return View(dto);
        }

    }
    public async Task<IActionResult> RemoveBanner(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"https://localhost:7149/api/Banners?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
