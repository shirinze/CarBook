using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailDescriptionComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke(int id)
		{
			ViewBag.carid = id;
			return View();
		}
	}
}
