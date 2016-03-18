using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OreFun2014.Models
{
    public class Station
    {
        [Key]
        [Display(Name = "Station Number")]
        public int StationID { get; set; }

        [Display(Name = "Station Name")]
        public string StationName { get; set; }

        public string City { get; set; }

        public virtual ICollection<Route> Routes { get; set; }
        public IEnumerable<Station> Stations { get; set; }
    }
}