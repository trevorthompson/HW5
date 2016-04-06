using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Thompson_Trevor_HW5.Models;
using System.Data.Entity;


namespace Thompson_Trevor_HW5.DAL
{
  
            public class AppDbContext : DbContext
    {
        //Constructor that invokes the base constructor
        public AppDbContext() : base("MyDBConnection") { }

        //Create the db set
        public DbSet<Member> Members { get; set; }

        //Create the db set
        public DbSet<Event> Events { get; set; }


        //Create the db set
        public DbSet<Committee> Committees { get; set; }
    }
}