using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using CascadingDropDownApp.Gateway;
using CascadingDropDownApp.Interface;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Controllers
{
    public class CustomerAddressController : Controller
    {
        private CascadingDbContext db = new CascadingDbContext();
        private readonly ICustomerAddress _iCustomerAddress;
        private readonly ICountry _iCountry;
        private readonly IDivision _iDivision;
        private readonly IDistrict _iDistrict;
        private readonly IUpazila _iUpazila;
        private readonly IUnionParishad _iUnionParishad;

        public CustomerAddressController(ICustomerAddress iCustomerAddress, ICountry iCountry, IDivision iDivision, IDistrict iDistrict, IUpazila iUpazila, IUnionParishad iUnionParishad)
        {
            _iCustomerAddress = iCustomerAddress;
            _iCountry = iCountry;
            _iDivision = iDivision;
            _iDistrict = iDistrict;
            _iUpazila = iUpazila;
            _iUnionParishad = iUnionParishad;
        }
        
        public ActionResult Index()
        {
            var customerAddresses = _iCustomerAddress.GetAllCustomerAddress();
            return View(customerAddresses.ToList());
        }
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            CustomerAddressModels customerAddressModels = db.CustomerAddresses.Find(id);
//            if (customerAddressModels == null)
//            {
//                return HttpNotFound();
//            }
//            return View(customerAddressModels);
//        }

        // GET: CustomerAddress/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            ViewBag.PermanentCountryId = _iCountry.GetCountry();
            ViewBag.PermanentDistrictId = _iDistrict.GetDistrictList();
            ViewBag.PermanentDivisionId = _iDivision.GetDivisionList();
            ViewBag.PermanentUnionParishadId = _iUnionParishad.GetUnionParishadList();
            ViewBag.PermanentUpazillaId = _iUpazila.GetUpazilaList();
            ViewBag.PresentCountryId = _iCountry.GetCountry();
            ViewBag.PresentDistrictId = _iDistrict.GetDistrictList();
            ViewBag.PresentDivisionId = _iDivision.GetDivisionList();
            ViewBag.PresentUnionParishadId = _iUnionParishad.GetUnionParishadList();
            ViewBag.PresentUpazilaId = _iUpazila.GetUpazilaList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerAddressId,CustomerId,PresentCountryId,PresentDivisionId,PresentDistrictId,PresentUpazilaId,PresentUnionParishadId,PresentHome,PresentRoadNo,PresentVillage,PermanentCountryId,PermanentDivisionId,PermanentDistrictId,PermanentUpazillaId,PermanentUnionParishadId,PermanentHome,PermanentRoadNo,PermanentVillage")] CustomerAddressModels customerAddressModels)
        {
            if (ModelState.IsValid)
            {
                db.CustomerAddresses.Add(customerAddressModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", customerAddressModels.CustomerId);
            ViewBag.PermanentCountryId = new SelectList(db.Countries, "CountryId", "CountryCode", customerAddressModels.PermanentCountryId);
            ViewBag.PermanentDistrictId = new SelectList(db.Districts, "DistrictId", "DistrictCode", customerAddressModels.PermanentDistrictId);
            ViewBag.PermanentDivisionId = new SelectList(db.Divisions, "DivisionId", "DivisionCode", customerAddressModels.PermanentDivisionId);
            ViewBag.PermanentUnionParishadId = new SelectList(db.UnionParishads, "UnionParishadId", "UnionParishadCode", customerAddressModels.PermanentUnionParishadId);
            ViewBag.PermanentUpazillaId = new SelectList(db.Upazilas, "UpazilaId", "UpazilaCode", customerAddressModels.PermanentUpazillaId);
            ViewBag.PresentCountryId = new SelectList(db.Countries, "CountryId", "CountryCode", customerAddressModels.PresentCountryId);
            ViewBag.PresentDistrictId = new SelectList(db.Districts, "DistrictId", "DistrictCode", customerAddressModels.PresentDistrictId);
            ViewBag.PresentDivisionId = new SelectList(db.Divisions, "DivisionId", "DivisionCode", customerAddressModels.PresentDivisionId);
            ViewBag.PresentUnionParishadId = new SelectList(db.UnionParishads, "UnionParishadId", "UnionParishadCode", customerAddressModels.PresentUnionParishadId);
            ViewBag.PresentUpazilaId = new SelectList(db.Upazilas, "UpazilaId", "UpazilaCode", customerAddressModels.PresentUpazilaId);
            return View(customerAddressModels);
        }

        // GET: CustomerAddress/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerAddressModels customerAddressModels = db.CustomerAddresses.Find(id);
            if (customerAddressModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.PermanentCountryId = new SelectList(db.Countries, "CountryId", "CountryCode", customerAddressModels.PermanentCountryId);
            ViewBag.PermanentDistrictId = new SelectList(db.Districts, "DistrictId", "DistrictCode", customerAddressModels.PermanentDistrictId);
            ViewBag.PermanentDivisionId = new SelectList(db.Divisions, "DivisionId", "DivisionCode", customerAddressModels.PermanentDivisionId);
            ViewBag.PermanentUnionParishadId = new SelectList(db.UnionParishads, "UnionParishadId", "UnionParishadCode", customerAddressModels.PermanentUnionParishadId);
            ViewBag.PermanentUpazillaId = new SelectList(db.Upazilas, "UpazilaId", "UpazilaCode", customerAddressModels.PermanentUpazillaId);
            ViewBag.PresentCountryId = new SelectList(db.Countries, "CountryId", "CountryCode", customerAddressModels.PresentCountryId);
            ViewBag.PresentDistrictId = new SelectList(db.Districts, "DistrictId", "DistrictCode", customerAddressModels.PresentDistrictId);
            ViewBag.PresentDivisionId = new SelectList(db.Divisions, "DivisionId", "DivisionCode", customerAddressModels.PresentDivisionId);
            ViewBag.PresentUnionParishadId = new SelectList(db.UnionParishads, "UnionParishadId", "UnionParishadCode", customerAddressModels.PresentUnionParishadId);
            ViewBag.PresentUpazilaId = new SelectList(db.Upazilas, "UpazilaId", "UpazilaCode", customerAddressModels.PresentUpazilaId);
            return View(customerAddressModels);
        }

        // POST: CustomerAddress/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerAddressId,CustomerId,PresentCountryId,PresentDivisionId,PresentDistrictId,PresentUpazilaId,PresentUnionParishadId,PresentHome,PresentRoadNo,PresentVillage,PermanentCountryId,PermanentDivisionId,PermanentDistrictId,PermanentUpazillaId,PermanentUnionParishadId,PermanentHome,PermanentRoadNo,PermanentVillage")] CustomerAddressModels customerAddressModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerAddressModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PermanentCountryId = new SelectList(db.Countries, "CountryId", "CountryCode", customerAddressModels.PermanentCountryId);
            ViewBag.PermanentDistrictId = new SelectList(db.Districts, "DistrictId", "DistrictCode", customerAddressModels.PermanentDistrictId);
            ViewBag.PermanentDivisionId = new SelectList(db.Divisions, "DivisionId", "DivisionCode", customerAddressModels.PermanentDivisionId);
            ViewBag.PermanentUnionParishadId = new SelectList(db.UnionParishads, "UnionParishadId", "UnionParishadCode", customerAddressModels.PermanentUnionParishadId);
            ViewBag.PermanentUpazillaId = new SelectList(db.Upazilas, "UpazilaId", "UpazilaCode", customerAddressModels.PermanentUpazillaId);
            ViewBag.PresentCountryId = new SelectList(db.Countries, "CountryId", "CountryCode", customerAddressModels.PresentCountryId);
            ViewBag.PresentDistrictId = new SelectList(db.Districts, "DistrictId", "DistrictCode", customerAddressModels.PresentDistrictId);
            ViewBag.PresentDivisionId = new SelectList(db.Divisions, "DivisionId", "DivisionCode", customerAddressModels.PresentDivisionId);
            ViewBag.PresentUnionParishadId = new SelectList(db.UnionParishads, "UnionParishadId", "UnionParishadCode", customerAddressModels.PresentUnionParishadId);
            ViewBag.PresentUpazilaId = new SelectList(db.Upazilas, "UpazilaId", "UpazilaCode", customerAddressModels.PresentUpazilaId);
            return View(customerAddressModels);
        }

        // GET: CustomerAddress/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerAddressModels customerAddressModels = db.CustomerAddresses.Find(id);
            if (customerAddressModels == null)
            {
                return HttpNotFound();
            }
            return View(customerAddressModels);
        }

        // POST: CustomerAddress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerAddressModels customerAddressModels = db.CustomerAddresses.Find(id);
            db.CustomerAddresses.Remove(customerAddressModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public JsonResult GetPresentDivisionByCountryId(int countryId)

        {
            var division = _iCustomerAddress.GetDivisionByCountryId(countryId);
            return Json(division, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetPermanentDivisionByCountryId(int countryId)

        {
            var division = _iCustomerAddress.GetDivisionByCountryId(countryId);
            return Json(division, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetPresentDistrictByDivisionId(int divisionId)
        {
            var district = _iCustomerAddress.GetDistrictByDivisionId(divisionId);
            return Json(district, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetPermanentDistrictByDivisionId(int divisionId)
        {
            var district = _iCustomerAddress.GetDistrictByDivisionId(divisionId);
            return Json(district, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetPresentUpzillaByDistrictId(int districtId)
        {
            var upazila = _iCustomerAddress.GetUpzillaByDistrictId(districtId);
            return Json(upazila, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetPermanentUpzillaByDistrictId(int districtId)
        {
            var upazila = _iCustomerAddress.GetUpzillaByDistrictId(districtId);
            return Json(upazila, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetPresentUnionByUpazillaId(int upazilaId)
        {
            var unionParisad = _iCustomerAddress.GetUnionByUpazillaId(upazilaId);
            return Json(unionParisad, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetPermanentUnionByUpazillaId(int upazilaId)
        {
            var unionParisad = _iCustomerAddress.GetUnionByUpazillaId(upazilaId);
            return Json(unionParisad, JsonRequestBehavior.AllowGet);
        }

    }
}
