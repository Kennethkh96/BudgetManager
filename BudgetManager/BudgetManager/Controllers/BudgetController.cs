using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetManager.Models;
using BudgetManager.Database.interfaces;
using BudgetManager.Database;
using System.Net;

namespace BudgetManager.Controllers
{
    public class BudgetController : Controller
    {
        private IDbContext db = new Db();

        [HttpGet]
        public ActionResult Index()
        {
            if (TempData["Message"] != null)
                ViewBag.Message = TempData["Message"];
            return View();
        }

        [HttpGet]
        public ActionResult Create(string msg)
        {
            try
            {
                ViewBag.Intervals = db.GetIntervals();
                ViewBag.Visibiltys = db.GetVisibiltys();
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "something went horribly wrong on our side, sorry for the inconvenience");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Create(Budget bud)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.CreateBudget(bud);
                    TempData["Message"] = "Budget was successfully created";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "something went horribly wrong on our side, sorry for the inconvenience");
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "bad request, missing values");
            }
                
        }
    }
}