using CarBook.DTO.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CarBook.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MessageList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7149/api/Contacts");
            if (response != null && response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var valeus = JsonConvert.DeserializeObject<List<AdminContactListDto>>(jsonData);
                return View(valeus);
            }
            return View();
        }
    }
}
