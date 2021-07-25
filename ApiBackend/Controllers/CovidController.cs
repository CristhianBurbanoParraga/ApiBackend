using ApiBackend.Contexto;
using ApiBackend.Modelo;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiBackend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class CovidController : ControllerBase
    {
        private readonly AppDbContext context;

        public CovidController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<CovidController>
        [HttpGet]
        public IEnumerable<Covid> Get()
        {
            return context.Covid.ToList();
        }

        // GET api/<CovidController>/5
        [HttpGet("{id}")]
        public Covid Get(int id)
        {
            var covid = context.Covid.FirstOrDefault(c => c.Id == id);
            return covid;
        }

        // POST api/<CovidController>
        [HttpPost]
        public ActionResult Post([FromBody] Covid covid)
        {
            try
            {
                context.Covid.Add(covid);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/<CovidController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Covid covid)
        {
            try
            {
                if (covid.Id == id)
                {
                    context.Entry(covid).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok();
                } else
                {
                    return BadRequest();
                }
                
            } catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // DELETE api/<CovidController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var covid = context.Covid.FirstOrDefault(c => c.Id == id);
            if (covid != null)
            {
                context.Covid.Remove(covid);
                context.SaveChanges();
                return Ok();
            } else
            {
                return BadRequest();
            }
        }
    }
}
