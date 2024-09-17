using CarBook.DTO.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUi.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailAddReviewVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailAddReviewVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(AddCarReviewDto dto)
        {
            return View();
        }
    }
}
