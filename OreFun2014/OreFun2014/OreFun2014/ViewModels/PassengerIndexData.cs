using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OreFun2014.Models;

namespace OreFun2014.ViewModels
{
    public class PassengerIndexData
    {
        public IEnumerable<Passenger> Passengers { get; set; }
        public IEnumerable<Route> Routes { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<Train> Trains { get; set; }
    }
}
