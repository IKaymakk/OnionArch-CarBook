using CarBook.DTO.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBook.WebUi.ViewComponents.CarDetailViewComponents
{
    public class _CarBodyTypeListVC : ViewComponent
    {
        IHttpClientFactory _httpClientFactory;

        public _CarBodyTypeListVC(IHttpClientFactory httpClientFactory)
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
                List<SelectListItem> bodytypes = (from x in values
                                                  select new SelectListItem
                                                  {
                                                      Text = x.BodyType,
                                                      Value = x.BodyType
                                                  }).ToList();
                ViewBag.BodyTypes = bodytypes;
                return View(values);
            }
            return View();
        }
    }
}
