using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieVilla.Models;
using MovieVilla.ViewModel;
using AutoMapper;

namespace MovieVilla.Controllers
{
    [Authorize(Roles = Role.canManageMovies)]
    public class CustomersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult CustomersList()
        {
            //var Customers = db.Customers.Include("MembershipType").ToList();
            if (User.IsInRole(Role.canManageMovies))
                return View("CustomersList");
            return View("ReadOnlyCustomersList");

        }
        

        public ActionResult Details(int? id)
        {
            CustomerViewModel cust;

            if (id == null)
            {
                cust = new CustomerViewModel()
                {
                    membershipTypes = db.MembershipTypes.ToList(),
                    customer = new Customer()
                    {
                        Id = 0
                    },
                    Title = "Create Cutomer"
                };
                return View(cust);
            }
            var customer = db.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            cust = new CustomerViewModel()
            {
                customer = customer,
                membershipTypes = db.MembershipTypes.ToList(),
                Title = "Edit Customer"
            };
            return View(cust);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                CustomerViewModel cust = new CustomerViewModel()
                {
                    customer = customer,
                    membershipTypes = db.MembershipTypes.ToList()
                };
                return View("Details", cust);
            }
            if (customer.Id == 0)
            {
                db.Customers.Add(customer);
            }
            else
            {
                var customerInDb = db.Customers.SingleOrDefault(c => c.Id == customer.Id);
                if (customerInDb == null)
                    return HttpNotFound();
                else
                {
                    Mapper.Map(customer, customerInDb);
                    //customerInDb.BirthDate = customer.BirthDate;
                    //customerInDb.Name = customer.Name;
                    //customerInDb.MembershipTypeId = customer.MembershipTypeId;
                    //customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                }
            }
            db.SaveChanges();
            return RedirectToAction("CustomersList");
        }

    }
}
