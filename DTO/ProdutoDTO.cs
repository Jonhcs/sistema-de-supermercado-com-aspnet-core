using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_supermercado_com_aspnet_core.DTO
{
    public class ProdutoDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage="Nome do Produto é Obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage="Categoria do Produto é Obrigatório")]
        public int CategoriaID { get; set; }
         [Required(ErrorMessage="Fornecedor do Produto é Obrigatório")]
        public int FornecedorID { get; set; }


        [Required(ErrorMessage="Obrigatório")]
        public float PrecoDeCusto { get; set; }
        [Required(ErrorMessage="Obrigatório")]
        public string PrecoDeCustoString { get; set; }


        [Required(ErrorMessage="Obrigatório")]
        public float PrecoDeVenda { get; set; }
        [Required(ErrorMessage="Obrigatório")]
        public string PrecoDeVendaString { get; set; }


        [Required(ErrorMessage="Obrigatório")]
        [Range(0,2, ErrorMessage="Medição Inválida")]
        public int Medicao { get; set; }
    }
}

