using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CascadingDropDownApp.Interface;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Controllers
{
    public class DistrictController : Controller
    {
        private readonly IDistrict _iDistrict;
        private readonly IDivision _iDivision;

        public DistrictController(IDistrict iDistrict, IDivision iDivision)
        {
            _iDistrict = iDistrict;
            _iDivision = iDivision;
        }


        public ActionResult ViewDistrict()
        {
            return View(_iDistrict.GetDistrictList());
        }

        [HttpGet]
        public ActionResult AddDistrict()
        {
            ViewBag.Division = _iDivision.GetDivisionList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDistrict(District district)
        {
            if (ModelState.IsValid)
            {
                _iDistrict.SaveDistrict(district);
                return RedirectToAction("ViewDistrict");
            }
            return View(district);
        }

        [HttpPost]
        public JsonResult IsDistrictCodeExists(string districtcode)
        {
            try
            {

                var distCode = _iDistrict.CheckDistrictCodeExists(districtcode);
                return Json(distCode, JsonRequestBehavior.AllowGet);


            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public JsonResult IsDistrictNameExists(string districtname)
        {
            try
            {

                var distName = _iDistrict.CheckDistrictNameExists(districtname);
                return Json(distName, JsonRequestBehavior.AllowGet);


            }
            catch (Exception)
            {
                throw;
            }
        }
       
    }
}