using DemoSeguimientoDNT.Domain.Entities;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Request;
using DemoSeguimientoDNT.Infrastructure.Helpers;
using DemoSeguimientoDNT.Infrastructure.Persistence.Contexts;
using DemoSeguimientoDNT.Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace DemoSeguimientoDNT.Infrastructure.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DemoSeguimientoContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(DemoSeguimientoContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var getAll = await _entity
                .AsNoTracking()
                .ToListAsync();

            return getAll;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var getById = await _entity!
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            return getById!;
        }

        public async Task<bool> RegisterAsync(T entity)
        {
            entity.Created = DateTime.Now;
            entity.Updated = DateTime.Now;

            _ = await _context.AddAsync(entity);

            int recordAffected = await _context.SaveChangesAsync();
            return recordAffected > 0;
        }

        public async Task<bool> EditAsync(T entity)
        {
            entity.Updated = DateTime.Now;

            _ = _context.Update(entity);
            _context.Entry(entity).Property(x => x.Created).IsModified = false;

            int recordAffected = await _context.SaveChangesAsync();
            return recordAffected > 0;
        }

        public Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _entity;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

        public IQueryable<TDTOs> Ordering<TDTOs>(BasePaginationRequest request, IQueryable<TDTOs> queryable, bool pagination = false) where TDTOs : class
        {
            IQueryable<TDTOs> queryDTOs = request.Order == "desc" ? queryable.OrderBy($"{request.Sort} descending") : queryable.OrderBy($"{request.Sort} ascending");

            if (pagination)
            {
                queryDTOs = queryDTOs.Paginate(request);
            }

            return queryDTOs;
        }
    }
}
