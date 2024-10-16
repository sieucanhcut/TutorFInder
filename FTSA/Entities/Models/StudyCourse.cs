using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class StudyCourse
    {
        public Guid? CourseId { get; set; }
        public Course? Course { get; set; }
        public Guid? StudentId { get; set; }
        public StudentDetails? Student {  get; set; }
    }
}
