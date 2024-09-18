using CarBook.DTO.CarDtos;
using CarBook.DTO.CarPricingsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using System.Web.Mvc;

namespace CarBook.WebUi.Controllers;

public class CarController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CarController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.v1 = "Araçlar";
        ViewBag.v2 = "Araç Kirala";
        var client = _httpClientFactory.CreateClient();
        var responsemessage = await client.GetAsync("https://localhost:7149/api/CarPricings");
        if (responsemessage.IsSuccessStatusCode)
        {
            var jsondata = await responsemessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CarResultDto>>(jsondata);



            return View(values);
        }
        return View();
    }
    public async Task<IActionResult> FilterIndex(int id)
    {
        ViewBag.v1 = "Araçlar";
        ViewBag.v2 = "Araç Kirala";

        var client = _httpClientFactory.CreateClient();
        var responsemessage = await client.GetAsync("https://localhost:7149/api/CarPricings/GetCarsByBrandIdQuery" + id);
        if (responsemessage.IsSuccessStatusCode)
        {
            var jsondata = await responsemessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CarListFilterDto>>(jsondata);

            if (values == null || !values.Any())
            {
                return View();
            }
            else
            {
                ViewBag.SelectedBrandId = id; // Seçili BrandId'yi ViewBag ile geçiyoruz
                return View(values);
            }
        }
        return View();
    }
    public async Task<IActionResult> FilterByBodyType(string bodytype)
    {
        ViewBag.v1 = "Araçlar";
        ViewBag.v2 = "Araç Kirala";

        var client = _httpClientFactory.CreateClient();
        var responsemessage = await client.GetAsync("https://localhost:7149/api/CarPricings/GetCarsByBodyTypeQuery?bodytype=" + bodytype);
        if (responsemessage.IsSuccessStatusCode)
        {
            var jsondata = await responsemessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CarFilterBodyTypeDto>>(jsondata);


            if (values == null || !values.Any())
            {
                return View(values);

            }
            else
            {
                ViewBag.SelectedBodyType = bodytype;
                return View(values);
            }
        }
        return View();
    }
    public async Task<IActionResult> CarDetail(int id)
    {
        ViewBag.v1 = "Araç Detayı";
        ViewBag.v2 = id + "Numaralı Araç";
        ViewBag.carid = id;
        TempData["carid"] = id;

        return View();
    }
    [Microsoft.AspNetCore.Mvc.HttpPost]
    public async Task<IActionResult> AddCarReview(AddCarReviewDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        dto.customerName = TempData["userName"].ToString();
        dto.reviewDate = DateTime.Now;
        dto.customerImage = "Yok";
        dto.carId = Convert.ToInt32(TempData["carid"]);
        dto.appUserId = Convert.ToInt32(TempData["userId"]);
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7149/api/Reviews", content);
        if (response.IsSuccessStatusCode)
        {
            ViewBag.Success = "alert alert-success";
            TempData["Message"] = "Değerlendirmeniz Kaydedildi";
            return RedirectToAction("CarDetail", "Car", new { id = dto.carId });
        }
        else
        {
            ViewBag.Fail = "alert alert-danger";
            TempData["Message2"] = "Değerlendirme Yapabilmeniz İçin Rezervasyon Yapmanız Gerekmektedir.";
            return RedirectToAction("CarDetail", "Car", new { id = dto.carId });
        }
    }
}
