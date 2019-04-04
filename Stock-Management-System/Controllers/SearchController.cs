using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stock_Management_System.Context;
using Stock_Management_System.Models;

namespace Stock_Management_System.Controllers
{
    public class SearchController : Controller
    {
        private readonly ProjectDatabaseContext _searchContext;

        public SearchController()
        {
            _searchContext = new ProjectDatabaseContext();
        }

        public ActionResult ViewItemSummary()
        {
            ViewBag.companies = _searchContext.Companies.ToList();
            ViewBag.categories = _searchContext.Categories.ToList();

            return View();
        }

        public JsonResult GetSelectedStock(int id)
        {
            List<StockIn> stockIns = _searchContext.StockIns.Where(s => s.CompanyId == id).ToList();

            return Json(stockIns, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSelectedItem(int id)
        {
            Item item = _searchContext.Items.SingleOrDefault(itm => itm.Id == id);

            return Json(item, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSelectedCompany(int id)
        {
            Company company = _searchContext.Companies.SingleOrDefault(com => com.Id == id);

            return Json(company, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSelectedCategory(int id)
        {
            Category category = _searchContext.Categories.SingleOrDefault(cat => cat.Id == id);

            return Json(category, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewSalesBetweenTwoDates()
        {
            return View();
        }

        public JsonResult GetStockOutLists()
        {
            List<StockOut> stockOuts = _searchContext.StockOuts.ToList();

            return Json(stockOuts, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            _searchContext.Dispose();
        }
    }
}