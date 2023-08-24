using DemoSeguimientoDNT.Application.DTOs.Persona.Request;
using DemoSeguimientoDNT.Application.Interfaces;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Request;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoSeguimientoDNT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaApplication _personaApplication;

        public PersonasController(IPersonaApplication personaApplication)
        {
            _personaApplication = personaApplication;
        }

        [HttpPost("ListadoPersonas")]
        public async Task<IActionResult> ListaPersonas([FromBody] BaseFiltersRequest filters)
        {
            var response = await _personaApplication.ListaPersonas(filters);
            return Ok(response);
        }

        [HttpGet("ConsultarPorCodigoAsegurador")]
        public async Task<IActionResult> ByCodAsegurador(string codAsegurador)
        {
            var response = await _personaApplication.GetPersonasByCodAsegurador(codAsegurador);
            return Ok(response);
        }

        [HttpPost("RegistrarPersonas")]
        public async Task<IActionResult> RegistrarPersona([FromBody] PersonaRequestDto personaRequestDto)
        {
            var response = await _personaApplication.RegisterPersonas(personaRequestDto);
            return Ok(response);
        }

        [HttpPut("EditarPersonas")]
        public async Task<IActionResult> EditarPersona(int idPErsona, [FromBody] PersonaRequestDto personaRequestDto)
        {
            var response = await _personaApplication.EditPersonas(idPErsona, personaRequestDto);
            return Ok(response);
        }
    }
}
