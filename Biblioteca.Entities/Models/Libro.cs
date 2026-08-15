using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Entities.Models
{
    public class Libro
    {
        [Key]
        [Column("LibroID")]
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }
        
        [Required]
        [ForeignKey("Autor")]
        public int AutorId { get; set; }

        //[Required]
        //[ForeignKey("Editorial")]
        //public int EditorialId { get; set; }

        [Required]
        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }

        public Autor? Autor { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
