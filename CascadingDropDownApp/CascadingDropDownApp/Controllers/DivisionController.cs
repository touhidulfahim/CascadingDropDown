using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CascadingDropDownApp.Interface;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Controllers
{
    public class DivisionController : Controller
    {
        private readonly IDivision _iDivision;
        private readonly ICountry _iCountry;

        public DivisionController(IDivision iDivision, ICountry iCountry)
        {
            _iDivision = iDivision;
            _iCountry = iCountry;
        }

        public ActionResult ShowDivision()
        {
            var divisionList = _iDivision.GetDivisionList();
            return View(divisionList);
        }

        [HttpGet]
        public ActionResult AddDivision()
        {
            ViewBag.Country = _iCountry.GetCountry();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDivision(Division division)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _iDivision.SaveDivision(division);
                }
                return RedirectToAction("ShowDivision");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public JsonResult IsDivisionCodeExists(string divisioncode)
        {
            try
            {

                var divCode = _iDivision.CheckDivisionCodeExists(divisioncode);
                return Json(divCode, JsonRequestBehavior.AllowGet);


            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public JsonResult IsDivisionNameExists(string divisionname)
        {
            try
            {
                var divName = _iDivision.CheckDivisionNameExists(divisionname);
                return Json(divName, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}