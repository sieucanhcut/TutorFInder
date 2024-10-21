using Entities;
using Repositories;
using Repositories.Interfaces;

namespace Repositories.Implements
{
    internal class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(TutorWebContext dataContext) : base(dataContext) { }
    }
}
