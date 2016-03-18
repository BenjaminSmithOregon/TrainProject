using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OreFun2014.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OreFun2014.DAL
{
    public class OreFunContext : DbContext
    {
    
        public OreFunContext () : base("OreFunContext")
        {
        }
        
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Train> Trains { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
