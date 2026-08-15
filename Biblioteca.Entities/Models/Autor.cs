using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Entities.Models
{
    public class Autor
    {
        [Key]
        [Column("AutorID")]
        public int Id { get; set; }

        public required string Nombre { get; set; }

        public required string Apellido { get; set; }
    }
}
