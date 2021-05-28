using Microsoft.EntityFrameworkCore;
using Projeto_API_REST.Models;

namespace Projeto_API_REST.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }

        public DbSet<CartaoVirtual> CartoesVirtuais {get; set;}
    }
}
