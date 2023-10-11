using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMinfrastructure
{
    public class AMInfra:DbContext
    {
        DbSet<Flight> flights { get; set; }
        DbSet<Passenger> passengers { get; set; }  
        DbSet<Plane> planes { get; set; }   
        DbSet<Staff> staffs { get; set; }  
        DbSet<Traveller> travelers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
      Initial Catalog=AirportManagementDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
