using CarBook.DTO.BlogDtos;
using CarBook.DTO.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUi.ViewComponents.BlogCommentViewComponents;

public class _CommentListByBlogVC : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _CommentListByBlogVC(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int id)
    {

        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7149/api/Comments/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CommentListDto>>(jsonData);
            ViewBag.Count = result.Count();
            return View(result);
        }
        return View();
    }
}