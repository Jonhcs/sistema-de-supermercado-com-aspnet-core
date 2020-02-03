using System.ComponentModel.DataAnnotations;

namespace Sistema_de_supermercado_com_aspnet_core.DTO
{
    public class FornecedorDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = " Esse campo é obrigatório " )]
        public string Nome { get; set; }
        [Required(ErrorMessage = " Esse campo é obrigatório " )]
        [EmailAddress(ErrorMessage="Digite um email válido")]
        public string Email { get; set;}
        [Required(ErrorMessage = " Esse campo é obrigatório " )]
        [Phone(ErrorMessage="Digite um Telfone Válido")]
        public string Telefone { get; set;}
    }
}