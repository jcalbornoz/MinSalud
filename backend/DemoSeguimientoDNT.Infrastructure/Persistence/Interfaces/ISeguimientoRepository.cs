using DemoSeguimientoDNT.Domain.Entities;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Request;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Response;

namespace DemoSeguimientoDNT.Infrastructure.Persistence.Interfaces
{
    public interface ISeguimientoRepository : IGenericRepository<Seguimiento>
    {
        Task<BaseEntityResponse<Seguimiento>> ListaSeguimientos(BaseFiltersRequest filters);
        Task<IEnumerable<Seguimiento>> GetSeguimientosByIdPersonaAsync(int idPersona);
    }
}
