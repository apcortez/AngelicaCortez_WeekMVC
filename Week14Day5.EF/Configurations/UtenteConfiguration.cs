using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week14Day5.Core.Entities;

namespace Week14Day5.EF
{
    internal class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> modelBuilder)
        {
            modelBuilder.ToTable("Utente");
            modelBuilder.HasKey(s => s.Id);
            modelBuilder.Property(s => s.Nome).IsRequired();
            modelBuilder.Property(s => s.Username).IsRequired();
            modelBuilder.Property(s => s.Password).IsRequired();
            modelBuilder.Property(s => s.Ruolo).IsRequired();
        }
    }
}