using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> FindAllAsync();
        Task<Event> GetByIdAsync(Guid eventId); // Thêm phương thức này
        Task CreateAsync(Event entity);
        Task UpdateAsync(Event entity);
        Task DeleteAsync(Guid eventId);
        IQueryable<Event> FindByCondition(Expression<Func<Event, bool>> expression, bool trackChanges);
    }
}
