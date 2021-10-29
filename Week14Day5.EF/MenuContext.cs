using Microsoft.EntityFrameworkCore;
using System;
using Week14Day5.Core.Entities;

namespace Week14Day5.EF
{
    public class MenuContext : DbContext
    {
        public DbSet<Menu> IMenu { get; set; }
        public DbSet<Piatto> Piatti { get; set; }
        public DbSet<Utente> Utenti { get; set; }
        public MenuContext()
        {

        }

        public MenuContext(DbContextOptions<MenuContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
		                                Database=RistoranteDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Menu>(new MenuConfiguration());
            modelBuilder.ApplyConfiguration<Piatto>(new PiattoConfiguration());
            modelBuilder.ApplyConfiguration<Utente>(new UtenteConfiguration());
        }
    }
}
