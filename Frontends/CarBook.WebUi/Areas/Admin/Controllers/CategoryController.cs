using CarBook.DTO.CategoryDtos;
using CarBook.DTO.CategoryDtos;
using CarBook.DTO.FeatureDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUi.Areas.Admin.Controllers;
[Authorize(Roles = "Admin")]

[Area("Admin")]
public class CategoryController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public CategoryController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7149/api/Categories/CategoriesWithBlogCounts");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<AdminCategoryListDto>>(jsonData);
            return View(categories);
        }
        return View();
    }
    public async Task<IActionResult> UpdateCategory(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:7149/api/Categories/{id}");
        if (response.IsSuccessStatusCode)
        {

            var jsonData = await response.Content.ReadAsStringAsync();
            var Category = JsonConvert.DeserializeObject<AdminCategoryUpdateDto>(jsonData);
            return View(Category);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateCategory(AdminCategoryUpdateDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("https://localhost:7149/api/Categories", content);
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
    public async Task<IActionResult> RemoveCategory(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"https://localhost:7149/api/Categoriesid={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    [HttpGet]
    public IActionResult CreateCategory()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory(AdminCategoryCreateDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7149/api/Categories", stringContent);
        if (response.IsSuccessStatusCode)
        {
            ViewBag.Success = "alert alert-success";
            TempData["Message"] = "İşlem Başarıyla Gerçekleşti";
            return RedirectToAction("Index");
        }
        ViewBag.Fail = "alert alert-danger";
        TempData["Message2"] = "İşlem Gerçekleştirilmedi, Kontrol Ediniz";
        return View(dto);
    }
}
