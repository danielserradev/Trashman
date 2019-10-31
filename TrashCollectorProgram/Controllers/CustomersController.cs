using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollectorProgram.Models;

namespace TrashCollectorProgram.Controllers
{
    

    public class CustomersController : Controller
    {
        ApplicationDbContext context;
        public CustomersController()
        {
            context = new ApplicationDbContext();
        }
        
        
        // GET: Customers
        public ActionResult Index()
        {
            return View(context.Customers.ToList()); ;
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            Customer customer = context.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            

            try
            {
                // TODO: Add insert logic here
                string id = User.Identity.GetUserId();
                customer.ApplicationId = id;
                context.Customers.Add(customer);
                context.SaveChanges();
                return RedirectToAction("Details", "Customers", customer);
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            Customer customer = context.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                Customer editedCustomer = context.Customers.Where(c => c.Id == id).FirstOrDefault();
                editedCustomer.Id = customer.Id;
                editedCustomer.firstName = customer.firstName;
                editedCustomer.lastName = customer.lastName;
                editedCustomer.streetAddress = customer.streetAddress;
                editedCustomer.city = customer.city;
                editedCustomer.stateCode = customer.stateCode;
                editedCustomer.zipcode = customer.zipcode;
                editedCustomer.balance = customer.balance;
                editedCustomer.pickupConfirmed = customer.pickupConfirmed;
                editedCustomer.pickUpDay = customer.pickUpDay;
                editedCustomer.pickUpDate = customer.pickUpDate;
                editedCustomer.startDate = customer.startDate;
                editedCustomer.endDate = customer.endDate;
                context.SaveChanges();
                return RedirectToAction("Index", "Home" );
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            Customer customer = context.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View();
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                // TODO: Add delete logic here
                Customer customerToDelete = context.Customers.Where(c => c.Id == id).FirstOrDefault();
                context.Customers.Remove(customerToDelete);
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
