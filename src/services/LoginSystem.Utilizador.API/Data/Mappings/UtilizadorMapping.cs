using LoginSystem.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginSystem.Utilizador.API.Data.Mappings
{
    public class UtilizadorMapping : IEntityTypeConfiguration<Models.Utilizador>
    {
        public void Configure(EntityTypeBuilder<Models.Utilizador> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.OwnsOne(x => x.NIF, tf =>
            {
                tf.Property(x => x.Numero)
                .IsRequired()
                .HasMaxLength(Nif.NifMaxLength)
                .HasColumnName("Nif")
                .HasColumnType($"varchar({Nif.NifMaxLength})");
            });

            builder.OwnsOne(x => x.Email, tf =>
            {
                tf.Property(x => x.Endereco)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType($"varchar({Email.EnderecoMaxLength})");
            });

            builder.HasOne(x => x.Morada)
                .WithOne(x => x.Utilizador);

            builder.ToTable("Utilizadores");
        }
    }
}
