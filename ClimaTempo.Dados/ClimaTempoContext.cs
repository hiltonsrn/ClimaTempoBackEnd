using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace ClimaTempo.Dados
{
    public class ClimaTempoContext : DbContext
    {
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<PrevisaoClima> PrevisaoClima { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=UDS_DELL;Initial Catalog=ClimaTempoSimples;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cidade>()
                       .HasMany(c => c.PrevisaoClima)
                       .WithOne(e => e.Cidade).IsRequired();
            modelBuilder.Entity<Cidade>()
                       .HasOne(c => c.Estado)
                       .WithMany(e => e.Cidade).IsRequired();
        }
    }
}