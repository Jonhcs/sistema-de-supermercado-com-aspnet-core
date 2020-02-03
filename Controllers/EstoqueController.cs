using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_supermercado_com_aspnet_core.Data;
using Sistema_de_supermercado_com_aspnet_core.Models;

namespace Sistema_de_supermercado_com_aspnet_core.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly ApplicationDbContext database;
        public EstoqueController(ApplicationDbContext database) => this.database = database;


        [HttpPost]
        public IActionResult Salvar(Estoque estoqueTemporario){
            database.Estoques.Add(estoqueTemporario);
            database.SaveChanges();
            return RedirectToAction("Estoques","Gestao");
        }

        [HttpPost]
        public IActionResult Atualizar(Estoque estoqueTemporario){

            if (ModelState.IsValid)
            {
                var estoque = database.Estoques.First(p => p.Id == estoqueTemporario.Id);
                estoque.Produto = database.Produtos.First(p => p.Id == estoqueTemporario.ProdutoId);
                estoque.Quantidade = estoqueTemporario.Quantidade;
                database.SaveChanges();
                return RedirectToAction("Estoques","Gestao");
            }
            return RedirectToAction("Estoques","Gestao");
        }

        public IActionResult Deletar(int id){
            var estoque = database.Estoques.First(registro => registro.Id == id);
            database.Estoques.Remove(estoque);
            database.SaveChanges();
            return RedirectToAction("Estoques","Gestao");
        }
    }
}