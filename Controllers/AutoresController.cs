using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using APIBooks.Contexts;
using APIBooks.Entities;
using Microsoft.AspNetCore.Mvc;

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

    }
}
