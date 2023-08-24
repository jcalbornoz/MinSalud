using DemoSeguimientoDNT.Application.Commons.Bases;
using DemoSeguimientoDNT.Application.DTOs.Persona.Request;
using DemoSeguimientoDNT.Application.DTOs.Persona.Response;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Request;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Response;

namespace DemoSeguimientoDNT.Application.Interfaces
{
    public interface IPersonaApplication
    {
        // Consultar Personas
        Task<BaseResponse<BaseEntityResponse<PersonaResponseDto>>> ListaPersonas(BaseFiltersRequest baseFilters);
        Task<BaseResponse<IEnumerable<PersonaResponseDto>>> GetPersonasByCodAsegurador(string codAsegurador);
        
        // Crear Personas
        Task<BaseResponse<bool>> RegisterPersonas(PersonaRequestDto requestDto);
        
        // Actualizar Personas
        Task<BaseResponse<bool>> EditPersonas(int idPersona, PersonaRequestDto requestDto);
    }
}
