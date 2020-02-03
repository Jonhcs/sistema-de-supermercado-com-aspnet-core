using System.ComponentModel.DataAnnotations;

namespace Sistema_de_supermercado_com_aspnet_core.Models
{
    public class Promocao
    {
        public int Id { get; set; }
        
        public string Nome { get; set; }
        
        public Produto Produto {get; set;}
        
        public float Porcentagem {get; set; }
        
        public bool Status {get; set;}


    }
}