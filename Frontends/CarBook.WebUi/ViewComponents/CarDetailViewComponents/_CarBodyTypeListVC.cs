using CarBook.DTO.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBook.WebUi.ViewComponents.CarDetailViewComponents
{
    public class _CarBodyTypeListVC : ViewComponent
    {
        IHttpClientFactory _httpClientFactory;

        public _CarBodyTypeListVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
