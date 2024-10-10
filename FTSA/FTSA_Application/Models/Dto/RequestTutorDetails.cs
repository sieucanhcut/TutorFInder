using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FTSA_Application.Models.Dto
{
    public class RequestTutorDetails
    {
        public string? Title { get; set; } // Undergraduated Student, Graduated Student, Teacher
        public string? Faculty { get; set; } // khoa
        public string? Transportation { get; set; }
        public bool? OnlineTutor { get; set; }
        public string? SelfIntroduction { get; set; } // tu gioi thieu
        public string? TeachingAchievement { get; set; } // thanh tich day hoc
        public string? AcademicSpecialty { get; set; } //diem noi bat
        public string? Photo { get; set; }  // anh
        public string? IncludingPhotos { get; set; }
    }
}
