using CarBook.DTO.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUi.ViewComponents.DashboardViewComponents;

public class _DashboardBlogListVC : ViewComponent
{
    IHttpClientFactory _httpClientFactory;
    public _DashboardBlogListVC(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7149/api/Blogs");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var blogs = JsonConvert.DeserializeObject<List<AdminBlogListDto>>(jsonData);
            return View(blogs.TakeLast(5).Reverse());
        }
        return View();
    }
}
