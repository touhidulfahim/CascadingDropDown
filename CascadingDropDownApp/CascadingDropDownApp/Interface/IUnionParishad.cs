using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Interface
{
    public interface IUnionParishad:IDisposable
    {
        List<UnionParishad> GetUnionParishadList();
        int? SaveUnionParishad(UnionParishad unionParishad);
        bool CheckUnionParishadCodeExist(string unionparishadcode);
        bool CheckUnionParishadNameExist(string unionparishadname);
    }
}
