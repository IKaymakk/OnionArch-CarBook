using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUi.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutMainCoverVC:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
