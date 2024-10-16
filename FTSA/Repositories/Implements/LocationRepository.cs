using DataAccess.dbContext_Access;
using Entities;
using Repositories.Interfaces;

namespace Repositories.Implements
{
    internal class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(TutorWebContext dataContext) : base(dataContext) { }
    }
}
