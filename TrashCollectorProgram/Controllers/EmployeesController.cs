using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollectorProgram.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

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
        public async Task<ActionResult> GeoLocate(int id)
        {
            
            Customer customer = context.Customers.Where(c => c.Id == id).FirstOrDefault();
            string requesturl = "https://maps.googleapis.com/maps/api/geocode/json?address=";
            string customerAddress = System.Web.HttpUtility.UrlEncode(
                customer.streetAddress + " " +
                customer.city + " " +
                customer.stateCode + " " +
                customer.zipcode);

            string apiKey = APIKeys.GeoCodeApi;
            
            
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(requesturl + customerAddress + apiKey);
            JObject map = JObject.Parse(response);
            customer.lat = (float)map["results"][0]["geometry"]["location"]["lat"];
            customer.lng = (float)map["results"][0]["geometry"]["location"]["lng"];


            return View(customer);
        } 
        public ActionResult ConfirmPickupAndEditBalance(int id)
        {
            Customer customer = context.Customers.Where(c => c.Id == id).FirstOrDefault();


            return View(customer);
        }
        [HttpPost]
        public ActionResult ConfirmPickupAndEditBalance(int id, Customer customer)
        {
            decimal charge = 10;
            try
            {
                // TODO: Add update logic here
                Customer customerToEdit = context.Customers.Where(e => e.Id == id).FirstOrDefault();
                
                customerToEdit.pickupConfirmed = customer.pickupConfirmed;
                
                context.SaveChanges();
                if (customerToEdit.pickupConfirmed == true)
                {
                    customerToEdit.balance += charge;
                }
                context.SaveChanges();

                return RedirectToAction("GetPickupsToday");
            }
            catch
            {
                return View();
            }

        }
        public ActionResult GetPickupsToday()
        {
            DateTime today = DateTime.Today;
            DayOfWeek day = DateTime.Today.DayOfWeek;
            var customersInDay = context.Customers.Where(c => c.pickUpDay == day || c.pickUpDate == today).ToList();
            var notSuspendedPickup = customersInDay.Where(c => c.startDate > today || c.startDate == null && c.endDate < today || c.startDate == null).ToList();
            
            return View(notSuspendedPickup);
        }
        public ActionResult GetMonday()
        {
            DateTime today = DateTime.Today;
            DayOfWeek day = DateTime.Today.DayOfWeek;
            var mondayCustomer = context.Customers.Where(c => c.pickUpDay == DayOfWeek.Monday || c.pickUpDate == today).ToList();
            var notSuspendedOnMonday = mondayCustomer.Where(c => c.startDate > today || c.startDate == null && c.endDate < today || c.startDate == null).ToList();
            return View(notSuspendedOnMonday);
        }
        public ActionResult GetTuesday()
        {
            DateTime today = DateTime.Today;
            DayOfWeek day = DateTime.Today.DayOfWeek;
            var tuesdayCustomer = context.Customers.Where(c => c.pickUpDay == DayOfWeek.Tuesday || c.pickUpDate == today).ToList();
            var notSuspendedOnTuesday = tuesdayCustomer.Where(c => c.startDate > today || c.startDate == null && c.endDate < today || c.startDate == null).ToList();
            return View(notSuspendedOnTuesday);
        }
        public ActionResult GetWednesday()
        {
            DateTime today = DateTime.Today;
            DayOfWeek day = DateTime.Today.DayOfWeek;
            var wednesdayCustomer = context.Customers.Where(c => c.pickUpDay == DayOfWeek.Wednesday || c.pickUpDate == today).ToList();
            var notSuspendedOnWednesday = wednesdayCustomer.Where(c => c.startDate > today || c.startDate == null && c.endDate < today || c.startDate == null).ToList();
            return View(notSuspendedOnWednesday);
        }
        public ActionResult GetThursday()
        {
            DateTime today = DateTime.Today;
            DayOfWeek day = DateTime.Today.DayOfWeek;
            var thursdayCustomer = context.Customers.Where(c => c.pickUpDay == DayOfWeek.Thursday || c.pickUpDate == today).ToList();
            var notSuspendedOnThursday = thursdayCustomer.Where(c => c.startDate > today || c.startDate == null && c.endDate < today || c.startDate == null).ToList();
            return View(notSuspendedOnThursday);
        }
        public ActionResult GetFriday()
        {
            DateTime today = DateTime.Today;
            DayOfWeek day = DateTime.Today.DayOfWeek;
            var fridayCustomer = context.Customers.Where(c => c.pickUpDay == DayOfWeek.Friday || c.pickUpDate == today).ToList();
            var notSuspendedOnFriday = fridayCustomer.Where(c => c.startDate > today || c.startDate == null && c.endDate < today || c.startDate == null).ToList();
            return View(notSuspendedOnFriday);
        }
        public ActionResult GetSaturday()
        {
            DateTime today = DateTime.Today;
            DayOfWeek day = DateTime.Today.DayOfWeek;
            var saturdayCustomer = context.Customers.Where(c => c.pickUpDay == DayOfWeek.Saturday || c.pickUpDate == today).ToList();
            var notSuspendedOnSaturday = saturdayCustomer.Where(c => c.startDate > today || c.startDate == null && c.endDate < today || c.startDate == null).ToList();
            return View(notSuspendedOnSaturday);
        }
        public ActionResult GetSunday()
        {
            DateTime today = DateTime.Today;
            DayOfWeek day = DateTime.Today.DayOfWeek;
            var sundayCustomer = context.Customers.Where(c => c.pickUpDay == DayOfWeek.Sunday || c.pickUpDate == today).ToList();
            var notSuspendedOnSunday = sundayCustomer.Where(c => c.startDate > today || c.startDate == null && c.endDate < today || c.startDate == null).ToList();
            return View(notSuspendedOnSunday);
        }

        //GET: Pickups in zipcode

        public ActionResult GetPickups(Employee employee)
        {
            var pickUpsInZipcode = context.Customers.Where(e => e.zipcode == employee.zipcode).ToList();            
            return View(pickUpsInZipcode);
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
                return RedirectToAction("GetPickups", "Employees", employee);
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
