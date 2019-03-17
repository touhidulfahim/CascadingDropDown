using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CascadingDropDownApp.Models
{
    [Table("CustomerAddress")]
    public class CustomerAddressModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerAddressId { get; set; }
        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        [Required]
        [Display(Name = "Current Country")]
        public int PresentCountryId { get; set; }
        [Required]
        [Display(Name = "Current Division")]
        public int PresentDivisionId { get; set; }
        [Required]
        [Display(Name = "Current District")]
        public int PresentDistrictId { get; set; }
        [Required]
        [Display(Name = "Current Upazila")]
        public int PresentUpazilaId { get; set; }
        [Required]
        [Display(Name = "Current Union")]
        public int PresentUnionParishadId { get; set; }
        [Required]
        [Display(Name = "Current Home")]
        public string PresentHome { get; set; }
        [Required]
        [Display(Name = "Current Road")]
        public string PresentRoadNo { get; set; }
        [Required]
        [Display(Name = "Current Area/Village")]
        public string PresentVillage { get; set; }
        [Required]
        [Display(Name = "Country")]
        public int PermanentCountryId { get; set; }
        [Required]
        [Display(Name = "Division")]
        public int PermanentDivisionId { get; set; }
        [Required]
        [Display(Name = "District")]
        public int PermanentDistrictId { get; set; }
        [Required]
        [Display(Name = "Upazila")]
        public int PermanentUpazillaId { get; set; }
        [Required]
        [Display(Name = "Union")]
        public int PermanentUnionParishadId { get; set; }
        [Required]
        [Display(Name = "Home")]
        public string PermanentHome { get; set; }
        [Required]
        [Display(Name = "Road No")]
        public string PermanentRoadNo { get; set; }
        [Required]
        [Display(Name = "Village/Area")]
        public string PermanentVillage { get; set; }
        [ForeignKey("PermanentDivisionId")]
        public virtual Division PermanentDivision { get; set; }
        [ForeignKey("PresentDivisionId")]
        public virtual Division PresentDivision { get; set; }
        [ForeignKey("PermanentDistrictId")]
        public virtual District PermanentDistrict { get; set; }
        [ForeignKey("PresentDistrictId")]
        public virtual District PresentDistrict { get; set; }
        [ForeignKey("PresentUpazilaId")]
        public virtual Upazila PresentUpazila { get; set; }
        [ForeignKey("PermanentUpazillaId")]
        public virtual Upazila PermanentUpazilla { get; set; }
        [ForeignKey("PresentUnionParishadId")]
        public virtual UnionParishad PresentUnionParishad { get; set; }
        [ForeignKey("PermanentUnionParishadId")]
        public virtual UnionParishad PermanentUnionParishad { get; set; }
        [ForeignKey("PresentCountryId")]
        public virtual Country PresentCountry { get; set; }
        [ForeignKey("PermanentCountryId")]
        public virtual Country PermanentCountry { get; set; }

    }
}