using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public class Feedback
    {
        [Key]
        [Required]
        public Guid FeddbackId { get; set; }
        public User? Commenter { get; set; }
        public Guid? CommenterId { get; set; }
        public User? Receiver { get; set; }
        public Guid? ReceiverId { get; set; }
        public Guid? FreeCourseId { get; set; }
        public FreeCourse? FreeCourse { get; set; }
        [Required(ErrorMessage ="Please insert your comments before you post.")]
        [Column(TypeName ="nvarchar(256)")]
        public string? Message {  get; set; }
        public DateTime? PostDate { get; set; }
        public TutorDetails? Tutor { get; set; }
        public Guid? TutorId { get; set; }
    }
}
