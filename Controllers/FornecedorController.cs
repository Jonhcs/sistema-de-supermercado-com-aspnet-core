using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_supermercado_com_aspnet_core.Data;
using Sistema_de_supermercado_com_aspnet_core.DTO;
using Sistema_de_supermercado_com_aspnet_core.Models;

namespace Sistema_de_supermercado_com_aspnet_core.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly ApplicationDbContext database;
        public FornecedorController(ApplicationDbContext database) => this.database = database;
        public IActionResult Salvar(FornecedorDTO fornecedorTemporario){
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = fornecedorTemporario.Nome;
            fornecedor.Email = fornecedorTemporario.Email;
            fornecedor.Telefone = fornecedorTemporario.Telefone;
            fornecedor.Status = true;
            database.Add(fornecedor);
            database.SaveChanges();
            return RedirectToAction("Fornecedores","Gestao");
        }
        [HttpPost]
        public IActionResult Atualizar(FornecedorDTO fornecedorTemporaria) {
            if (ModelState.IsValid)
            {
                var fornecedor = database.Fornecedores.First( cat => cat.Id == fornecedorTemporaria.Id);
                fornecedor.Nome = fornecedorTemporaria.Nome;
                database.SaveChanges();
                return RedirectToAction("Fornecedores","Gestao");
            }else
            {
                return View("../gestao/editarfornecedor");
            }
        }
        public IActionResult Deletar(int id) {
            if (id > 0)
            {
                var fornecedor = database.Fornecedores.First(cat => cat.Id == id);
                fornecedor.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("Fornecedores","Gestao");
        }
    }
}