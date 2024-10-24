using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(TutorWebContext context) : base(context) { }

        public async Task<IEnumerable<Event>> FindAllAsync()
        {
            return await FindAll(false).ToListAsync();
        }

        public async Task<Event> GetByIdAsync(Guid eventId)
        {
            return await FindByCondition(e => e.EventId == eventId, false).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Event entity)
        {
            await _context.Set<Event>().AddAsync(entity);
        }

        public async Task UpdateAsync(Event entity)
        {
            _context.Set<Event>().Update(entity);
        }

        public async Task DeleteAsync(Guid eventId)
        {
            var entity = await GetByIdAsync(eventId);
            if (entity != null)
            {
                Delete(entity);
            }
        }
    }
}
