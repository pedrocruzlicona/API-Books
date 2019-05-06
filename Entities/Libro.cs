using System;
using System.ComponentModel.DataAnnotations;

namespace APIBooks.Entities
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public int AutorId { get; set; }

        //propiedad de navegación
        public Autor Autor { get; set; }
    }
}
