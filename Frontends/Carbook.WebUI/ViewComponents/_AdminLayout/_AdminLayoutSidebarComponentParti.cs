using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.ViewComponents._AdminLayout
{
    public class _AdminLayoutSidebarComponentPartial:ViewComponent
    { 
        public IViewComponentResult Invoke()
        { return View(); }  
    }
}
