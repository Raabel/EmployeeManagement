using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EmployeeManagement.Models.ViewModels;
using EmployeeManagement.Repositories;

namespace EmployeeManagement.Controllers
{
    public class AccountController : Controller
    {
        EmployeeRepository employeeRepo = new EmployeeRepository();
        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(VmLogin model)
        {
            var employees = employeeRepo.GetEmployees();
            if (ModelState.IsValid)
            {
                // Check if the username and password match your authentication logic

                // We can also save password as encrypted to enhance the app security
                // for this demo app we will use password without any encryption
                if (employees.Any(x => x.EmployeeName == model.Username && x.EmployeePassword == model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);

                    // Successful login, redirect to home page or any desired page
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }

            // If ModelState is not valid, return the view with validation errors
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

    }
}