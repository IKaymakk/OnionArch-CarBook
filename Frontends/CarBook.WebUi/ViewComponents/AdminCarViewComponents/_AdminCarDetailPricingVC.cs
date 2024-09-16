using CarBook.DTO.CarDtos;
using CarBook.DTO.CarPricingsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUi.ViewComponents.AdminCarViewComponents
{
    public class _AdminCarDetailPricingVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminCarDetailPricingVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7149/api/CarPricings/CarDetailForAdmin" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var carvalues = JsonConvert.DeserializeObject<UpdateCarPricingDto>(jsondata); // `UpdateCarDto`'ya deseralize edin
                return View(carvalues); // Bu modeli view'e gönderin
            }
            return View();
        }
    }
}
