using Microsoft.EntityFrameworkCore;
using MyBank.Models;
using System.Reflection.Metadata;

namespace MyBank
{
    public class ApplicationDbContext : DbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Clientes>();
            modelBuilder.Entity<Transaccion>();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("name=ConnectionStrings:DefaultConnection");
        }

    }
}
