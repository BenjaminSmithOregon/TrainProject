using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OreFun2014.Models
{
    public class Ticket
    {

        [Key]
        public int TicketID { get; set; }
        
        public int RouteID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Travel Date")]
        public DateTime RouteDate { get; set; }

        public int PassengerID { get; set; }

        [Display(Name = "Assigned Seat")]
        public string SeatAssignment { get; set; }

        public virtual Passenger Passenger { get; set; }
        public virtual Route Route { get; set; }
    }
}