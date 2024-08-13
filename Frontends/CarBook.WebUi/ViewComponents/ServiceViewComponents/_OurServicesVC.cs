using CarBook.DTO.FooterAddressesDtos;
using CarBook.DTO.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUi.ViewComponents.ServiceViewComponents;

public class _OurServicesVC:ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _OurServicesVC(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7149/api/Services");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var readedData = JsonConvert.DeserializeObject<List<ServiceResultDto>>(jsonData);
            return View(readedData);
        }
        return View();
    }

}
