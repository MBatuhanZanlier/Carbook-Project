using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.ViewComponents._About
{
    public class _AboutBecomeADriverComponentPartial:ViewComponent
    { 
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
