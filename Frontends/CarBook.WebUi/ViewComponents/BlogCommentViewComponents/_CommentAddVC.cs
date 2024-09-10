using CarBook.DTO.CommentDtos;
using CarBook.DTO.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing.Printing;
using System.Text;

namespace CarBook.WebUi.ViewComponents.BlogCommentViewComponents;

public class _CommentAddVC : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _CommentAddVC(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IViewComponentResult Invoke()
    {
        return View();
    }

}
