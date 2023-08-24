using AutoMapper;
using DemoSeguimientoDNT.Application.Commons.Bases;
using DemoSeguimientoDNT.Application.DTOs.Persona.Response;
using DemoSeguimientoDNT.Application.DTOs.Reporte.Response;
using DemoSeguimientoDNT.Application.DTOs.Seguimiennto.Request;
using DemoSeguimientoDNT.Application.DTOs.Seguimiennto.Response;
using DemoSeguimientoDNT.Application.Interfaces;
using DemoSeguimientoDNT.Domain.Entities;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Request;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Response;
using DemoSeguimientoDNT.Infrastructure.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSeguimientoDNT.Application.Services
{
    public class SeguimientoApplication : ISeguimientoApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SeguimientoApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<SeguimientoResponseDto>>> ObtenerSeguimiento(int idPersona)
        {
            var response = new BaseResponse<IEnumerable<SeguimientoResponseDto>>();

            var seguimiento = await _unitOfWork.Seguimiento.GetSeguimientosByIdPersonaAsync(idPersona);

            if (seguimiento is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<SeguimientoResponseDto>>(seguimiento);
                response.Message = "Consulta exitosa.";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "No se encontraron registros.";
            }

            return response;
        }

        public async Task<BaseResponse<BaseEntityResponse<SeguimientoResponseDto>>> ListaSeguimientos(BaseFiltersRequest baseFilters)
        {
            var response = new BaseResponse<BaseEntityResponse<SeguimientoResponseDto>>();

            var personas = await _unitOfWork.Seguimiento.ListaSeguimientos(baseFilters);

            if (personas is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<SeguimientoResponseDto>>(personas);
                response.Message = "Consulta exitosa.";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "No se encontraron registros.";
            }


            return response;
        }

        public async Task<BaseResponse<bool>> RegisterSeguimiento(SeguimientoRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();

            var seguimiento = _mapper.Map<Seguimiento>(requestDto);
            response.Data = await _unitOfWork.Seguimiento.RegisterAsync(seguimiento);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Se registró correctamente.";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Operación fallida.";
            }

            return response;
        }

        public async Task<BaseResponse<bool>> RegistrarSeguimiento(SeguimientoRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();

            var seguimiento = _mapper.Map<Seguimiento>(requestDto);

            response.Data = await _unitOfWork.Seguimiento.RegisterAsync(seguimiento);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Se registró correctamente.";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Operación fallida.";
            }


            return response;
        }

        public async Task<BaseResponse<BaseEntityResponse<ReporteResponseDto>>> ConsultarSeguimientos()
        {
            var response = new BaseResponse<BaseEntityResponse<ReporteResponseDto>>();

            var seguimiento = await _unitOfWork.Reporte.ConsultarSeguimientos();

            if (seguimiento is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<ReporteResponseDto>>(seguimiento);
                response.Message = "Consulta exitosa.";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "No se encontraron registros.";
            }

            return response;
        }
    }
}
