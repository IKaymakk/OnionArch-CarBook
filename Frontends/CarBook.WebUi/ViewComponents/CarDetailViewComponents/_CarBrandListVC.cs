using CarBook.DTO.BrandDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUi.ViewComponents.CarDetailViewComponents
{
    public class _CarBrandListVC : ViewComponent
    {
        private readonly IHttpClientFactory _factory;

        public _CarBrandListVC(IHttpClientFactory factory)
        {
            _factory = factory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("https://localhost:7149/api/Brands");
            var jsondata = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CreateCarBrandListDto>>(jsondata);
            return View(values);
        }
    }
}
