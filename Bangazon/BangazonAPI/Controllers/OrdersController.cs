using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bangazon.Data;
using Bangazon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;


namespace BangazonAPI.Controllers
{
    [ProducesAttribute("application/json")]
    [Route("[controller]")]//annotation - a way to decorate with modifying the code
    public class OrdersController : Controller
    {
        private BangazonContext context;
        public OrdersController(BangazonContext ctx)
        {
            context = ctx;
        }
        
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> orders = from order in context.Order select order;//select everythign in the customer table

            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);

        }
        // GET api/values/5
        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Order order = context.Order.Single(m => m.OrderId == id);

                if (order == null)
                {
                    return NotFound();
                }
                
                return Ok(order);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Order.Add(order);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderExists(order.OrderId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetOrder", new { id = order.OrderId }, order);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Order order)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
           if (order.OrderId != id)
            {
                return BadRequest();
            }
            context.Order.Update(order);
            context.SaveChanges();
            return Ok(order);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            Order order = context.Order.Single(m => m.OrderId == id);

            if(order == null)
            {
                return NotFound();
            }
            try
            {
                context.Order.Remove(order);
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderExists(order.OrderId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return Ok(order);
        }
        private bool OrderExists(int id)
        {
            return context.Order.Count(e => e.OrderId == id) > 0;
        }
    }
}
