using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.ViewComponents._Default
{
    public class _DefaultStatisticComponentPartial:ViewComponent
    { 
        public IViewComponentResult Invoke()
        { return View(); }
    }
}
