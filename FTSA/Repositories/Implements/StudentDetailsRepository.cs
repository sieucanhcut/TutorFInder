using DataAccess.dbContext_Access;
using Entities;
using Repositories.Interfaces;

namespace Repositories.Implements
{
    internal class StudentDetailsRepository : RepositoryBase<StudentDetails>, IStudentDetailsRepository
    {
        public StudentDetailsRepository(TutorWebContext dataContext) : base(dataContext) { }
    }
}
