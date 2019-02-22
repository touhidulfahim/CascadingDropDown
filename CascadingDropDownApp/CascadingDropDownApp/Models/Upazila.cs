using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CascadingDropDownApp.Models
{
    public class Upazila
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UpazilaId { get; set; }

        [Required(ErrorMessage = "Please select District!")]
        [Display(Name = "Disctrict")]
        public int DistrictId { get; set; }

        [Required(ErrorMessage = "Please input upazila code!")]
        [Display(Name = "Upazila Code")]
        [StringLength(5)]
        [Index(IsUnique = true)]
        [Remote("IsUpazilaCodeExists", "Upazila", HttpMethod = "POST", ErrorMessage = "Police upazila code already exists!")]
        public string UpazilaCode { get; set; }

        [Required(ErrorMessage = "Please input upazila code!")]
        [Display(Name = "Police station name")]
        [StringLength(50)]
        [Index(IsUnique = true)]
        [Remote("IsUpazilaNameExists", "Upazila", HttpMethod = "POST", ErrorMessage = "Police upazila name already exists!")]
        public string UpazilaName { get; set; }

        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }
        public virtual List<UnionParishad> UnionParishads { get; set; }
    }
}