using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Entities.Dtos
{
    public class CategoriaDto
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener mas de {1} caracteres", MinimumLength = 3)]
        public string Nombre { get; set; } = string.Empty;
    }
}
