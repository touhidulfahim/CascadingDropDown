using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Interface
{
    public interface ICountry:IDisposable
    {
        List<Country> GetCountry();
    }
}
