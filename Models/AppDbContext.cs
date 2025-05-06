// Classe de contexto do Entity Framework Core responsável por acessar o banco de dados.

using Microsoft.EntityFrameworkCore;

namespace CP_02_Locadora.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet que representa a tabela de Carros no banco.
        public DbSet<Carro> Carros { get; set; }
    }
}
