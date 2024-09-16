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
            var responsemessage = await client.GetAsync("https://localhost:7149/api/CarPricings");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CarResultDto>>(jsondata);
                return View(values);
            }
            return View();
        }
    }
}
