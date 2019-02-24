using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CascadingDropDownApp.Interface;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Controllers
{
    public class UpazilaController : Controller
    {
        private readonly IUpazila _iUpazila;
        private readonly IDistrict _iDistrict;

        public UpazilaController(IUpazila iUpazila, IDistrict iDistrict)
        {
            _iUpazila = iUpazila;
            _iDistrict = iDistrict;
        }

        public ActionResult ViewUpazila()
        {
            return View(_iUpazila.GetUpazilaList());
        }

        [HttpGet]
        public ActionResult AddUpazila()
        {
            ViewBag.District = _iDistrict.GetDistrictList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUpazila(Upazila upazila)
        {
            if (ModelState.IsValid)
            {
                _iUpazila.SaveUpazila(upazila);
                return RedirectToAction("ViewUpazila");
            }
            return View();
        }

        [HttpPost]
        public JsonResult IsUpazilaCodeExists(string upazilacode)
        {
            var upCode = _iUpazila.CheckUpazilaCodeExists(upazilacode);
            return Json(upCode, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult IsUpazilaNameExists(string upazilaname)
        {
            var upName = _iUpazila.CheckUpazilaNameExists(upazilaname);
            return Json(upName, JsonRequestBehavior.AllowGet);
        }
    }
}