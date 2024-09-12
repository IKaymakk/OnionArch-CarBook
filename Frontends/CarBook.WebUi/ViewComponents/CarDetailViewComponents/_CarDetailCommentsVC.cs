using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUi.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCommentsVC:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
