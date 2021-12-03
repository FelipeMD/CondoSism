using API.Domain.Entities.Apartamentos;
using API.Domain.Entities.Moradores;
using API.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace API.Domain.Context
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
        
        public DbSet<Apartamento> Apartamentos { get; set; }
        public DbSet<User> Users { get; set; }
    }
}