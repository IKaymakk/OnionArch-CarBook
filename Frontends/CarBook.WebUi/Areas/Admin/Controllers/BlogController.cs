using CarBook.DTO.BlogDtos;
using CarBook.DTO.BrandDtos;
using CarBook.DTO.CommentDtos;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text;

namespace CarBook.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private async Task PopulateViewBags()
        {
            var client = _httpClientFactory.CreateClient();

            // Authors listesini
            var response = await client.GetAsync("https://localhost:7149/api/Authors");
            var jsonData = await response.Content.ReadAsStringAsync();
            var authors = JsonConvert.DeserializeObject<List<AdminBlogCreateAuthorListDto>>(jsonData);
            List<SelectListItem> authorvalues = (from x in authors
                                                 select new SelectListItem
                                                 {
                                                     Text = x.name + " " + x.surname,
                                                     Value = x.authorId.ToString()
                                                 }).ToList();
            ViewBag.AuthorValues = authorvalues;

            // Categories listesini
            var response2 = await client.GetAsync("https://localhost:7149/api/Categories/CategoriesWithBlogCounts");
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<AdminBlogCreateCategoryListDto>>(jsonData2);
            List<SelectListItem> categoryvalues = (from x in categories
                                                   select new SelectListItem
                                                   {
                                                       Text = x.name,
                                                       Value = x.categoryId.ToString()
                                                   }).ToList();
            ViewBag.CategoryValues = categoryvalues;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7149/api/Blogs");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var blogs = JsonConvert.DeserializeObject<List<AdminBlogListDto>>(jsonData);
                return View(blogs);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            await PopulateViewBags();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(AdminBlogCreateDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7149/api/Blogs", content);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Success = "alert alert-success";
                TempData["Message"] = "İşlem Başarıyla Gerçekleşti";
                return RedirectToAction("Index");
            }
            await PopulateViewBags();
            ViewBag.Fail = "alert alert-danger";
            TempData["Message2"] = "İşlem Gerçekleştirilmedi, Kontrol Ediniz";
            return View(dto);
        }
        public async Task<IActionResult> RemoveBlog(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7149/api/Blogs?id={id}");
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Success = "alert alert-success";
                TempData["Message"] = "İşlem Başarıyla Gerçekleşti";
                return RedirectToAction("Index");
            }
            ViewBag.Fail = "alert alert-danger";
            TempData["Message2"] = "İşlem Gerçekleştirilmedi, Kontrol Ediniz";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            ViewBag.blogid = id;
            await PopulateViewBags();
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7149/api/Blogs/" + id);
            if (response.IsSuccessStatusCode)
            {

                var jsonData = await response.Content.ReadAsStringAsync();
                var Blog = JsonConvert.DeserializeObject<AdminBlogUpdateDto>(jsonData);
                return View(Blog);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(AdminBlogUpdateDto dto)
        {
            await PopulateViewBags();
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7149/api/Blogs", content);
           
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Success = "alert alert-success";
                TempData["Message"] = "İşlem Başarıyla Gerçekleşti";
                return RedirectToAction("Index");
            }
                ViewBag.Fail = "alert alert-danger";
                TempData["Message2"] = "İşlem Gerçekleştirilmedi, Kontrol Ediniz";
                return View(dto);

        }
        public async Task<IActionResult> CommentListByBlog(int id)
        {
            ViewBag.blogid = id;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7149/api/Comments/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var comments = JsonConvert.DeserializeObject<List<CommentListDto>>(jsonData);
                return View(comments);
            }
            return View();
        }
    }
}
