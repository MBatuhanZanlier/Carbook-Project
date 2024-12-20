using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.ViewComponents._Comment
{
    public class _CommentAddByBlogComponentPartial:ViewComponent
    { 
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.blogid = id; 
            return View(); 
        
        }
    }
}
