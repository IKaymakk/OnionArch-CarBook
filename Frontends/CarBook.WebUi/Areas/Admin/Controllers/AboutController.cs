using CarBook.DTO.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUi.Areas.Admin.Controllers;

[Area("Admin")]
public class AboutController : Controller
{


    private readonly IHttpClientFactory _httpClientFactory;
    public AboutController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> UpdateAbout()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7149/api/Abouts/1\r\n");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var About = JsonConvert.DeserializeObject<AdminAboutDto>(jsonData);
            return View(About);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateAbout(AdminAboutDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("https://localhost:7149/api/Abouts", content);
        if (response.IsSuccessStatusCode)
        {
            ViewBag.Success = "alert alert-success";
            TempData["Message"] = "İşlem Başarıyla Gerçekleşti";
            return RedirectToAction("UpdateAbout");
        }
        else
        {
            ViewBag.Fail = "alert alert-danger";
            TempData["Message2"] = "İşlem Gerçekleştirilmedi, Kontrol Ediniz";
            return View(dto);
        }
      
    }
}

