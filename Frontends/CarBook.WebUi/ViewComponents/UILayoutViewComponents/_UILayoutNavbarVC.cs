using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUi.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutNavbarVC:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
