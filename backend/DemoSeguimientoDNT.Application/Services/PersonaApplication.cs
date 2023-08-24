using AutoMapper;
using DemoSeguimientoDNT.Application.Commons.Bases;
using DemoSeguimientoDNT.Application.DTOs.Persona.Request;
using DemoSeguimientoDNT.Application.DTOs.Persona.Response;
using DemoSeguimientoDNT.Application.Interfaces;
using DemoSeguimientoDNT.Domain.Entities;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Request;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Response;
using DemoSeguimientoDNT.Infrastructure.Persistence.Interfaces;

namespace DemoSeguimientoDNT.Application.Services
{
    public class PersonaApplication : IPersonaApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonaApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<BaseEntityResponse<PersonaResponseDto>>> ListaPersonas(BaseFiltersRequest baseFilters)
        {
            var response = new BaseResponse<BaseEntityResponse<PersonaResponseDto>>();

            var personas = await _unitOfWork.Persona.ListaPersonas(baseFilters);

            if (personas is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<PersonaResponseDto>>(personas);
                response.Message = "Consulta exitosa.";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "No se encontraron registros.";
            }


            return response;
        }

        public async Task<BaseResponse<IEnumerable<PersonaResponseDto>>> GetPersonasByCodAsegurador(string codAsegurador)
        {
            var response = new BaseResponse<IEnumerable<PersonaResponseDto>>();

            var personas = await _unitOfWork.Persona.GetPersonasByCodAseguradorAsync(codAsegurador);

            if (personas is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<PersonaResponseDto>>(personas);
                response.Message = "Consulta exitosa.";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "No se encontraron registros.";
            }


            return response;
        }

        public async Task<BaseResponse<bool>> RegisterPersonas(PersonaRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();

            var provider = _mapper.Map<Persona>(requestDto);

            response.Data = await _unitOfWork.Persona.RegisterAsync(provider);

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

        public async Task<BaseResponse<bool>> EditPersonas(int idPersona, PersonaRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();

            var personaById = await PersonaById(idPersona);

            if (personaById.Data is null)
            {
                response.IsSuccess = false;
                response.Message = "No se encontraron registros.";

                return response;
            }

            var persona = _mapper.Map<Persona>(requestDto);
            persona.Id = idPersona;
            response.Data = await _unitOfWork.Persona.EditAsync(persona);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Se actualizó correctamente.";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Operación fallida.";
            }

            return response;
        }

        private async Task<BaseResponse<PersonaResponseDto>> PersonaById(int idPersona)
        {
            var response = new BaseResponse<PersonaResponseDto>();

            var persona = await _unitOfWork.Persona.GetByIdAsync(idPersona);

            if (persona is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<PersonaResponseDto>(persona);
                response.Message = "Consulta exitosa.";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "No se encontraron registros.";
            }

            return response;
        }

        public Task<BaseResponse<bool>> RemovePersonas(int idPersona)
        {
            throw new NotImplementedException();
        }
    }
}
