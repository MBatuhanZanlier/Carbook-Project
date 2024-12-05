using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.ViewComponents.UILayout
{
    public class _UILaoyutScriptComponentPartial:ViewComponent
    { 
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
