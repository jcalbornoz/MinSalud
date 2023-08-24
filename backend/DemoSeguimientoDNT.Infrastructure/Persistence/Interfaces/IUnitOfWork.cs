namespace DemoSeguimientoDNT.Infrastructure.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonaRepository Persona { get; }
        ISeguimientoRepository Seguimiento { get; }
        IReporteRepository Reporte { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
