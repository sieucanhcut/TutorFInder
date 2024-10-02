using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public class Invoice
    {
        [Key]
        [Required]
        public Guid InvoiceId { get; set; }
        public Guid? ContractId { get; set; }
        public Contract? Contract { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        [Required(ErrorMessage = "This field is required")]
        public decimal TimeGenerated {  get; set; }
        [Column(TypeName = "decimal(10,2)")]
        [Required(ErrorMessage = "This field is required")]
        public decimal InvoiceAmount { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        [Required(ErrorMessage = "This field is required")]
        public decimal Discount {  get; set; }
        [Column(TypeName = "nvarchar(256)")]
        [Required(ErrorMessage = "This field is required")]
        public string? ContractPaper {  get; set; }
        public DateTime TimeCharge { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        [Required(ErrorMessage = "This field is required")]
        public decimal AmountCharged {  get; set; }
        [Column(TypeName = "nvarchar(256)")]
        [Required(ErrorMessage = "This field is required")]
        public string? Note {  get; set; }
    }
}
