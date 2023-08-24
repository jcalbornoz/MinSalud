using DemoSeguimientoDNT.Domain.Entities;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Request;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Response;
using DemoSeguimientoDNT.Infrastructure.Persistence.Contexts;
using DemoSeguimientoDNT.Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoSeguimientoDNT.Infrastructure.Persistence.Repository
{
    public class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {
        private readonly DemoSeguimientoContext _context;

        public PersonaRepository(DemoSeguimientoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Persona>> GetPersonasByCodAseguradorAsync(string codAsegurador)
        {
            var personasByCodAsegurador = await _context.Personas
                .Where(x => x.CodAsegurador == codAsegurador)
                .AsNoTracking()
                .ToListAsync();

            return personasByCodAsegurador;
        }

        public async Task<BaseEntityResponse<Persona>> ListaPersonas(BaseFiltersRequest filtersRequest)
        {
            var response = new BaseEntityResponse<Persona>();

            var personas = GetEntityQuery()
                .AsNoTracking();

            if (filtersRequest.NumFilter is not null && !string.IsNullOrEmpty(filtersRequest.TextFilter))
            {
                switch (filtersRequest.NumFilter)
                {
                    case 1:
                        personas = personas?.Where(x => x.PrimerNombre.Contains(filtersRequest.TextFilter));
                        break;
                    case 2:
                        personas = personas?.Where(x => x.PrimerApellido.Contains(filtersRequest.TextFilter));
                        break;
                }
            }

            filtersRequest.Sort ??= "Id";

            response.TotalRecords = await personas!.CountAsync();
            response.Items = await Ordering(filtersRequest, personas!, !(bool)filtersRequest.Download!).ToListAsync();
            return response;
        }
    }
}
