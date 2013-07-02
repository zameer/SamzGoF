using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BusinessObjects;
using DataObjects;

namespace SamzFoo.Controllers
{
    public class CustomersController : Controller
    {
        ICustomerDao customerDao = DataAccess.CustomerDao;
        //
        // GET: /Customers/

        public ActionResult Index(string serachString)
        {
            List<Customer> customers = customerDao.GetCustomers();
            if(!string.IsNullOrEmpty(serachString))
                customers = customers.Where(c=> c.CompanyName.Contains(serachString)).ToList();

            //Set countries
            var countries = new List<string>();
            countries.Add("Srilanka");
            countries.Add("USA");
            countries.Add("Argentina");
            countries.Add("Netherlands");

            ViewBag.Countries = new SelectList(countries);

            return View(customers);
        }

        [HttpPost]
        public ActionResult IndexDelete(int[] deleteInputs)
        {
            if (deleteInputs != null)
            {
                foreach (var customerId in deleteInputs)
                    customerDao.DeleteCustomer(customerId);

                ModelState.AddModelError("", deleteInputs.Count().ToString() + " record(s) has been successfully deleted!");
            }
            else
            {
                ModelState.AddModelError("", " No record(s) has been successfully deleted!");
            }


            List<Customer> customers = customerDao.GetCustomers();

            //Set countries
            var countries = new List<string>();
            countries.Add("Srilanka");
            countries.Add("USA");
            countries.Add("Argentina");
            countries.Add("Netherlands");


            ViewBag.Countries = new SelectList(countries);
            return View("Index", customers);
            //return View(customers);
        }

        //
        // GET: /Customers/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Customers/Create

        public ActionResult Create()
        {
            //Set countries
            var countries = new List<string>();
            countries.Add("Srilanka");
            countries.Add("USA");
            countries.Add("Argentina");
            countries.Add("Netherlands");


            ViewBag.Country = new SelectList(countries);
            return View();
        }

        //
        // POST: /Customers/Create

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    customerDao.InsertCustomer(customer);
                    return RedirectToAction("Index");
                }
                return View(customer);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Customers/Edit/5

        public ActionResult Edit(int id)
        {
            Customer customer = customerDao.GetCustomer(id);
            return View(customer);
        }

        //
        // POST: /Customers/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    customerDao.UpdateCustomer(customer);
                    return RedirectToAction("Index");
                }
                return View(customer);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Customers/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Customers/Delete/5

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
