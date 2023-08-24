using DemoSeguimientoDNT.Domain.Entities;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Request;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Response;

namespace DemoSeguimientoDNT.Infrastructure.Persistence.Interfaces
{
    public interface IPersonaRepository : IGenericRepository<Persona>
    {
        Task<BaseEntityResponse<Persona>> ListaPersonas(BaseFiltersRequest filters);
        Task<IEnumerable<Persona>> GetPersonasByCodAseguradorAsync(string codAsegurador);
    }
}
