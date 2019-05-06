using System;
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
    public class LibrosController:ControllerBase
    {
        private readonly ApplicationDbContext context;

        //inyeccion de dependencia para acceder a una instancia de db context
        public LibrosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            //Include para incluir entidades relacionadas con la entidad Libros
            //se coloca la Propiedad de nave
            return context.Libros.Include(x => x.Autor).ToList();
        }
        [HttpGet("{id}", Name = "ObtenerLibro")]
        public ActionResult<Libro> Get(int id)
        {
            var libro = context.Libros.Include(x => x.Autor).FirstOrDefault(x => x.Id == id);

            if (libro == null)
            {
                return NotFound();
            }

            return libro;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Libro libro)
        {
            context.Libros.Add(libro);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerLibro", new { id = libro.Id }, libro);
        }
    }
}
