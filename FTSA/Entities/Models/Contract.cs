using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Contract
    {
        [Required]
        [Key]
        public Guid ContractId{ get; set; }
        public Guid? StudentId { get; set; }
        public Guid? TutorId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This field is required")]
        public string? ContractTitle { get; set; }
        public TutorDetails? Tutor {get; set; }
        public StudentDetails? Student { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime? SignDate { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required(ErrorMessage = "This field is required")]
        public string? ContractPaper { get; set; } 
        public Invoice? Invoice { get; set; }
    }
}
