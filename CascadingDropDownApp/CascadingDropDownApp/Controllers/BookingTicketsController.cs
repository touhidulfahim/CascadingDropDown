using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CascadingDropDownApp.Gateway;
using CascadingDropDownApp.Interface;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Controllers
{
    public class BookingTicketsController : Controller
    {
        private readonly CascadingDbContext _db;
        private readonly IDistrict _iDistrict;

        public BookingTicketsController(CascadingDbContext db, IDistrict iDistrict)
        {
            _db = db;
            _iDistrict = iDistrict;
        }

        public ActionResult Index()
        {
            //var bookingTickets = _db.BookingTickets.Include(b => b.DistrictFrom).Include(b => b.DistrictTo);
            return View(); //bookingTickets.ToList());
        }

        public JsonResult GetDistrictDetailsByDistrictId(int districtId)
        {
            var districtDetails = _iDistrict.GetDistrictInfosByDistrictId(districtId);
            var result = (from s in districtDetails
                          select new
                          {
                              code = s.DistrictCode,
                              city = s.Division.DivisionName,
                              country = s.Division.Country.CountryName
                          }).FirstOrDefault();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            ViewBag.TransferFrom = _iDistrict.GetAllDhkDistrict();
            ViewBag.TransferTo = _iDistrict.GetAllCtgDistrict();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookingTicket bookingTicket)
        {
            if (ModelState.IsValid)
            {
                bookingTicket.BookingDate = DateTime.Now;
               // _db.BookingTickets.Add(bookingTicket);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookingTicket);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
