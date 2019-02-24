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
    public class UpazilaRepository : IUpazila
    {
        private readonly CascadingDbContext _context;
        private bool _disposed = false;

        public UpazilaRepository(CascadingDbContext context)
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

        public List<Upazila> GetUpazilaList()
        {
            try
            {
                var upzilaList = _context.Upazilas.Include(u => u.District).ToList();
                return upzilaList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int? SaveUpazila(Upazila upazila)
        {
            try
            {
                int result = -1;
                if (upazila != null)
                {
                    _context.Upazilas.Add(upazila);
                    _context.SaveChanges();
                    result = upazila.UpazilaId;
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckUpazilaCodeExists(string upazilacode)
        {
            try
            {
                var upCode = !_context.Upazilas.Any(u => u.UpazilaCode == upazilacode);
                return upCode;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckUpazilaNameExists(string upazilaname)
        {
            try
            {
                var upName = !_context.Upazilas.Any(u => u.UpazilaName == upazilaname);
                return upName;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}