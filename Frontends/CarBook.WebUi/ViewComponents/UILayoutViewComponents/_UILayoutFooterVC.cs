using CarBook.DTO.ContactDtos;
using CarBook.DTO.FooterAddressesDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUi.ViewComponents.UILayoutViewComponents;

public class _UILayoutFooterVC : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _UILayoutFooterVC(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7149/api/FooterAddress/6");
        if (response.IsSuccessStatusCode)
        {
            var jsondata = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<FooterAddressDto>(jsondata);
            ViewBag.Address = values.Address;
            ViewBag.Mail = values.EMail;
            ViewBag.Phone = values.Phone;
        }
        return View();
    }
}
