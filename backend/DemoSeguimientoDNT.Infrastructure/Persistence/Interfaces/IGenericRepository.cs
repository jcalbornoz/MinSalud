using DemoSeguimientoDNT.Domain.Entities;
using DemoSeguimientoDNT.Infrastructure.Commons.Bases.Request;
using System.Linq.Expressions;

namespace DemoSeguimientoDNT.Infrastructure.Persistence.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> RegisterAsync(T entity);
        Task<bool> EditAsync(T entity);
    }
}
