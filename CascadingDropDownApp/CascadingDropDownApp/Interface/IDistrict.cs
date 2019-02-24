using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Interface
{
    public interface IDistrict:IDisposable
    {
        List<District> GetDistrictList();
        int? SaveDistrict(District district);
        bool CheckDistrictNameExists(string districtname);
        bool CheckDistrictCodeExists(string districtcode);
    }
}
