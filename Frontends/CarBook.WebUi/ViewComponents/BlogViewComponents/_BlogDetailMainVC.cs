using CarBook.DTO.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUi.ViewComponents.BlogViewComponents
{
    public class _BlogDetailMainVC:ViewComponent
    {
        private readonly IHttpClientFactory _httpclientfactory;

        public _BlogDetailMainVC(IHttpClientFactory httpclientfactory)
        {
            _httpclientfactory = httpclientfactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Bloglarımız";
            return View();
        }
    }
}
