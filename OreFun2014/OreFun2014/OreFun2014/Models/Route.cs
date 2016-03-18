using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OreFun2014.Models
{
    public class Route
    {
        [Key]
        public int RouteID { get; set; }

        [Display(Name = "Route Number")]
        public int RouteNumber { get; set; }

        [Display(Name = "Station")]
        public int StationID { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Arrival Time")]
        public DateTime? ArrivalTime { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Departure Time")]
        public DateTime? DepartTime { get; set; }

        [Display(Name = "Train Number")]
        public int TrainID { get; set; }

        public virtual Station Station { get; set; }
        public virtual Train Train { get; set; }
        //public virtual Passenger Passenger { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}