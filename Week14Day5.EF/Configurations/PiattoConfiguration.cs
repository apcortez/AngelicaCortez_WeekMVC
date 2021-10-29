using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week14Day5.Core.Entities;

namespace Week14Day5.EF
{
    internal class PiattoConfiguration : IEntityTypeConfiguration<Piatto>
    {
        public void Configure(EntityTypeBuilder<Piatto> modelBuilder)
        {
            modelBuilder.ToTable("Piatti");
            modelBuilder.HasKey(p => p.Id);
            modelBuilder.Property(p => p.Nome).IsRequired();
            modelBuilder.Property(p => p.Descrizione);
            modelBuilder.Property(p => p.Tipologia);
            modelBuilder.Property(p => p.Prezzo).HasColumnType("decimal(18,2)"); ;


            //Relazione 1 -> n
            modelBuilder.HasOne(p => p.Menu).WithMany(m => m.Piatti).HasForeignKey(m => m.MenuId);
        }
    }
}