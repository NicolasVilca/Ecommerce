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
    public class CategoriesController : ControllerBase
    {
        private ABMContext context;
        public CategoriesController(ABMContext parametro)
        {
            context = parametro;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return context.Categories.Include(x => x.Products).ToList();
            //Include(x => x.).
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            return context.Categories.Find(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Category value)
        {
            context.Categories.Add(value);
            context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Category value)
        {
            var category = context.Categories.Find(id);
            if(category != null)
            {
                category.CategoryId = value.CategoryId;
                category.Title = value.Title;
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
            var category = context.Categories.Find(id);
            if(category != null)
            {
                context.Categories.Remove(category);
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