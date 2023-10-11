using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {

       public List<Flight> Flights = new List<Flight>();
        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> ls = new List<DateTime>();
            //With for structure
            //for (int j = 0; j < Flights.Count; j++)
            //    if (Flights[j].Destination.Equals (==)(destination))
            //        ls.Add(Flights[j].FlightDate);

            //With foreach structure
            //foreach(Flight f in Flights)
            //    if (f.Destination.Equals(destination))
            //        ls.Add(f.FlightDate);
            //return ls;

            //with LINQ language
            // var  query=from instance in collections
            //             where
            //             select
            //return query.ToList
            //var query = from f in Flights
            //          where
            //          f.Destination.Equals(destination)
            //          select f.FlightDate;
            //return query.ToList();
            //lambda
            return Flights.Where(f =>f.Destination == destination). Select(a=>a.FlightDate).ToList();


        }
        //lambda : Fonction anonymes
        // (return)var lambda = collection.Where(instance=>instance.condition.Select(instance=>instance.condition
         
        public void GetFlights(string filterType, string filterValue)
        {
            
        }

        

        public void ShowFlightDetails(Plane x1)
        {
            //var query = from item in Flights
            //            where item.Plane == x1
            //            select new { item.Destination, item.FlightDate };

            var query= from f in x1.Flights
                       select new { f.Destination, f.FlightDate };

            foreach (var item in query)
            {
                Console.WriteLine("flighatdate"+ item.FlightDate+ "Destination"+item.Destination);
            }
            //lambda
            //lambda : Fonction anonymes
            // (return)var lambda = collection.Where(instance=>instance.condition.Select(instance=>instance.condition
            //var reqlambda=Flights.Where(f=>f.Plane==x1).Select( f=>new { f.Destination, f.FlightDate });



        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //var req = from f in Flights
            //          where ( DateTime.Compare (f.FlightDate,startDate)>0 && (f.FlightDate - startDate).TotalDays < 7)
            //          select f;
            //       return req.Count();

            //DateTime endDate = startDate.AddDays(7);
            //var progFlights = Flights.Where(flight =>
            //    flight.FlightDate >= startDate && flight.FlightDate < endDate);
            //return progFlights.Count();


            //DateTime endDate = startDate.AddDays(7);

            //var query = from f in Flights
            //            where f.FlightDate >= startDate && f.FlightDate <= endDate
            //            select f;


            //return query.Count();
            //lambda
            return Flights.Where(f => (f.FlightDate - startDate).TotalDays < 7).Select(a => a).Count();
            


        }

        public double DurationAverage(string destination)
        {
            //var query = from f in Flights
            //            where f.Destination.Equals(destination)
            //            select f.EstimatedDuration;
            //return query.Average();
            //lambda
            //return Flights.Where(f=> f.Destination.Equals(destination)).Select(p=>p.EstimatedDuration).Average();
            return Flights.Where(f => f.Destination.Equals(destination)).Average(p => p.EstimatedDuration);
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //var query = from a in Flights
            //            orderby(a.EstimatedDuration )descending
            //            select a;
            //return query;
            //lambda
            return Flights.OrderByDescending(a => a.EstimatedDuration);
        }

        public IEnumerable<Passenger> SeniorTravellers(Flight flight)
        {
            //var query = from a in flight.Passengers.OfType < Traveller >()
            //           orderby a.BirthDate
            //            select a;
            //return query.Take(3);
            //lambda
            return flight.Passengers.OfType<Traveller>().OrderBy(a => a.BirthDate).Take(3);
        }



        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var req = from f in Flights
                      group f by f.Destination;

            //  var reqLambda = Flights.GroupBy(f => f.Destination);

            foreach (var item in req)
            {
                Console.WriteLine("Destination: " + item.Key);
                foreach (var f in item)
                    Console.WriteLine("Décollage: " + f.FlightDate);

            }
            return req;
        }


    }
    }



  
