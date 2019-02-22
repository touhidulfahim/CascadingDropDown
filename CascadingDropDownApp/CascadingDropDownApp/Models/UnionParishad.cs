using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CascadingDropDownApp.Models
{
    public class UnionParishad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UnionParishadId { get; set; }

        [Required]
        [Display(Name = "Union Code")]
        [StringLength(5)]
        [Index(IsUnique = true)]
        [Remote("IsUnionCodeExists", "UnionParishad", HttpMethod = "POST", ErrorMessage = "Code already exists!")]
        public string UnionParishadCode { get; set; }

        [Required]
        [Display(Name = "Union Name")]
        [StringLength(50)]
        [Index(IsUnique = true)]
        [Remote("IsUnionNameExists", "UnionParishad", HttpMethod = "POST", ErrorMessage = "Name already exists!")]
        public string UnionParishadName { get; set; }

        [Required]
        [Display(Name = "Upazila")]
        public int UpazilaId { get; set; }

        [ForeignKey("UpazilaId")]
        public virtual Upazila Upazila { get; set; }
    }
}