using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.ViewComponents._AdminLayout
{
    public class _AdminLayoutNavbarComponentPartial:ViewComponent
    { 
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
