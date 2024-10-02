using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public class StudentDetails
    {
        [Key]
        [Required]
        public Guid StudentId { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [Column(TypeName ="nvarchar(50)")]
        public string? Grade { get; set; }
        public Guid? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Contract>? Contacts { get; set; }
        public ICollection<StudyCourse>? _StudyingCourses { get; set; }
        public ICollection<StudentRequirement>? _StudentRequirements { get; set; }
    }
}
