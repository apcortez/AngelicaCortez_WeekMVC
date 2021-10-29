using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week14Day5.Core.Entities;

namespace Week14Day5.EF
{
    internal class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> modelBuilder)
        {
            modelBuilder.ToTable("IMenu"); 
            modelBuilder.HasKey(m => m.Id);
            modelBuilder.Property(m => m.Nome).IsRequired();


            //Relazione 1 -> n
            modelBuilder.HasMany(m => m.Piatti).WithOne(p => p.Menu).HasForeignKey(p => p.MenuId);
        }
    }
}