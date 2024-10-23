using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class RequestTutorDetails
    {
            public Guid UserId { get; set; }
            public Guid TutorId { get; set; }
            public string? Title { get; set; } // Undergraduated Student, Graduated Student, Teacher
            public string? Faculty { get; set; } // khoa
            public string? Transportation { get; set; }
            public bool? OnlineTutor { get; set; }
            public string? SelfIntroduction { get; set; } // tu gioi thieu
            public string? TeachingAchievement { get; set; } // thanh tich day hoc
            public string? AcademicSpecialty { get; set; } //diem noi bat
            public string? Photo { get; set; }  // anh
            public string? IncludingPhotos { get; set; }

            public string? UserName { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public string? PlaceOfWork { get; set; }
            public string? City { get; set; }
            public string? District { get; set; }
            public string? Gender { get; set; }
            public DateTime? UpdateDate { get; set; }
    }

}
