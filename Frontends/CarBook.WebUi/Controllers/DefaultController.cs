using CarBook.DTO.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUi.Controllers;

public class DefaultController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DefaultController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7149/api/Locations");
        var jsonData = await response.Content.ReadAsStringAsync();
        var locations = JsonConvert.DeserializeObject<List<RentACarLocationDto>>(jsonData);
        List<SelectListItem> locationList = (from x in locations
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.LocationId.ToString()
                                             }).ToList();
        ViewBag.locations = locationList;
        return View();
    }
    [HttpPost]
    public IActionResult Index(string pickdate,string offdate, string picktime, string offtime, string LocationId)
    {
        TempData["pickdate"] = pickdate;
        TempData["offdate"] = offdate;
        TempData["picktime"] = picktime;
        TempData["offtime"] = offtime;
        TempData["locationid"] = LocationId;
        return RedirectToAction("Index","RentACar");
    }
}
