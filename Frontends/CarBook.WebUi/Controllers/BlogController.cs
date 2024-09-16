using CarBook.DTO.BlogDtos;
using CarBook.DTO.CommentDtos;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

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
        var responseMessage = await client.GetAsync("https://localhost:7149/api/Blogs/GetAllBlogsWithAuthors");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<BlogsWithAuthorDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    public async Task<IActionResult> BlogDetail(int id)
    {
        ViewBag.v1 = "Bloglar";
        ViewBag.v2 = "Bloglarımız";
        var client = _httpclientfactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7149/api/Blogs/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<BlogDetailDto>(jsonData);
            ViewBag.id = id;
            return View(values);
        }
        return View();
    }
    [HttpGet]
    public PartialViewResult AddComment()
    {
        return PartialView();
    }
    [HttpPost]
    public async Task<IActionResult> AddComment(AddCommentDto dto)
    {

        var client = _httpclientfactory.CreateClient();
        var jsondata = JsonConvert.SerializeObject(dto);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7149/api/Comments", content);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("BlogDetail", "Blog", new { id = dto.BlogId });
        }

        return View(); // Başarısız olursa mevcut view geri döner
    }
}

