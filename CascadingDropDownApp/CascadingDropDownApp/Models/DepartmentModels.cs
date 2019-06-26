using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CascadingDropDownApp.Models
{
    [Table("hr_Departments")]
    public class DepartmentModels
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(10)]
        [Index(IsUnique = true)]
        public string DepartmentCode { get; set; }

        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateOfEntry { get; set; }
    }
}