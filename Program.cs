// Classe principal responsável por configurar os serviços e iniciar a aplicação.

using CP_02_Locadora.Models;
using Microsoft.EntityFrameworkCore;

namespace CP_02_Locadora
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona os serviços necessários ao container.
            builder.Services.AddControllers();

            // Obtém a string de conexão com o banco de dados Oracle.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Configura o contexto do banco de dados.
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseOracle(connectionString));

            var app = builder.Build();

            // Configura o pipeline de requisições HTTP.
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
