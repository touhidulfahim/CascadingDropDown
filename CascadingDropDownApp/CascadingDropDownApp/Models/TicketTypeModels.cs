using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CascadingDropDownApp.Models
{
    public class TicketTypeModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TicketTypeId { get; set; }
        public string TicketTypeName { get; set; }
        public string Description { get; set; }
    }
}