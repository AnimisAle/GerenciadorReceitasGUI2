using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GerenciadorReceitas
{
    public class ReceitasContext : DbContext
    {
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Substitua pela sua string de conexão do PostgreSQL
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=ReceitasDB;Username=postgres;Password=postgres");
        }
    }
}