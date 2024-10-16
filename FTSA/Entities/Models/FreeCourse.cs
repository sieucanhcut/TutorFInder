using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FreeCourse
    {
        [Key]
        [Required]
        public Guid FreeCourseId { get; set; }
        public TutorDetails? Tutor {  get; set; }
        public Guid? TutorId { get; set; }
        public ICollection<Feedback>? _Feedbacks { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        [Required(ErrorMessage = "This field is required")]
        public string? Description {  get; set; }
        [Column(TypeName = "nvarchar(256)")]
        [Required(ErrorMessage = "This field is required")]
        public string? Media {  get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
