using AutoMapper;
using DemoSeguimientoDNT.Application.DTOs.Reporte.Response;
using DemoSeguimientoDNT.Application.DTOs.Seguimiennto.Request;
using DemoSeguimientoDNT.Application.DTOs.Seguimiennto.Response;
using DemoSeguimientoDNT.Domain.Entities;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Response;

namespace DemoSeguimientoDNT.Application.Mappers
{
    public class SeguimientoMappingProfile : Profile
    {
        public SeguimientoMappingProfile()
        {
            CreateMap<Seguimiento, SeguimientoResponseDto>()
                .ForMember(x => x.IdSeguimiento, x => x.MapFrom(y => y.Id))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Seguimiento>, BaseEntityResponse<SeguimientoResponseDto>>()
                .ReverseMap();
            

            CreateMap<SeguimientoRequestDto, Seguimiento>()
                .ReverseMap();

            CreateMap<Reporte, ReporteResponseDto>()
                .ReverseMap();

            CreateMap<BaseEntityResponse<Reporte>, BaseEntityResponse<ReporteResponseDto>>()
                .ReverseMap();
        }
    }
}
