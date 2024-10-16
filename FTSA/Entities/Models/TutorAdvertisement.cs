using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TutorAdvertisement
    {
        [Key]
        [Required]
        public Guid AdvertisementId { get; set; }
        public TutorDetails? Tutor {  get; set; }
        public Guid? TutorId {  get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required(ErrorMessage = "This field is required")]
        public string? Description {  get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required(ErrorMessage = "This field is required")]
        public string? Media {  get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
