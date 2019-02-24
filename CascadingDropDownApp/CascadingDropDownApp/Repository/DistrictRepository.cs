using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using CascadingDropDownApp.Gateway;
using CascadingDropDownApp.Interface;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Repository
{
    public class DistrictRepository:IDistrict
    {
        private readonly CascadingDbContext _context;
        private bool _disposed = false;

        public DistrictRepository(CascadingDbContext context)
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

        public List<District> GetDistrictList()
        {
            try
            {
                var divisionList = _context.Districts.Include(d => d.Division);
                return divisionList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int? SaveDistrict(District district)
        {
            try
            {
                int result = -1;
                if (district != null)
                {
                    _context.Districts.Add(district);
                    _context.SaveChanges();
                    result = district.DistrictId;
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckDistrictNameExists(string districtname)
        {
            try
            {
                var disName = !_context.Districts.Any(d => d.DistrictName == districtname);
                return disName;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckDistrictCodeExists(string districtcode)
        {
            try
            {
                var disName = !_context.Districts.Any(d => d.DistrictCode == districtcode);
                return disName;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}