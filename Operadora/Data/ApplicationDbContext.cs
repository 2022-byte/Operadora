using Microsoft.EntityFrameworkCore;
using Operadora.Models;

namespace Operadora.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Operador> Operadors { get; set; }
    }
}
