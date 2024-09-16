using CarBook.DTO.ServiceDtos;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUi.Controllers;

public class AdminServicesController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminServicesController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7149/api/Services");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ServiceListDto>>(jsonData);
            return View(values);
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateService(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7149/api/Services/" + id);
        var jsondata = await response.Content.ReadAsStringAsync();
        var service = JsonConvert.DeserializeObject<ServiceListDto>(jsondata);
        return View(service);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateService(ServiceListDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("https://localhost:7149/api/Services", content);
        if (response.IsSuccessStatusCode)
        {
            ViewBag.Success = "alert alert-success";
            TempData["Message"] = "İşlem Başarıyla Gerçekleşti";
            return RedirectToAction("Index");
        }
        else
        {
            ViewBag.Fail = "alert alert-danger";
            TempData["Message2"] = "İşlem Gerçekleştirilmedi, Kontrol Ediniz";
            return View(dto);
        }
    }
    public async Task<IActionResult> RemoveServiceById(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync("https://localhost:7149/api/Services?id=" + id);
        if (response.IsSuccessStatusCode)
        {
            ViewBag.Success = "alert alert-success";
            TempData["Message"] = "İşlem Başarıyla Gerçekleşti";
            return RedirectToAction("Index");
        }
        else
        {
            ViewBag.Fail = "alert alert-danger";
            TempData["Message2"] = "İşlem Gerçekleştirilmedi, Kontrol Ediniz";
            return RedirectToAction("Index");
        }
    }
    [HttpGet]
    public IActionResult CreateService()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateService(ServiceListDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7149/api/Services", content);
        if (response.IsSuccessStatusCode)
        {
            ViewBag.Success = "alert alert-success";
            TempData["Message"] = "İşlem Başarıyla Gerçekleşti";
            return RedirectToAction("Index");
        }
        else
        {
            ViewBag.Fail = "alert alert-danger";
            TempData["Message2"] = "İşlem Gerçekleştirilmedi, Kontrol Ediniz";
            return View(dto);
        }
    }
}