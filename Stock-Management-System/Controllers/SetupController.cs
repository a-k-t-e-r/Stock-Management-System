using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stock_Management_System.Context;
using Stock_Management_System.Models;

namespace Stock_Management_System.Controllers
{
	public class SetupController : Controller
	{
		private readonly ProjectDatabaseContext _setupContext;

		public SetupController()
		{
			_setupContext = new ProjectDatabaseContext();
		}

		public ActionResult SaveCategory()
		{
			ViewBag.categories = _setupContext.Categories.ToList();

			return View();
		}

		[HttpPost]
		public ActionResult SaveCategory(Category category)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("SaveCategory", "Setup");
			}

			_setupContext.Categories.Add(category);
			_setupContext.SaveChanges();

			return RedirectToAction("SaveCategory", "Setup");
		}

		public ActionResult SaveCompany()
		{
			ViewBag.companies = _setupContext.Companies.ToList();

			return View();
		}

		[HttpPost]
		public ActionResult SaveCompany(Company company)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("SaveCompany", "Setup");
			}

			_setupContext.Companies.Add(company);
			_setupContext.SaveChanges();

			return RedirectToAction("SaveCompany", "Setup");
		}

		public ActionResult SaveItem()
		{
			ViewBag.categories = _setupContext.Categories.ToList();
			ViewBag.companies = _setupContext.Companies.ToList();
		    ViewBag.numOfItems = _setupContext.Items.Count();

			return View();
		}

		[HttpPost]
		public ActionResult SaveItem(Item item)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("SaveItem", "Setup");
			}

			_setupContext.Items.Add(item);
			_setupContext.SaveChanges();

			return RedirectToAction("SaveItem", "Setup");
		}

		public ActionResult DeleteAllItems()
		{
			var allItems = _setupContext.Items.ToList();
			_setupContext.Items.RemoveRange(allItems);
			_setupContext.SaveChanges();

			return RedirectToAction("SaveItem", "Setup");
		}

		protected override void Dispose(bool disposing)
		{
			_setupContext.Dispose();
		}
	}
}