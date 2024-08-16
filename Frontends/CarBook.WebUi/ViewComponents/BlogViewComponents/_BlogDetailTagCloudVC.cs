using CarBook.DTO.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUi.ViewComponents.BlogViewComponents;

public class _BlogDetailTagCloudVC : ViewComponent
{
    IHttpClientFactory _httpClientFactory;

    public _BlogDetailTagCloudVC(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int blogid)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7149/api/Blogs/GetBlogListWithTagClouds" + blogid);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<BlogDetailTagCloudDto>(jsonData);
            return View(values);
        }
        return View();

    }
}