using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.ViewComponents.UILayout
{
    public class _UILaoyutMainCoverComponentPartial:ViewComponent
    { 
        public IViewComponentResult Invoke()
        { return View(); }
    }
}
