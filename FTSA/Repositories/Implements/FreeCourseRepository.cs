﻿using Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class FreeCourseRepository : RepositoryBase<FreeCourse>, IFreeCourseRepository
    {
        public FreeCourseRepository(TutorWebContext dataContext) : base(dataContext)
        {
        }
    }
}
