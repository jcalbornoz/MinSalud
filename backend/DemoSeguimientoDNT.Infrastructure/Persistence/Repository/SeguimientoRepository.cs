using DemoSeguimientoDNT.Domain.Entities;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Request;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Response;
using DemoSeguimientoDNT.Infrastructure.Persistence.Contexts;
using DemoSeguimientoDNT.Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoSeguimientoDNT.Infrastructure.Persistence.Repository
{
    public class SeguimientoRepository : GenericRepository<Seguimiento>, ISeguimientoRepository
    {
        private readonly DemoSeguimientoContext _context;

        public SeguimientoRepository(DemoSeguimientoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Seguimiento>> GetSeguimientosByIdPersonaAsync(int idPersona)
        {
            var seguimientosByIdPersonas = await _context.Seguimientos
                .Where(x => x.IdPersona.Equals(idPersona))
                .AsNoTracking()
                .ToListAsync();

            return seguimientosByIdPersonas;
        }

        public async Task<BaseEntityResponse<Seguimiento>> ListaSeguimientos(BaseFiltersRequest filtersRequest)
        {
            var response = new BaseEntityResponse<Seguimiento>();

            var seguimientos = GetEntityQuery().AsNoTracking();

            filtersRequest.Sort ??= "Id";

            response.TotalRecords = await seguimientos!.CountAsync();
            response.Items = await Ordering(filtersRequest, seguimientos!, !(bool)filtersRequest.Download!).ToListAsync();
            return response;
        }
    }
}
