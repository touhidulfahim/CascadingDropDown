using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CascadingDropDownApp.Models
{
    public class CategoryModels
    {
        [Key]
        public Guid ItemCategoryID { get; set; }
        public string ItemCategoryName { get; set; }
        public string ShortName { get; set; }
        public Nullable<Guid> ParentCategoryID { get; set; }

        [ForeignKey("ParentCategoryID")]
        public virtual CategoryModels Categories { get; set; }
        
    }
}