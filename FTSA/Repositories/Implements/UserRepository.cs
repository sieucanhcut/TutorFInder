using DataAccess.dbContext_Access;
using Entities;
using Repositories.Interfaces;

namespace Repositories.Implements
{
    internal class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(TutorWebContext dataContext) : base(dataContext) { }
    }
}
