using Entities;
using Repositories.Intefaces;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    internal class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        
        public CourseRepository(TutorWebContext dataContext) : base(dataContext)
        {

        }
    }
}
