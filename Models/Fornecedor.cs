namespace Sistema_de_supermercado_com_aspnet_core.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set;}
        public string Telefone { get; set;}
        public bool Status { get; set; }
    }
}