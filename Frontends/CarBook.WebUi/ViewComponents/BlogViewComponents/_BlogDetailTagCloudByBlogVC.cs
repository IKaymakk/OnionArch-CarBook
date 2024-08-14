using CarBook.DTO.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUi.ViewComponents.BlogViewComponents;

public class _BlogDetailTagCloudByBlogVC : ViewComponent
{
    IHttpClientFactory _httpClientFactory;

    public _BlogDetailTagCloudByBlogVC(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7149/api/Blogs/blog/27");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<BlogWithTagCloudDto>(jsonData);
            return View(values);
        }
        return View();

    }
}