using DataAccess.dbContext_Access;
using Entities;
using Repositories;

namespace Repositories.Implements
{
    internal class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(TutorWebContext dataContext) : base(dataContext) { }
    }
}
