using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Interface
{
    public interface IDivision:IDisposable
    {
        List<Division> GetDivisionList();
        int? SaveDivision(Division division);
        bool CheckDivisionCodeExists(string divisioncode);
        bool CheckDivisionNameExists(string divisionname);
    }
}
