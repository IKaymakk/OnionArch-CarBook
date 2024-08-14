using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUi.ViewComponents.BlogCommentViewComponents;

public class _CommentListByBlogVC:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
