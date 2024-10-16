using DataAccess.dbContext_Access;
using Entities;
using Repositories.Interfaces;

namespace Repositories.Implements
{
    internal class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(TutorWebContext dataContext) : base(dataContext) { }
    }
}
