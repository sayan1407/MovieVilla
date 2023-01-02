using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieVilla.Models;
using System.Data.Entity;
using AutoMapper;

namespace MovieVilla.Controllers.Api
{
    public class CustomersController : ApiController
    {

        public ApplicationDbContext db = new ApplicationDbContext();
        //GET/api/cutomers
        public IHttpActionResult GetCustomers()
        {
            var CustomerDto = db.Customers.Include(c => c.MembershipType).ToList().Select(Mapper.Map<Customer, CustomerDTO>);
            return Ok(CustomerDto);
        }
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);
            db.Customers.Add(customer);
            db.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customerDto.Id), customerDto);
        }
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = db.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto, customerInDb);
            db.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return Ok();
        }
    }
}
