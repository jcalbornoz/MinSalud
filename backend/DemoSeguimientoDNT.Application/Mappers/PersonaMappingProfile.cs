using AutoMapper;
using DemoSeguimientoDNT.Application.DTOs.Persona.Request;
using DemoSeguimientoDNT.Application.DTOs.Persona.Response;
using DemoSeguimientoDNT.Domain.Entities;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Response;

namespace DemoSeguimientoDNT.Application.Mappers
{
    public class PersonaMappingProfile : Profile
    {
        public PersonaMappingProfile()
        {
            CreateMap<Persona, PersonaResponseDto>()
                .ForMember(x => x.IdPersona, x => x.MapFrom(y => y.Id))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Persona>, BaseEntityResponse<PersonaResponseDto>>()
                .ReverseMap();

            CreateMap<PersonaRequestDto, Persona>()
                .ReverseMap();
        }
    }
}
