using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public class Course
    {
        [Key]
        [Required]
        public Guid CourseId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This field is required")]
        public string? CourseName { get; set; }
        public ICollection<StudyCourse>? _StudyingCourses { get; set; }
        public ICollection<TutionFeeSchedule>? _TutionFeeSchedules { get; set; } 
        public ICollection<StudentRequirement>? _StudentRequirements { get; set; }
    }
}
