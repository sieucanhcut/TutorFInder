using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class User
    {
        [Key]
        [Required]
        public Guid UserId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This field is required")]
        public string? UserName { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Required(ErrorMessage = "This field is required")]
        public string? Password { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This field is required")]
        public string? Gender { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This field is required")]
        [EmailAddress]
        public string? Email { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This field is required")]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Phone]
        public string? PhoneNumber2 { get; set; }
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpiry { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This field is required")]
        public string? PlaceOfWork { get; set; }

        public string? CitizenId { get; set; }

        public bool IsEmailConfirmed { get; set; } = false; 

        public StudentDetails? _Student { get; set; }
        public TutorDetails? _Tutor { get; set; }
        public Role? Role { get; set; }
        public Guid RoleId { get; set; }
        public Guid? LocationId { get; set; }
        public Location? Location { get; set; }
        public ICollection<Event>? _Events { get; set; }
        public ICollection<Feedback>? _Feedbacks { get; set; }
        public ICollection<Feedback>? _FeedbacksAbout { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
