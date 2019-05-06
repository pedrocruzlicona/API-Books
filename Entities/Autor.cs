using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIBooks.Entities
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  Nombre { get; set; }

        //propiedad de navegacion
        public List<Libro> Libros { get; set; }
    }
}
