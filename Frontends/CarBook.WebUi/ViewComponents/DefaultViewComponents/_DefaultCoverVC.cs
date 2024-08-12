using CarBook.DTO.BannerDtos;
using CarBook.DTO.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUi.ViewComponents.DefaultViewComponents;

public class _DefaultCoverVC : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultCoverVC(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7149/api/Banners/2");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<BannerCoverDto>(jsonData);
            return View(values);
        }
        return View();
    }
}
