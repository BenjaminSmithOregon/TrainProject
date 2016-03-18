using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OreFun2014.Models
{
    public class Passenger
    {
        public int PassengerID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public bool Baggage { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public virtual ICollection<Ticket> Tickets { get; set; }
        //public virtual ICollection<Train> Trains { get; set; }
        //public virtual ICollection<Route> Routes { get; set; }
    }
}