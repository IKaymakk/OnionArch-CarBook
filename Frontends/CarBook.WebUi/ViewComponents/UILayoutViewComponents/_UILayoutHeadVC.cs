using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUi.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutHeadVC:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
