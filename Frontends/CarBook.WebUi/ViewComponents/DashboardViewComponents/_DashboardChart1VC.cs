using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUi.ViewComponents.DashboardViewComponents
{
    public class _DashboardChart1VC : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
