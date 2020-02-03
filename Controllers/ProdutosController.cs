using System;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_supermercado_com_aspnet_core.Data;
using Sistema_de_supermercado_com_aspnet_core.DTO;
using Sistema_de_supermercado_com_aspnet_core.Models;

namespace Sistema_de_supermercado_com_aspnet_core.Controllers
{
    public class ProdutosController : Controller
    {

        private readonly ApplicationDbContext database;
        public ProdutosController(ApplicationDbContext database) => this.database = database;
        public IActionResult Salvar(ProdutoDTO ProdutoTemporario){

            if (ModelState.IsValid)
            {
                Produto produto = new Produto();
                produto.Nome = ProdutoTemporario.Nome;
                produto.Categoria = database.Categorias.First(categoria => categoria.Id == ProdutoTemporario.CategoriaID);
                produto.Fornecedor = database.Fornecedores.First(fornecedor => fornecedor.Id == ProdutoTemporario.FornecedorID);
                produto.PrecoDeVenda = float.Parse(ProdutoTemporario.PrecoDeVendaString, CultureInfo.InstalledUICulture.NumberFormat);
                produto.PrecoDeCusto = float.Parse(ProdutoTemporario.PrecoDeCustoString, CultureInfo.InstalledUICulture.NumberFormat);
                produto.Medicao = ProdutoTemporario.Medicao;
                produto.Status = true;
                database.Produtos.Add(produto);
                database.SaveChanges();

                return RedirectToAction("Produtos", "Gestao");
            }else
            {
                ViewBag.Categorias = database.Categorias.ToList();
                ViewBag.Fornecedores = database.Fornecedores.ToList();
                return View("../Gestao/NovoProduto");
            }
        }

        public IActionResult Atualizar(ProdutoDTO produtoTemporario){
            if (ModelState.IsValid)
            {
                var produto = database.Produtos.First(p => p.Id == produtoTemporario.Id);
                produto.Nome = produtoTemporario.Nome;
                produto.PrecoDeCusto = produtoTemporario.PrecoDeCusto;
                produto.PrecoDeVenda = produtoTemporario.PrecoDeVenda;
                produto.Medicao = produtoTemporario.Medicao;
                produto.Categoria = database.Categorias.First(categoria => categoria.Id == produtoTemporario.CategoriaID);
                produto.Fornecedor = database.Fornecedores.First(fornecedor => fornecedor.Id == produtoTemporario.FornecedorID);
                database.SaveChanges();
                return RedirectToAction("Produtos","Gestao");
            }
            return RedirectToAction("Produtos","Gestao");
        }

        public IActionResult Deletar(int id) {
            if (id > 0 )
            {
                var produto = database.Produtos.First( p => p.Id == id);
                produto.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("Produtos", "Gestao");
        }

        [HttpPost]
        public IActionResult Produto(int id) {
            if (id > 0)
            {
                var produto = database.Produtos.Where( p => p.Status == true).Include( p => p.Categoria).Include( p => p.Fornecedor).First( p => p.Id == id);
                if (produto != null) {
                    var estoque = database.Estoques.First(e => e.Produto.Id == produto.Id);
                    if (estoque == null){     
                        produto = null;    
                    }
                }
                
                if (produto != null){   
                    Promocao promocao;
                    try{
                        promocao = database.Promocaos.First(p => p.Produto.Id == produto.Id);
                    }catch(Exception e){
                        promocao = null;
                    }
      
                    if(promocao != null){
                        var divisao = (promocao.Porcentagem/100);
                        produto.PrecoDeVenda -= produto.PrecoDeVenda * divisao ;
                    }
                    
                    Response.StatusCode = 200;
                    return Json(produto);
                }else
                {
                    Response.StatusCode = 404;
                    return Json(null);
                }
            }else{
                Response.StatusCode = 404;
                return Json(null);
            }
            
        }

        [HttpPost]
        public IActionResult GerarVendas([FromBody] VendaDTO dados) {
           //Gerando Venda
           Venda venda = new Venda();
           venda.Total = dados.total;
           venda.Troco = dados.troco;
           venda.ValorPago = dados.troco <= 0.01f ? dados.total : dados.total + dados.troco;
           venda.Data = DateTime.Now;
           database.Vendas.Add(venda);
           database.SaveChanges();
           return Ok(new{msg="Venda Processada Com Sucesso!"});
           
           //return Ok(dados);
        }

        public class SaidaDTO {
            public int produto;
            public int quantidade;
            public float subtotal;
        }

        public class VendaDTO{
            public float total;
            public float troco;
            public SaidaDTO[] produtos;
        }
    }
}