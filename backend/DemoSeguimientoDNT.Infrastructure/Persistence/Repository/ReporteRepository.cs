using DemoSeguimientoDNT.Domain.Entities;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Response;
using DemoSeguimientoDNT.Infrastructure.Persistence.Contexts;
using DemoSeguimientoDNT.Infrastructure.Persistence.Interfaces;

namespace DemoSeguimientoDNT.Infrastructure.Persistence.Repository
{
    public class ReporteRepository : GenericRepository<Reporte>, IReporteRepository
    {
        private readonly DemoSeguimientoContext _context;

        public ReporteRepository(DemoSeguimientoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BaseEntityResponse<Reporte>> ConsultarSeguimientos()
        {
            var response = new BaseEntityResponse<Reporte>();

            var seguimientosPersonas = (from p in _context.Personas
                                        join s in _context.Seguimientos on p.Id equals s.IdPersona into ps
                                        from s in ps.DefaultIfEmpty()
                                        select new Reporte
                                        {
                                            IdPersona = p.Id,
                                            TipoIdentificacion = p.TipoIdentificacion,
                                            NroIdentificacion = p.NroIdentificacion,
                                            NombresApellidos = $"{p.PrimerNombre} {p.SegundoNombre} {p.PrimerApellido} {p.SegundoApellido}",
                                            Upgd = s.CodLugarAtencion,
                                            FechaAtencion = s.FechaAtencion,
                                            Asegurador = p.CodAsegurador,
                                            FechaDefunsion = s.FechaDefuncion,
                                            UltimoSeguimiento = s.Updated
                                        }
            ).ToList();

            response.TotalRecords = seguimientosPersonas!.Count;
            response.Items = seguimientosPersonas!.ToList();
            
            return response;
        }

        public Task<BaseEntityResponse<Reporte>> ExportarSeguimientos()
        {
            throw new NotImplementedException();
        }
    }
}
