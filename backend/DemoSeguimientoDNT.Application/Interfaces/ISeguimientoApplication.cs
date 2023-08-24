using DemoSeguimientoDNT.Application.Commons.Bases;
using DemoSeguimientoDNT.Application.DTOs.Reporte.Response;
using DemoSeguimientoDNT.Application.DTOs.Seguimiennto.Request;
using DemoSeguimientoDNT.Application.DTOs.Seguimiennto.Response;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Request;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Response;

namespace DemoSeguimientoDNT.Application.Interfaces
{
    public interface ISeguimientoApplication
    {
        // Consultar Seguimientos
        Task<BaseResponse<BaseEntityResponse<SeguimientoResponseDto>>> ListaSeguimientos(BaseFiltersRequest baseFilters);
        Task<BaseResponse<IEnumerable<SeguimientoResponseDto>>> ObtenerSeguimiento(int idPersona);
        Task<BaseResponse<BaseEntityResponse<ReporteResponseDto>>> ConsultarSeguimientos();

        // Crear Seguimientos
        Task<BaseResponse<bool>> RegistrarSeguimiento(SeguimientoRequestDto requestDto);

        // Exportar Seguimientos
    }
}
