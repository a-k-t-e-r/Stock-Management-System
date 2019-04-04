using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stock_Management_System.Context;
using Stock_Management_System.Models;

namespace Stock_Management_System.Controllers
{
	public class StockController : Controller
	{
		private readonly ProjectDatabaseContext _stockContext;

		public StockController()
		{
			_stockContext = new ProjectDatabaseContext();
		}

		public ActionResult SaveStockIn()
		{
			ViewBag.companies = _stockContext.Companies.ToList();
			ViewBag.items = _stockContext.Items.ToList();

			return View();
		}

		[HttpPost]
		public ActionResult SaveStockIn(StockIn stockIn)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("SaveStockIn", "Stock");
			}

			_stockContext.StockIns.Add(stockIn);
			_stockContext.SaveChanges();

			return RedirectToAction("SaveStockIn", "Stock");
		}

		public JsonResult GetSelectedItems()
		{
			List<Item> items = _stockContext.Items.ToList();

			return Json(items, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetAllStockIn()
		{
			List<StockIn> stockIns = _stockContext.StockIns.ToList();

			return Json(stockIns, JsonRequestBehavior.AllowGet);
		}

		public ActionResult SaveStockOut()
		{
			ViewBag.companies = _stockContext.Companies.ToList();
			ViewBag.items = _stockContext.Items.ToList();

			return View();
		}

		[HttpPost]
        public ActionResult SaveStockOut(StockOut stockOut)
		{
            if (!ModelState.IsValid)
            {
                return RedirectToAction("SaveStockOut", "Stock");
            }

            _stockContext.StockOuts.Add(stockOut);
            _stockContext.SaveChanges();

            return RedirectToAction("SaveStockOut", "Stock");
		}

		public JsonResult GetAllStockOut()
		{
			List<StockOut> stockOuts = _stockContext.StockOuts.ToList();

			return Json(stockOuts, JsonRequestBehavior.AllowGet);
		}

		protected override void Dispose(bool disposing)
		{
			_stockContext.Dispose();
		}
	}
}