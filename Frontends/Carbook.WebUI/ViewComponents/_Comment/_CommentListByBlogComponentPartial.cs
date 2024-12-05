using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.ViewComponents._Comment
{
    public class _CommentListByBlogComponentPartial:ViewComponent
    { 
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
