using DemoSeguimientoDNT.Infrastructure.Persistence.Contexts;
using DemoSeguimientoDNT.Infrastructure.Persistence.Interfaces;

namespace DemoSeguimientoDNT.Infrastructure.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DemoSeguimientoContext _context;
        public IPersonaRepository Persona { get; private set; }
        public ISeguimientoRepository Seguimiento { get; private set; }
        public IReporteRepository Reporte { get; private set; }

        public UnitOfWork(DemoSeguimientoContext context)
        {
            _context = context;
            Persona = new PersonaRepository(_context);
            Seguimiento = new SeguimientoRepository(_context);
            Reporte = new ReporteRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
