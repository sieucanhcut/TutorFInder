using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class StudentRequirement
    {
        public Guid? StudentId {  get; set; }
        public Guid? CourseId { get; set; }
        public StudentDetails? Student {  get; set; }
        public Course? Course { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required(ErrorMessage = "This field is required")]
        public string? Status { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
