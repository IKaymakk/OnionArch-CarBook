using CarBook.DTO.CarDtos;
using CarBook.DTO.CarFeaturesDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUi.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailFeaturesVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailFeaturesVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7149/api/CarFeatures/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CarDetailFeaturesDto>>(jsondata);
                return View(values);
            }
            return View();
        }
    }
}
