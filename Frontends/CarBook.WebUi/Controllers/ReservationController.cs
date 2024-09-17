using CarBook.DTO.LocationDtos;
using CarBook.DTO.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUi.Controllers;

public class ReservationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ReservationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int id)
    {
        ViewBag.v1 = "Rezervasyon";
        ViewBag.v2 = "Araç Kiralama Formu";
        ViewBag.v3 = id;

        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7149/api/Locations");
        if (response.IsSuccessStatusCode)
        {
            var jsondata = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<RentACarLocationDto>>(jsondata);
            List<SelectListItem> LocationList = (from location in values
                                                 select new SelectListItem
                                                 {
                                                     Text = location.Name,
                                                     Value = location.LocationId.ToString()
                                                 }).ToList();
            ViewBag.locations = LocationList;
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(CreateReservationDto dto, int id)
    {
        // POST isteğini yap
        var client = _httpClientFactory.CreateClient();
        var jsondata2 = JsonConvert.SerializeObject(dto);
        StringContent content = new StringContent(jsondata2, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7149/api/Reservations", content);
        ViewBag.userid = dto.AppUserId;


        if (response.IsSuccessStatusCode)
        {
            ViewBag.Success = "alert alert-success";
            TempData["Message"] = "İşlem Başarıyla Gerçekleşti , Rezervasyon Detayları İçin Mail Kutunuzu Kontrol Ediniz";
            return RedirectToAction("Index");
        }
        ViewBag.v3 = id;
        ViewBag.Fail = "alert alert-danger";
        TempData["Message2"] = "İşlem Gerçekleştirilmedi, Kontrol Ediniz";
        var response2 = await client.GetAsync("https://localhost:7149/api/Locations");
        if (response2.IsSuccessStatusCode)
        {
            var jsondata = await response2.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<RentACarLocationDto>>(jsondata);
            List<SelectListItem> LocationList = values.Select(location => new SelectListItem
            {
                Text = location.Name,
                Value = location.LocationId.ToString()
            }).ToList();
            ViewBag.locations = LocationList;
        }

        return View(dto);
    }
}
