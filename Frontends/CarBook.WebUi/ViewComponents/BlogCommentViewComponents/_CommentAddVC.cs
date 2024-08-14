using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUi.ViewComponents.BlogCommentViewComponents;

public class _CommentAddVC:ViewComponent
{
    public IViewComponentResult Invoke()
    { return View(); }
}
