using Entities;
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
