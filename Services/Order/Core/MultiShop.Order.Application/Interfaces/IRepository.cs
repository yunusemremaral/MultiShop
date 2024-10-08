using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Interfaces
{
    public interface IRepository<T>  where T : class
    {
        Task<List<T>> GetAllAsync();   // genel işlemler
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T Entity);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task GetByIdAsync(GetAddressByIdQuery query);
    }
}
