using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CascadingDropDownApp.DTO;
using CascadingDropDownApp.Gateway;
using CascadingDropDownApp.Interface;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Repository
{
    public class DepartmentRepository:IDepartment
    {
        private readonly CascadingDbContext _context;

        public DepartmentRepository(CascadingDbContext context)
        {
            _context = context;
        }

        public int SaveDepartment(DepartmentDTO department)
        {
            try
            {
                int result = -1;

                if (department !=null)
                {
                    var departments = AutoMapper.Mapper.Map<DepartmentModels>(department);
                    _context.Departments.Add(departments);
                    _context.SaveChanges();
                    result=departments.DepartmentId;
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public List<DepartmentDTO> GetAllDepartments()
        {
            try
            {
                List<DepartmentModels> depts = _context.Departments.ToList();
                List<DepartmentDTO> departments = AutoMapper.Mapper.Map<List<DepartmentModels>, List<DepartmentDTO>>(depts);
                return departments;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DepartmentDTO GetDepartmentById(int? id)
        {
            try
            {
                DepartmentModels department = _context.Departments.Find(id);
                DepartmentDTO deptDTO = AutoMapper.Mapper.Map<DepartmentModels, DepartmentDTO>(department);
                return deptDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int? UpdateDepartments(DepartmentDTO deptDto)
        {
            try
            {
                int? result = -1;
                if (deptDto != null)
                {
                    var departments = AutoMapper.Mapper.Map<DepartmentModels>(deptDto);
                    _context.Entry(departments).State = EntityState.Modified;
                    _context.SaveChanges();
                    result = departments.DepartmentId;
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}