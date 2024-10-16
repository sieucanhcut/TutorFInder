using DataAccess.dbContext_Access;
using Entities;
using Repositories.Interfaces;

namespace Repositories.Implements
{
    internal class TutorDetailsRepository : RepositoryBase<TutorDetails>, ITutorDetailsRepository
    {
        public TutorDetailsRepository(TutorWebContext dataContext) : base(dataContext) { }
    }
}
