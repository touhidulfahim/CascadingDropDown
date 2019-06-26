using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;
using CascadingDropDownApp.DTO;
using CascadingDropDownApp.Interface;

namespace CascadingDropDownApp.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartment _iDepartment;

        public DepartmentController(IDepartment iDepartment)
        {
            _iDepartment = iDepartment;
        }
        // GET: Department

        public ActionResult ViewDepartmentList()
        {
            return View(_iDepartment.GetAllDepartments());
        }


        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDepartment(DepartmentDTO deptDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    deptDto.DateOfEntry = DateTime.Now;
                    deptDto.IsActive = true;
                    _iDepartment.SaveDepartment(deptDto);
                }
                return View(deptDto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ActionResult EditDepartment(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                DepartmentDTO dept = _iDepartment.GetDepartmentById(id);
                if (dept == null)
                {
                    return HttpNotFound();
                }

                return View(dept);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDepartment(DepartmentDTO deptDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _iDepartment.UpdateDepartments(deptDto);
                }
                return View(deptDto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}