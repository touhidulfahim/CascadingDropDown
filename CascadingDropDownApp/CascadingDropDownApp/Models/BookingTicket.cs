using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CascadingDropDownApp.Models
{
    public class BookingTicket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingTicketId { get; set; }

        public string PassengerName { get; set; }
        public string Mobile { get; set; }
        public DateTime BookingDate { get; set; }

        public int TransferFrom { get; set; }
        public int TransferTo { get; set; }

        [ForeignKey("TransferFrom")]
        public virtual District DistrictFrom { get; set; }

        [ForeignKey("TransferTo")]
        public virtual District DistrictTo { get; set; }

    }
}