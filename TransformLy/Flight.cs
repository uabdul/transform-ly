using System;
namespace TransformLy
{
    public class Flight
    {
        public Flight()
        {
            //TO DO use constructor - take in params, set props
            FlightCapacity = 20;
        }

        //Auto implemented properties
        //TO DO remove set OR put private in front of it (which means only members of class can set the value)
        public int FlightNumber { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public int DayOfWeek { get; set; }
        public int FlightCapacity { get; }
        public override string ToString()
        {
            return base.ToString();
        }


        //Methods
        //TO DO override the ToString method 
        public void PrintToConsole()
        {
            Console.WriteLine("Flight: " + this.FlightNumber + " Departure: " + this.DepartureCity + " Arrival: " + this.ArrivalCity + " Day: " + this.DayOfWeek);
        }
    }
}

