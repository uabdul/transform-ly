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
                Console.WriteLine("Order Number: " + this.OrderNumber + " Destination: " + this.Destination + " Assignment: not assigned");
            }
            else
            {
                Console.WriteLine("Order Number: " + this.OrderNumber + " Destination: " + this.Destination + " Assignment: " + this.Flight.FlightNumber);
            }
        }

        public void AssignFlight(Flight flight)
        {
            Flight = flight;
        }
    }
}

