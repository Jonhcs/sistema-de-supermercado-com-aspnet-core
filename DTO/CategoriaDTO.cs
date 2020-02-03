using System.ComponentModel.DataAnnotations;

namespace Sistema_de_supermercado_com_aspnet_core.DTO
{
    public class CategoriaDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Nome muito grande.")]
        [MinLength(2, ErrorMessage = "Precisa ter no mínimo 2 caracteres.")]
        public string Nome { get; set; }
    }
}