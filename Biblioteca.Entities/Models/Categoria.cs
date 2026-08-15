using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Entities.Models
{
    public class Categoria
    {
        [Key]
        [Column("CategoriaID")]
        public int Id { get; set; }

        public required string Nombre { get; set; }
    }
}
