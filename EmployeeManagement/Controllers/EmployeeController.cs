using EmployeeManagement.Interfaces;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        // Also we can use DI to manage the repository instance.

        private readonly EmployeeRepository _employeeRepository;
        //EmployeeRepository employeeRepo = new EmployeeRepository();

        public EmployeeController()
        {
            _employeeRepository = new EmployeeRepository();

        }

        // GET: Employee
        public ActionResult Index()
        {
            var employees = _employeeRepository.GetEmployees();

            return View(employees);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            // Assuming you have a list of departments (you can retrieve this from the database)
            var departments = new List<string> { "IT", "HR", "Finance", "Sales" };
            var employees = _employeeRepository.GetEmployees();

            // Create a SelectList for the dropdown
            ViewBag.DepartmentList = new SelectList(departments);

            // Return the view
            return View(employees);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            var employees = _employeeRepository.GetEmployees();
            if (ModelState.IsValid)
            {
                // Check if the employeeRepo with the same email already exists
                if (employees.Any(e => e.EmployeeEmail == employee.EmployeeEmail))
                {
                    ModelState.AddModelError("EmployeeEmail", "Employee with this email already exists.");
                }
                else
                {
                    // Save to the database 
                    _employeeRepository.SaveEmployee(employee);

                    return PartialView("_EmployeeList", employees);
                }
            }

            // If ModelState is not valid, return the view with validation errors
            var departments = new List<string> { "IT", "HR", "Finance", "Sales" };
            ViewBag.DepartmentList = new SelectList(departments);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
