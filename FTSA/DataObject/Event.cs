using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public class Event
    {
        [Key]
        [Required]
        public Guid EventId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This field is required")]
        public string? Title { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This field is required")]
        public string? Description { get; set; }
        public Guid? AdminId { get; set; }
        public User? Admin { get; set; }
    }
}
