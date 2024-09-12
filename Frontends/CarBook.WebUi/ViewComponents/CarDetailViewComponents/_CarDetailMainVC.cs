using CarBook.DTO.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUi.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailMainVC:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailMainVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://localhost:7149/api/Cars/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<CarDetailDto>(jsondata);
                return View(values);
            }
            return View();
        }
    }
}
