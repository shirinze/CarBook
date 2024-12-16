using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.RentACarFilterViewComponents
{
    public class _RentACarFilterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
          
            return View();
        }
    }
}
