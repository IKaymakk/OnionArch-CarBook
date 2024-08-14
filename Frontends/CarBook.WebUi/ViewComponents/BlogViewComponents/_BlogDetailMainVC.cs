using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUi.ViewComponents.BlogViewComponents
{
    public class _BlogDetailMainVC:ViewComponent
    {
        public IViewComponentResult Invoke()
        { return View(); }
    }
}
