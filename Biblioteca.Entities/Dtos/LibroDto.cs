using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Entities.Dtos
{
    public class LibroDto
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "El título del libro es obligatorio.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "El título debe tener entre 2 y 150 caracteres.")]
        public required string Titulo { get; set; }

        [Required(ErrorMessage = "La fecha de lanzamiento es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "Proporciona una fecha válida.")]
        public DateTime FechaPublicacion { get; set; }

        [Required(ErrorMessage = "El ID del autor es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un autor válido.")]
        public int AutorId { get; set; }

        [Required(ErrorMessage = "El ID del autor es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una categoría válido.")]
        public int CategoriaId { get; set; }

    }
}
