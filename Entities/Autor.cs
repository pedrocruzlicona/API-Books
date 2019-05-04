using System;
using System.ComponentModel.DataAnnotations;

namespace APIBooks.Entities
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }
        public int Nombre { get; set; }
    }
}
