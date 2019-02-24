using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CascadingDropDownApp.Gateway;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Interface
{
    public interface IUpazila:IDisposable
    {
        List<Upazila> GetUpazilaList();
        int? SaveUpazila(Upazila upazila);
        bool CheckUpazilaCodeExists(string upazilacode);
        bool CheckUpazilaNameExists(string upazilaname);
    }
}
