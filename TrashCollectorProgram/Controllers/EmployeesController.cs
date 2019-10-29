using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollectorProgram.Models;

namespace TrashCollectorProgram.Controllers
{
    //Making employes private only to employees
    //[Authorize(Roles = "Customer")]
    
    public class EmployeesController : Controller
    {
        ApplicationDbContext context;
        public EmployeesController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Employees
        public ActionResult Index()
        {
            return View(context.Employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            Employee employee = context.Employees.Where(e => e.Id == id).FirstOrDefault();
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                string id = User.Identity.GetUserId();                
                employee.ApplicationId = id;
                context.Employees.Add(employee);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = context.Employees.Where(e => e.Id == id).FirstOrDefault();
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                // TODO: Add update logic here
                Employee employeeToEdit = context.Employees.Where(e => e.Id == id).FirstOrDefault();
                employeeToEdit.Id = employee.Id;
                employeeToEdit.zipcode = employee.zipcode;
                context.SaveChanges();



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            Employee employee = context.Employees.Where(e => e.Id == id).FirstOrDefault();
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                // TODO: Add delete logic here
                Employee employeeToDelete = context.Employees.Where(e => e.Id == id).FirstOrDefault();
                context.Employees.Remove(employeeToDelete);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
