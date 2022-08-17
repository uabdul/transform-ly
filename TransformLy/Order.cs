using System;
using Newtonsoft.Json;

namespace TransformLy
{
    public class Order
    {
        public string OrderNumber { get; }
        public string Destination { get; }
        public Flight? Flight { get; set; }

        public Order(string ordernumber, string destination)
        {
            OrderNumber = ordernumber;
            Destination = destination;
        }

        public void PrintToConsole()
        {
            if (this.Flight == null)
            {
                Console.WriteLine("Order: " + this.OrderNumber + " Flight Number: not scheduled");
            }
            else
            {
                Console.WriteLine("Order: " + this.OrderNumber + " Flight Number: " + this.Flight.FlightNumber + " Departure: " + this.Flight.DepartureCity + " Arrival: " + this.Flight.ArrivalCity + " Day: " + this.Flight.DayOfWeek);
            }
        }

        public void AssignFlight(Flight flight)
        {
            Flight = flight;
        }
    }
}

