using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using CascadingDropDownApp.Interface;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Controllers
{
    public class UnionParishadController : Controller
    {
        private readonly IUnionParishad _iUnionParishad;
        private readonly IUpazila _iUpazila;

        public UnionParishadController(IUnionParishad iUnionParishad, IUpazila iUpazila)
        {
            _iUnionParishad = iUnionParishad;
            _iUpazila = iUpazila;
        }

        public ActionResult ViewUnionParishad()
        {
            return View(_iUnionParishad.GetUnionParishadList());
        }
        [HttpGet]
        public ActionResult AddUnionParishad()
        {
            ViewBag.Upazila = _iUpazila.GetUpazilaList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUnionParishad(UnionParishad unionParishad)
        {
            if (ModelState.IsValid)
            {
                _iUnionParishad.SaveUnionParishad(unionParishad);
                return RedirectToAction("ViewUnionParishad");
            }
            return View();
        }

        [HttpPost]
        public JsonResult IsUnionCodeExists(string unionparishadcode)
        {
            var upCode = _iUnionParishad.CheckUnionParishadCodeExist(unionparishadcode);
            return Json(upCode, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult IsUnionNameExists(string unionparishadname)
        {
            var upName = _iUnionParishad.CheckUnionParishadNameExist(unionparishadname);
            return Json(upName, JsonRequestBehavior.AllowGet);
        }
    }
}