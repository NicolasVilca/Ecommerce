using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apifinal.Models;
using Microsoft.EntityFrameworkCore;

namespace apifinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ABMContext context;
        public CustomersController(ABMContext parametro)
        {
            context = parametro;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return context.Customers.ToList();
        }

        // GET api/values/5
        [HttpGet("{username}")]
        public ActionResult<Customer> Get(string username)
        {

            return context.Customers.FirstOrDefault(b => b.Username == username);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Customer value)
        {
            context.Customers.Add(value);
            context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Customer value)
        {
            var Customer = context.Customers.Find(id);
            if(Customer != null)
            {
                Customer.Username = value.Username;
                Customer.FirstName = value.FirstName;
                Customer.Surname = value.Surname;
                Customer.Email = value.Email;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Customer = context.Customers.Find(id);
            if(Customer != null)
            {
                context.Customers.Remove(Customer);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}