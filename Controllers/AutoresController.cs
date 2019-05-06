using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using APIBooks.Contexts;
using APIBooks.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace APIBooks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoresController:ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            return context.Autores.ToList();
        }

        [HttpGet("{id}",Name ="autorNavigate")]
        public ActionResult<Autor> Get(int id)
        {
            var autor = context.Autores.FirstOrDefault(x => x.Id == id);
            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Autor autor)
        {
            //int id;
            context.Autores.Add(autor);
            context.SaveChanges();
            return new CreatedAtRouteResult("autorNavigate", new { id = autor.Id } , autor);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id,[FromBody] Autor autor)
        {
            //validamos para evitar que se cambie el id de un recurso
            if (id != autor.Id)
            {
                return BadRequest();
            }

            context.Entry(autor).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {
            var autor = context.Autores.FirstOrDefault(x=>x.Id==id);
            if (autor==null)
            {
                return NotFound();
            }
            context.Autores.Remove(autor);
            context.SaveChanges();

            return autor;
        }
    }
}
