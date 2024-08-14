using CarBook.DTO.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUi.Controllers;

public class BlogController : Controller
{
    private readonly IHttpClientFactory _httpclientfactory;

    public BlogController(IHttpClientFactory httpclientfactory)
    {
        _httpclientfactory = httpclientfactory;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.v1 = "Bloglar";
        ViewBag.v2 = "Bloglarımız";

        var client = _httpclientfactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7149/api/Blogs/GetAllBlogsWithAuthors\r\n");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<BlogsWithAuthorDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    public async Task<IActionResult> BlogDetail()
    {
        ViewBag.v1 = "Bloglar";
        ViewBag.v2 = "";
        return View();
    }
}
