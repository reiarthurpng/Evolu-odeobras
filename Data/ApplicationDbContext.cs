using Microsoft.EntityFrameworkCore;
using EvolucaoObra.Models;

namespace EvolucaoObra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Obra> Obras { get; set; }
    }
}
