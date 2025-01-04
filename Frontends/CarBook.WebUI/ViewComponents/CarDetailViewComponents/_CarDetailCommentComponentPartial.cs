using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailCommentComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke(int id)
		{
			ViewBag.carid = id;
			return View();
		}
	}
}
