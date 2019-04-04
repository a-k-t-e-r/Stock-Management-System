using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Stock_Management_System.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(("CompanyId"))]
        public Company Company { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Record Level")]
        [Column(TypeName = "decimal")]
        public decimal RecordLevel { get; set; }
    }
}