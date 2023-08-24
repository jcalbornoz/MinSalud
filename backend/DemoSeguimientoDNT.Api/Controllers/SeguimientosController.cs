using DemoSeguimientoDNT.Application.DTOs.Seguimiennto.Request;
using DemoSeguimientoDNT.Application.Interfaces;
using DemoSeguimientoDNT.Application.Services;
using DemoSeguimientoDNT.Domain.Entities;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoSeguimientoDNT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguimientosController : ControllerBase
    {
        private readonly ISeguimientoApplication _seguimientoApplication;

        public SeguimientosController(ISeguimientoApplication seguimientoApplication)
        {
            _seguimientoApplication = seguimientoApplication;
        }

        [HttpPost("ConsultarSeguimientos")]
        public async Task<IActionResult> ConsultarSeguimientos()
        {
            var response = await _seguimientoApplication.ConsultarSeguimientos();
            return Ok(response);
        }
        
        [HttpPost("ListarSeguimientos")]
        public async Task<IActionResult> ListaSeguimientos([FromBody] BaseFiltersRequest filters)
        {
            var response = await _seguimientoApplication.ListaSeguimientos(filters);
            return Ok(response);
        }

        [HttpGet("ConsultarSeguimientoPorPersona")]
        public async Task<IActionResult> ByIdPersona(int idPersona)
        {
            var response = await _seguimientoApplication.ObtenerSeguimiento(idPersona);
            return Ok(response);
        }

        [HttpPost("RegistrarSeguimientos")]
        public async Task<IActionResult> RegistrarSeguimiento([FromBody] SeguimientoRequestDto requestDto)
        {
            var response = await _seguimientoApplication.RegistrarSeguimiento(requestDto);
            return Ok(response);
        }
    }
}
