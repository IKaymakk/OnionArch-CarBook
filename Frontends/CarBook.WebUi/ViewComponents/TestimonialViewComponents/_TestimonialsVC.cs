using CarBook.DTO.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CarBook.WebUi.ViewComponents.TestimonialViewComponents
{
    public class _TestimonialsVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TestimonialsVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7149/api/Testimonials");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<TestimonialResultDto>>(jsondata);
                return View(values);
            }
            return View();
        }
    }
}
