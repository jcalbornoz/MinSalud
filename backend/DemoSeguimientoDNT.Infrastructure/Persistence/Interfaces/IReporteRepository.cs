using DemoSeguimientoDNT.Domain.Entities;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Request;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Response;

namespace DemoSeguimientoDNT.Infrastructure.Persistence.Interfaces
{
    public interface IReporteRepository : IGenericRepository<Reporte>
    {
        Task<BaseEntityResponse<Reporte>> ConsultarSeguimientos();
        Task<BaseEntityResponse<Reporte>> ExportarSeguimientos();
    }
}
