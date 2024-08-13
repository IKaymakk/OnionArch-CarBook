using CarBook.DTO.BannerDtos;
using CarBook.DTO.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUi.ViewComponents.DefaultViewComponents
{
    public class _DefaultLast5CarsVC : ViewComponent
    {
        IHttpClientFactory _httpClientFactory;

        public _DefaultLast5CarsVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7149/api/Cars/GetLast5CarsWithBrand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<GetLast5CarsDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
