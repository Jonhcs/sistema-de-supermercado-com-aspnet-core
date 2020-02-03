using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_supermercado_com_aspnet_core.Data;
using Sistema_de_supermercado_com_aspnet_core.DTO;
using Sistema_de_supermercado_com_aspnet_core.Models;

namespace Sistema_de_supermercado_com_aspnet_core.Controllers
{
    public class PromocoesController : Controller
    {
        private readonly ApplicationDbContext database;
        public PromocoesController(ApplicationDbContext database) => this.database = database;


        [HttpPost]
        public IActionResult Salvar(PromocaoDTO promocaoTemporaria ) {
            if (ModelState.IsValid)
            {   
                Promocao promocao = new Promocao();
                promocao.Nome = promocaoTemporaria.Nome;
                promocao.Produto = database.Produtos.First(prod => prod.Id == promocaoTemporaria.ProdutoID);
                promocao.Porcentagem = promocaoTemporaria.Porcentagem;
                promocao.Status = true;
                database.Promocaos.Add(promocao);
                database.SaveChanges();
                return RedirectToAction("Promocoes", "Gestao");

            }else
            {
                ViewBag.Produtos = database.Produtos.ToList();
                return View("../Gestao/NovaPromocao");
            }

        }
        public IActionResult Atualizar(PromocaoDTO PromocaoTemporaria) {
            if (ModelState.IsValid)
            {
                var promocao = database.Promocaos.First( p => p.Id == PromocaoTemporaria.Id);
                promocao.Nome = PromocaoTemporaria.Nome;
                promocao.Porcentagem = PromocaoTemporaria.Porcentagem;
                promocao.Produto = database.Produtos.First( p => p.Id == PromocaoTemporaria.ProdutoID);
                database.SaveChanges();
                return RedirectToAction("Promocoes","Gestao");
            }else
            {
                return RedirectToAction("Promocoes","Gestao");
            }
        }
        public IActionResult Deletar(int id) {
            if (id > 0)
            {
                var promocao = database.Promocaos.First(cat => cat.Id == id);
                promocao.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("Promocoes","Gestao");
        }
    }
}