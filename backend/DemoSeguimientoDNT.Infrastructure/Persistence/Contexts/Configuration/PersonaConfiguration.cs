using DemoSeguimientoDNT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoSeguimientoDNT.Infrastructure.Persistence.Contexts.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("IdPersona");

            builder.ToTable("Persona");

            builder.Property(e => e.CodAsegurador)
                .HasMaxLength(6)
                .IsUnicode(false);
            builder.Property(e => e.CodMpioResidencia)
                .HasMaxLength(5)
                .IsUnicode(false);
            builder.Property(e => e.Created).HasColumnType("datetime");
            builder.Property(e => e.FechaNacimiento).HasColumnType("date");
            builder.Property(e => e.NroIdentificacion)
                .HasMaxLength(17)
                .IsUnicode(false);
            builder.Property(e => e.PrimerApellido)
                .HasMaxLength(60)
                .IsUnicode(false);
            builder.Property(e => e.PrimerNombre)
                .HasMaxLength(60)
                .IsUnicode(false);
            builder.Property(e => e.SegundoApellido)
                .HasMaxLength(60)
                .IsUnicode(false);
            builder.Property(e => e.SegundoNombre)
                .HasMaxLength(60)
                .IsUnicode(false);
            builder.Property(e => e.Sexo)
                .HasMaxLength(2)
                .IsUnicode(false);
            builder.Property(e => e.TipoIdentificacion)
                .HasMaxLength(2)
                .IsUnicode(false);
            builder.Property(e => e.Updated).HasColumnType("datetime");
        }
    }
}
