using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUi.ViewComponents.UILayoutViewComponents;

    public class _UILayoutFooterVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
