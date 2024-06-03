using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Core_Proje.ViewComponents.Portfolio
{
	public class PortfolioList : ViewComponent
	{
		PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
		public IViewComponentResult Invoke()
		{
			var values = portfolioManager.TGetList();
			return View(values);
		}
	}
}
