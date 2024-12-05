using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.ViewComponents.UILayout
{
    public class _UILaoyutHeadComponentPartial:ViewComponent
    { 
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
