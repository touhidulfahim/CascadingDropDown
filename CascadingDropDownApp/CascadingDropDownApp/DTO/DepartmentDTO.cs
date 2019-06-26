using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CascadingDropDownApp.DTO
{
    public class DepartmentDTO
    {
        public int DepartmentId { get; set; }
        [Required]
        [MinLength(2,ErrorMessage = "Min lenght is 2!")]
        [MaxLength(5,ErrorMessage = "Max lenght is 5!")]
        public string DepartmentCode { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Max lenght is 5!")]
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfEntry { get; set; }
    }
}