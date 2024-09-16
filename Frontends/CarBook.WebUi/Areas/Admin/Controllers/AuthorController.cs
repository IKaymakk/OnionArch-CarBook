using CarBook.DTO.AuthorDtos;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUi.Areas.Admin.Controllers;
[Authorize(Roles = "Admin")]

[Area("Admin")]
public class AuthorController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AuthorController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7149/api/Authors");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<AdminAuthorDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    public IActionResult CreateAuthor()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateAuthor(CreateAuthorDto Authordto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(Authordto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7149/api/Authors", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            ViewBag.Success = "alert alert-success";
            TempData["Message"] = "İşlem Başarıyla Gerçekleşti";
            return RedirectToAction("Index");
        }
        else
        {
            ViewBag.Fail = "alert alert-danger";
            TempData["Message2"] = "İşlem Gerçekleştirilmedi, Kontrol Ediniz";
            return View();
        }
    }

    [HttpGet]
    public async Task<IActionResult> UpdateAuthor(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response2 = await client.GetAsync($"https://localhost:7149/api/Authors/{id}");
        if (response2.IsSuccessStatusCode)
        {
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            var car = JsonConvert.DeserializeObject<UpdateAuthorDto>(jsonData2);
            return View(car);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7149/api/Authors", content);
        if (responseMessage.IsSuccessStatusCode)
        {
            ViewBag.Success = "alert alert-success";
            TempData["Message"] = "İşlem Başarıyla Gerçekleşti";
            return RedirectToAction("Index");
        }
        ViewBag.Fail = "alert alert-danger";
        TempData["Message2"] = "İşlem Gerçekleştirilmedi, Kontrol Ediniz";
        return View();
    }

    public async Task<IActionResult> BlogListByAuthor(int id)
    {
        ViewBag.authorid = id;
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:7149/api/Authors/BlogListByAuthor{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var bloglist = JsonConvert.DeserializeObject<List<BlogListByAuthorDto>>(jsonData);
            return View(bloglist);
        }
        return View();
    }
    public async Task<IActionResult> RemoveAuthor(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"https://localhost:7149/api/Authors?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
