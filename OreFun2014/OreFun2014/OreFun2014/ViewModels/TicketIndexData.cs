using System;
using System.Collections.Generic;
using OreFun2014.Models;

namespace OreFun2014.ViewModels
{
    public class TicketIndexData
    {
        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<Passenger> Passengers { get; set; }
        public IEnumerable<Route> Routes { get; set; }
        public IEnumerable<Train> Trains { get; set; }
        public IEnumerable<Station> Stations { get; set; }
    }
}