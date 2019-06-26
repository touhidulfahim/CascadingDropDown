using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CascadingDropDownApp.DTO;

namespace CascadingDropDownApp.Interface
{
    public interface IDepartment
    {
        int SaveDepartment(DepartmentDTO department);
        List<DepartmentDTO> GetAllDepartments();
        DepartmentDTO GetDepartmentById(int? id);
        int? UpdateDepartments(DepartmentDTO deptDto);
    }
}
