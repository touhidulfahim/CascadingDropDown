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
    public class UnionParishadRepository:IUnionParishad
    {
        private readonly CascadingDbContext _context;
        private bool _disposed = false;

        public UnionParishadRepository(CascadingDbContext context)
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

        public List<UnionParishad> GetUnionParishadList()
        {
            try
            {
                return _context.UnionParishads.Include(u => u.Upazila).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int? SaveUnionParishad(UnionParishad unionParishad)
        {
            int result = -1;
            if (unionParishad != null)
            {
                _context.UnionParishads.Add(unionParishad);
                _context.SaveChanges();
                result=unionParishad.UnionParishadId;
            }
            return result;
        }

        public bool CheckUnionParishadCodeExist(string unionparishadcode)
        {
            var upCode = !_context.UnionParishads.Any(u => u.UnionParishadCode == unionparishadcode);
            return upCode;
        }

        public bool CheckUnionParishadNameExist(string unionparishadname)
        {
            var upName = !_context.UnionParishads.Any(u => u.UnionParishadName == unionparishadname);
            return upName;
        }
    }
}