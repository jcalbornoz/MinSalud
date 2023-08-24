using DemoSeguimientoDNT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DemoSeguimientoDNT.Infrastructure.Persistence.Contexts;

public partial class DemoSeguimientoContext : DbContext
{
    public DemoSeguimientoContext()
    {
    }

    public DemoSeguimientoContext(DbContextOptions<DemoSeguimientoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Seguimiento> Seguimientos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
