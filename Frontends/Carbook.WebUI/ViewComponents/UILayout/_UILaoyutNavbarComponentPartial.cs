using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.ViewComponents.UILayout
{
    public class _UILaoyutNavbarComponentPartial:ViewComponent
    { 
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
