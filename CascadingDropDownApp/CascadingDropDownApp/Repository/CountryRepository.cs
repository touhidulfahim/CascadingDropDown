using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CascadingDropDownApp.Gateway;
using CascadingDropDownApp.Interface;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Repository
{
    public class CountryRepository:ICountry
    {
        private readonly CascadingDbContext _context;
        private bool _disposed = false;

        public CountryRepository(CascadingDbContext context)
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

        public List<Country> GetCountry()
        {
            try
            {
                return _context.Countries.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}