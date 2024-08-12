using CarBook.DTO.CarDtos;
using CarBook.DTO.FooterAddressesDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUi.ViewComponents.FooterAddressViewComponents;

public class _FooterAddressVC : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _FooterAddressVC(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7149/api/FooterAddress/6");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var readedData = JsonConvert.DeserializeObject<FooterAddressDto>(jsonData);
            return View(readedData);
        }
        return View();
    }
}
