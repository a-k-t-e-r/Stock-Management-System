using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Stock_Management_System.Models
{
    public class SearchAndViewItemsSummary
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}