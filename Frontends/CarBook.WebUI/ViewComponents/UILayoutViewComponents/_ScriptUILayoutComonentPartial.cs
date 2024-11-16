using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _ScriptUILayoutComonentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
