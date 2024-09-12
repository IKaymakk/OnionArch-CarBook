using CarBook.DTO.CarFeaturesDtos;
using CarBook.DTO.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Transactions;

namespace CarBook.WebUi.Controllers;

public class AdminCarFeatureController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminCarFeatureController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> CarDetail(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:7149/api/CarFeatures/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsondata = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CarFeatureListDto>>(jsondata);
            ViewBag.carid = id;
            var firstItem = values?.FirstOrDefault();
            if (firstItem != null)
            {
                ViewBag.BrandName = firstItem.brandName;
                ViewBag.CarModel = firstItem.carModel;
            }
            return View(values);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CarDetail(List<CarFeatureListDto> dto)
    {

        int carId = dto.First().carId;
        var client = _httpClientFactory.CreateClient();
        foreach (var x in dto)
        {
            if (x.avaible)
            {
                await client.GetAsync($"https://localhost:7149/api/CarFeatures/ToTrue?id={x.carFeatureId}");

            }
            else
            {
                await client.GetAsync($"https://localhost:7149/api/CarFeatures/Tofalse?id={x.carFeatureId}");

            }

        }
        return RedirectToAction("CarDetail", "AdminCarFeature", new { id = carId });
    }
    [HttpGet]
    public async Task<IActionResult> CreateFeatureByCarId(int id)
    {
        ViewBag.carId = id;
        var client = _httpClientFactory.CreateClient();

        var featuresResponse = await client.GetAsync("https://localhost:7149/api/Features");
        var carFeaturesResponse = await client.GetAsync($"https://localhost:7149/api/CarFeatures/{id}");

        if (featuresResponse.IsSuccessStatusCode && carFeaturesResponse.IsSuccessStatusCode)
        {
            var jsonFeatures = await featuresResponse.Content.ReadAsStringAsync();
            var jsonCarFeatures = await carFeaturesResponse.Content.ReadAsStringAsync();

            var allFeatures = JsonConvert.DeserializeObject<List<ResultFeatureWithAvaibleDto>>(jsonFeatures);
            var existingCarFeatures = JsonConvert.DeserializeObject<List<ResultFeatureWithAvaibleDto>>(jsonCarFeatures);

            var existingFeatureIds = existingCarFeatures.Select(cf => cf.FeatureId).ToHashSet();

            var availableFeatures = allFeatures
                .Where(f => !existingFeatureIds.Contains(f.FeatureId))
                .ToList();

            CreateCarFeatureDto model = new CreateCarFeatureDto
            {
                Features = availableFeatures,
                CarId = id
            };

            return View(model);
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeatureByCarId(CreateCarFeatureDto createCarFeatureDto)
    {
        CreateCarFeatureDetailDto model = new CreateCarFeatureDetailDto();
        model.CarId = createCarFeatureDto.CarId;
        var client = _httpClientFactory.CreateClient();
        foreach (var item in createCarFeatureDto.Features)
        {
            if (item.Avaible)
            {
                model.FeatureId = item.FeatureId;
                item.Avaible = true;
                var jsondata = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7149/api/CarFeatures", content);
            }
          
        }
        return RedirectToAction("Index", "AdminCars");
    }
}
