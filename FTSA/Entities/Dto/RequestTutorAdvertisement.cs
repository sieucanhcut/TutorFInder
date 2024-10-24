using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class RequestTutorAdvertisement
    {
        public Guid AdvertisementId { get; set; }
        public Guid? TutorId { get; set; }
        public string? Description { get; set; }
        public string? Media { get; set; }
        public string? Title { get; set; } // Undergraduated Student, Graduated Student, Teacher
        public string? Faculty { get; set; } // khoa
        public bool? OnlineTutor { get; set; }
        public string? Photo { get; set; }  // anh
        public string? UserName { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
    }
}
