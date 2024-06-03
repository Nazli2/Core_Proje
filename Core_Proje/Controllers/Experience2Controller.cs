using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Proje.Controllers
{
	[AllowAnonymous]
    [Authorize(Roles = "Admin")]
    public class Experience2Controller : Controller
	{
		ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult ListExperience()
		{
			var values = JsonConvert.SerializeObject(experienceManager.TGetList());
			return Json(values);
		}
		[HttpPost]
		public IActionResult AddExperience(Experience p)
		{
			experienceManager.TAdd(p);
			var values = JsonConvert.SerializeObject(p);
			return Json(values);
		}
		public IActionResult GetById(int ExperienceID)
		{
			var v = experienceManager.TGetByID(ExperienceID);
			var values = JsonConvert.SerializeObject(v);
			return Json(values);
		}
		public IActionResult DeleteExperience(int id)
		{
			var v = experienceManager.TGetByID(id);
			experienceManager.TDelete(v);
			return NoContent();
		}
		public IActionResult UpdateExperience(Experience p)
		{
			var v = experienceManager.TGetByID(p.ExperienceID);
			//experienceManager.TUpdate(v);
			experienceManager.TUpdate(p);
			var values = JsonConvert.SerializeObject(p);
			return Json(values);
		}
	}
}
