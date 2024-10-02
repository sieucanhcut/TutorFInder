using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public class TutionFeeSchedule
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(50)")]
        public string? Grade {  get; set; }
        public float FeePerPeriod { get; set; } // nghin dong

        public Guid? TutorId { get; set; }
        public TutorDetails? Tutor { get; set; }
        public Course? Course { get; set; }
        public Guid? CourseId { get; set; }
    }
}
