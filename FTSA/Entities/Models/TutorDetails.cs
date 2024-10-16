using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TutorDetails
    {
        [Key]
        [Required]
        public Guid TutorId { get; set; }
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(50)")]
        public string? Title { get; set; } // Undergraduated Student, Graduated Student, Teacher
        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(50)")]
        public string? Faculty {get; set; } // khoa
        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(50)")]
        public string? Transportation {  get; set; }
        public bool? OnlineTutor { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(500)")]
        public string? SelfIntroduction {  get; set; } // tu gioi thieu
        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(500)")]
        public string? TeachingAchievement { get; set; } // thanh tich day hoc
        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(200)")]
        public string? AcademicSpecialty {  get; set; } //diem noi bat
        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(50)")]
        public string? Photo {  get; set; }  // anh
        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(50)")]
        public string? IncludingPhotos {  get; set; } // cac anh dinh kem
        public User? User { get; set; }
        public ICollection<TutionFeeSchedule>? _tutionFeeSchedules { get; set; }
        public ICollection<Contract>? Contacts {  get; set; }
        public ICollection<FreeCourse>? _FreeCourse { get; set; }
        public ICollection<Feedback>? _FeedbacksAbout { get; set; }
        public ICollection<TutorAdvertisement>? _TutorAdvertisements { get; set; }
    }
}
