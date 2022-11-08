using LoginSystem.Utilizador.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginSystem.Utilizador.API.Data.Mappings
{
    public class MoradaMapping : IEntityTypeConfiguration<Morada>
    {
        public void Configure(EntityTypeBuilder<Morada> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Rua)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(x => x.CP)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnType("varchar(8)");

            builder.Property(x => x.Porta)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.ToTable("Moradas");
        }
    }
}
