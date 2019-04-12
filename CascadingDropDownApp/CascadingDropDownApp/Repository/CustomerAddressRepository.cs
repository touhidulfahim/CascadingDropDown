using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CascadingDropDownApp.Gateway;
using CascadingDropDownApp.Interface;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Repository
{
    public class CustomerAddressRepository:ICustomerAddress
    {
        private readonly CascadingDbContext _context;
        private bool _disposed = false;

        public CustomerAddressRepository(CascadingDbContext context)
        {
            _context = context;
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public List<CustomerAddressModels> GetAllCustomerAddress()
        {
            var customerAddress = _context.CustomerAddresses.Include(c => c.PermanentCountry)
                .Include(c => c.PresentCountry).Include(c=>c.PermanentDivision).Include(c=>c.PresentDivision);
            return customerAddress.ToList();
        }

        public List<Division> GetDivisionByCountryId(int countryId)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            var division = _context.Divisions.Where(p => p.CountryId == countryId).ToList();
            return division;
        }

        public List<District> GetDistrictByDivisionId(int divisionId)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            var dist = _context.Districts.Where(d => d.DivisionId == divisionId).ToList();
            return dist;
        }

        public List<Upazila> GetUpzillaByDistrictId(int districtId)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            var upazila = _context.Upazilas.Where(u => u.DistrictId == districtId).ToList();
            return upazila;
        }

        public List<UnionParishad> GetUnionByUpazillaId(int upazilaId)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            var up = _context.UnionParishads.Where(u => u.UpazilaId == upazilaId).ToList();
            return up;
        }

//        public JsonResult GetDivision(int countryId)
//        {
//            using (EMSDbContext db = new EMSDbContext())
//            {
//                db.Configuration.ProxyCreationEnabled = false;
//                List<Division> divisions = db.Divisions.Where(d => d.CountryId == countryId).ToList();
//                return Json(divisions, JsonRequestBehavior.AllowGet);
//            }
//        }
    }
}