using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje.Controllers
{
    [AllowAnonymous]
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
	{
		MessageManager messageManager = new MessageManager(new EfMessageDal());
		public IActionResult Index()
		{
			var values = messageManager.TGetList();
			return View(values);
		}
		public IActionResult DeleteContact(int id)
		{
            var values = messageManager.TGetByID(id);
            messageManager.TDelete(values);
            return RedirectToAction("Index");
        }
		public IActionResult ContactDetails(int id)
		{
			var values = messageManager.TGetByID(id);
			return View(values);

		}
	}
}
