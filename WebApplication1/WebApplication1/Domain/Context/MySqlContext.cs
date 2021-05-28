using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.Moradores;

namespace WebApplication1.Domain.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {
            
        }
        
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
            
        }
        
        public DbSet<Morador> Moradores { get; set; }
    }
}