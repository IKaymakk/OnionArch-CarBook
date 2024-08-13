using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUi.ViewComponents.DefaultViewComponents;

public class _DefaultStatsVC:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
