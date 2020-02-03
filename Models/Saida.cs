using System;
namespace Sistema_de_supermercado_com_aspnet_core.Models
{
    public class Saida
    {
        public int Id { get; set; }
        public Produto Produto{ get; set;}
        public float Quantidade {get; set;}
        public float ValorDaVenda {get; set;}
        public DateTime Data { get; set;}
        public Venda Venda { get; set;}

    }
}