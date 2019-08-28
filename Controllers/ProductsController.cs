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
    public class ProductsController : ControllerBase
    {
        private ABMContext context;
        public ProductsController(ABMContext parametro)
        {
            context = parametro;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return context.Products.Include(x => x.Categories).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return context.Products.Find(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            context.Products.Add(value);
            context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product value)
        {
            var product = context.Products.Find(id);
            if(product != null)
            {
                product.ProductId = value.ProductId;
                product.Price = value.Price;
                product.Title = value.Title;
                product.Description = value.Description;
                product.CategoryId = value.CategoryId;
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
            var product = context.Products.Find(id);
            if(product != null)
            {
                context.Products.Remove(product);
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
