using CarBook.DTO.BrandDtos;
using CarBook.DTO.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUi.Controllers;

public class AdminCarsController : Controller
{
    IHttpClientFactory _httpClientFactory;

    public AdminCarsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7149/api/Cars/CarsListWithBrands");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<AdminCarListDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> CreateCar()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7149/api/Brands");
        var jsonData = await response.Content.ReadAsStringAsync();
        var brands = JsonConvert.DeserializeObject<List<CreateCarBrandListDto>>(jsonData);
        List<SelectListItem> brandValues = (from x in brands
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.BrandId.ToString()
                                            }).ToList();
        ViewBag.BrandValues = brandValues;
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createCarDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7149/api/Cars", stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    public async Task<IActionResult> RemoveCar(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"https://localhost:7149/api/Cars?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> UpdateCar(int id)
    {
        ViewBag.CarId = 0;
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("https://localhost:7149/api/Brands");
        var jsonData = await response.Content.ReadAsStringAsync();
        var brands = JsonConvert.DeserializeObject<List<CreateCarBrandListDto>>(jsonData);
        List<SelectListItem> brandValues = (from x in brands
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.BrandId.ToString()
                                            }).ToList();
        ViewBag.BrandValues = brandValues;

        var response2 = await client.GetAsync($"https://localhost:7149/api/Cars/{id}");
        if (response2.IsSuccessStatusCode)
        {
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            var car = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData2);
            return View(car);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateCar(UpdateCarDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData =  JsonConvert.SerializeObject(dto);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7149/api/Cars", content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        else
        {
            // Marka verilerini tekrar yükleyin
            var response = await client.GetAsync("https://localhost:7149/api/Brands");
            var jsonData2 = await response.Content.ReadAsStringAsync();
            var brands = JsonConvert.DeserializeObject<List<CreateCarBrandListDto>>(jsonData2);
            List<SelectListItem> brandValues = (from x in brands
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.BrandId.ToString()
                                                }).ToList();
            ViewBag.BrandValues = brandValues;
            return View();
        }
    }
   
}