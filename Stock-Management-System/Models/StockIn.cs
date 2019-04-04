using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Stock_Management_System.Models
{
    public class StockIn
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        [Column(TypeName = "decimal")]
        public decimal RecorderLevel { get; set; }

        [Column(TypeName = "decimal")]
        [Required]
        public decimal AvailableQuantity { get; set; }

        [Required]
        [Column(TypeName = "decimal")]
        public decimal StockInQuantity { get; set; }
    }
}