using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_supermercado_com_aspnet_core.Data;
using Sistema_de_supermercado_com_aspnet_core.DTO;

namespace Sistema_de_supermercado_com_aspnet_core.Controllers
{
    
    public class GestaoController : Controller
    {
        private readonly ApplicationDbContext database;
        public GestaoController(ApplicationDbContext database) => this.database = database;
        public IActionResult Index(){
            return View();
        }
        public IActionResult Categorias(){
            var categorias = database.Categorias.Where(cat => cat.Status == true).ToList();
            return View(categorias);
        }

        public IActionResult EditarCategoria( int id) {
            var categoria = database.Categorias.First( c => c.Id == id);
            CategoriaDTO categoriaView = new CategoriaDTO();
            categoriaView.Id = categoria.Id;
            categoriaView.Nome = categoria.Nome;
            return View(categoriaView);
        }
        public IActionResult NovaCategoria(){
            return View();
        }
        public IActionResult Fornecedores(){
            var fornecedores = database.Fornecedores.Where(forn => forn.Status == true ).ToList();
            return View(fornecedores);
        }
        public IActionResult NovoFornecedor(){
            return View();
        }
        public IActionResult EditarFornecedor(int id) {
            var fornecedor = database.Fornecedores.First(forn => forn.Id == id);
            FornecedorDTO fornecedorView = new FornecedorDTO();
            fornecedorView.Id = fornecedor.Id;
            fornecedorView.Nome = fornecedor.Nome;
            fornecedorView.Email = fornecedor.Email;
            fornecedorView.Telefone = fornecedor.Telefone;
            return View(fornecedorView);
        }
        public IActionResult Produtos(){
            var produtos = database.Produtos.Include( p => p.Categoria).Include( p => p.Fornecedor).Where( p => p.Status == true).ToList();
            return View(produtos);
        }
        public IActionResult NovoProduto(){
            ViewBag.Categorias = database.Categorias.ToList();
            ViewBag.Fornecedores = database.Fornecedores.ToList();
            return View();
        }
        public IActionResult EditarProduto(int id) {

            var produto = database.Produtos.Include( p => p.Categoria).Include( p => p.Fornecedor).First(forn => forn.Id == id);
            ProdutoDTO produtoView = new ProdutoDTO();
            produtoView.Id = produto.Id;
            produtoView.Nome = produto.Nome;
            produtoView.PrecoDeCusto = produto.PrecoDeCusto;
            produtoView.PrecoDeVenda = produto.PrecoDeVenda;
            produtoView.Medicao = produto.Medicao;
            produtoView.CategoriaID = produto.Categoria.Id;
            produtoView.FornecedorID = produto.Fornecedor.Id;
            ViewBag.Categorias = database.Categorias.ToList();
            ViewBag.Fornecedores = database.Fornecedores.ToList();
            return View(produtoView);
        }

        public IActionResult Promocoes(){
            var promocoes = database.Promocaos.Include(p => p.Produto).Where( p => p.Status == true ).ToList();
            return View(promocoes);
        }
        public IActionResult NovaPromocao(){
            ViewBag.Produtos = database.Produtos.ToList();
            return View();
        }

        public IActionResult EditarPromocao(int id) {

            var promocao = database.Promocaos.Include( p => p.Produto).First(forn => forn.Id == id);
            PromocaoDTO promocaoView = new PromocaoDTO();
            promocaoView.Id = promocao.Id;
            promocaoView.Nome = promocao.Nome;
            promocaoView.Porcentagem = promocao.Porcentagem;
            promocaoView.ProdutoID = promocao.Produto.Id;
            ViewBag.Produtos = database.Produtos.ToList();
            return View(promocaoView);
        }
        public IActionResult Estoques(){
            var estoque = database.Estoques.Include(e => e.Produto).ToList();
            return View(estoque);
        }
        public IActionResult NovoEstoque(){
            ViewBag.Produtos = database.Produtos.ToList();
            return View();
        }

        public IActionResult EditarEstoque(int id) {
            var estoque = database.Estoques.Include(p => p.Produto).First( e => e.Id == id);
            ViewBag.Produtos = database.Produtos.ToList();
            return View(estoque);
        }
    }
}