using DemoSeguimientoDNT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSeguimientoDNT.Infrastructure.Persistence.Contexts.Configuration
{
    internal class SeguimientoConfiguration : IEntityTypeConfiguration<Seguimiento>
    {
        public void Configure(EntityTypeBuilder<Seguimiento> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("IdSeguimiento");

            builder.ToTable("Seguimiento");

            builder.Property(e => e.CodClasificacionNutricional)
                .HasMaxLength(2)
                .IsUnicode(false);
            builder.Property(e => e.CodLugarAtencion)
                .HasMaxLength(12)
                .IsUnicode(false);
            builder.Property(e => e.CodManejoActual)
                .HasMaxLength(2)
                .IsUnicode(false);
            builder.Property(e => e.CodTratamiento)
                .HasMaxLength(2)
                .IsUnicode(false);
            builder.Property(e => e.CodUbicacion)
                .HasMaxLength(2)
                .IsUnicode(false);
            builder.Property(e => e.Created).HasColumnType("datetime");
            builder.Property(e => e.DesManejo)
                .HasMaxLength(250)
                .IsUnicode(false);
            builder.Property(e => e.DesUbicacion)
                .HasMaxLength(250)
                .IsUnicode(false);
            builder.Property(e => e.FechaAtencion).HasColumnType("datetime");
            builder.Property(e => e.FechaDefuncion)
                .HasMaxLength(2)
                .IsUnicode(false);
            builder.Property(e => e.OtroTratamiento)
                .HasMaxLength(256)
                .IsUnicode(false);
            builder.Property(e => e.PesoKg).HasColumnType("decimal(5, 2)");
            builder.Property(e => e.TotalSobresFtlc).HasColumnName("TotalSobresFTLC");
            builder.Property(e => e.Updated).HasColumnType("datetime");

            builder.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Seguimientos)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seguimiento_Persona");
        }
    }
}
