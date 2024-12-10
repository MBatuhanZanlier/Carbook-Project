using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.ViewComponents._AdminLayout
{
    public class _AdminLayoutFooterComponentPartial:ViewComponent
    { 
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
