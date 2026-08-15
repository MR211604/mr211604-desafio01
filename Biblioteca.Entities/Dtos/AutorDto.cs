using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Entities.Dtos
{
    public class AutorDto
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener mas de {1} caracteres", MinimumLength = 3)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Apellido { get; set; } = string.Empty;
    }
}
