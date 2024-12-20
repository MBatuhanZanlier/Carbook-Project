using Microsoft.AspNetCore.Mvc;

namespace Carbook.WebUI.ViewComponents._CarDetail
{
	public class _CarDetailTabPaneComponentPartial:ViewComponent
	{
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
