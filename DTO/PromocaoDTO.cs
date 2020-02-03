using System.ComponentModel.DataAnnotations;

namespace Sistema_de_supermercado_com_aspnet_core.DTO
{
    public class PromocaoDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage="Este campo é Obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage="Este campo é Obrigatório")]
        public int ProdutoID {get; set;}
        [Required(ErrorMessage="Este campo é Obrigatório")]
        [Range(0,100)]
        public float Porcentagem {get; set; }
    }
}