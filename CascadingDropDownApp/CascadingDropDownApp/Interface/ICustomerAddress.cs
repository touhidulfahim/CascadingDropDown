using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Interface
{
    public interface ICustomerAddress:IDisposable
    {
        List<CustomerAddressModels> GetAllCustomerAddress();
        List<Division> GetDivisionByCountryId(int countryId);
        List<District> GetDistrictByDivisionId(int divisionId);
        List<Upazila> GetUpzillaByDistrictId(int districtId);
        List<UnionParishad> GetUnionByUpazillaId(int upazilaId);
    }
}