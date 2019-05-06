using System;
using APIBooks.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIBooks.Contexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ):base(options)
        {

        }
        //crea la tabla Autores
        public DbSet<Autor> Autores { get; set; }

        public DbSet<Libro> Libros { get; set; }
    }
}
