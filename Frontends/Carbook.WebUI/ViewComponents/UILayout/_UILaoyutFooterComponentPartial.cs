using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.ViewComponents.UILayout
{
    public class _UILaoyutFooterComponentPartial:ViewComponent
    { 
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
