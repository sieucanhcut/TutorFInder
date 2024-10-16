using DataAccess.dbContext_Access;
using Entities;
using Entities.Models;
using Repositories.Interfaces;

namespace Repositories.Implements
{
    public class StudyCourseRepository : RepositoryBase<StudyCourse>, IStudyCourseRepository
    {
        public StudyCourseRepository(TutorWebContext dataContext) : base(dataContext)
        {
        }

    }
}
