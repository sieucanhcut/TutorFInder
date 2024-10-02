using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public class Location
    {
        [Required]
        [Key]
        public Guid LocationId {  get; set; }
        [Required(ErrorMessage ="This field is required")]
        [Column(TypeName ="nvarchar(50)")]
        public string? CityOrProvince {  get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "nvarchar(50)")]
        public string? District { get; set; }
        public DateTime? UpdateDate { get; set; }
        public ICollection<User>? _Users { get; set; }
    }
}
