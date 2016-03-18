using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OreFun2014.Models
{
    public class Train
    {
        [Key]
        [Display(Name = "Train ID")]
        public int TrainID { get; set; }

        [Display(Name = "Train Name")]
        public string TrainName { get; set; }

        [Display(Name = "Train Model")]
        public string TrainModel { get; set; }

        [Display(Name = "Number of Cars")]
        public int NumOfCars { get; set; }

        public virtual ICollection<Route> Routes { get; set; }
        //public virtual Passenger Passenger { get; set; }
    }
}