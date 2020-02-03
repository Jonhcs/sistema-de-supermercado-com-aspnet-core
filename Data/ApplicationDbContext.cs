using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sistema_de_supermercado_com_aspnet_core.Models;

namespace Sistema_de_supermercado_com_aspnet_core.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Categoria> Categorias {get; set;}
        public DbSet<Fornecedor> Fornecedores {get; set;}
        public DbSet<Produto> Produtos {get; set;}
        public DbSet<Promocao> Promocaos {get; set;}
        public DbSet<Estoque> Estoques {get; set;}
        public DbSet<Saida> Saidas {get; set;}
        public DbSet<Venda> Vendas  {get; set;}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
