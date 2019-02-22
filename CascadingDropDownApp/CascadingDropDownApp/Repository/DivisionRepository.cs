using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc.Html;
using CascadingDropDownApp.Gateway;
using CascadingDropDownApp.Interface;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Repository
{
    public class DivisionRepository : IDivision
    {
        private readonly CascadingDbContext _context;
        private bool _disposed = false;

        public DivisionRepository(CascadingDbContext context)
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


        public List<Division> GetDivisionList()
        {
            try
            {
                return _context.Divisions.Include(d => d.Country).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int? SaveDivision(Division division)
        {
            try
            {
                int result = -1;
                if (division != null)
                {
                    _context.Divisions.Add(division);
                    _context.SaveChanges();
                    result = division.DivisionId;
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool CheckDivisionCodeExists(string divisioncode)
        {
            try
            {
                var divCode = !_context.Divisions.Any(d => d.DivisionCode == divisioncode);
                return divCode;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckDivisionNameExists(string divisionname)
        {
            try
            {
                var divName = !_context.Divisions.Any(d=>d.DivisionName==divisionname);
                return divName;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}