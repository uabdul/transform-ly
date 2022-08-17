using System;
namespace TransformLy
{
    public class Flight
    {

        //Auto implemented properties
        //TO DO remove set OR put private in front of it (which means only members of class can set the value)
        public int FlightNumber { get; }
        public string DepartureCity { get; }
        public string ArrivalCity { get; }
        public int DayOfWeek { get; }
        public int FlightCapacity { get; }

        public Flight(int flightnumber, string departure, string arrival, int dayofweek)
        {
            FlightNumber = flightnumber;
            DepartureCity = departure;
            ArrivalCity = arrival;
            DayOfWeek = dayofweek; 
            FlightCapacity = 20;
        }


        //public override string ToString()
        //{
        //    return base.ToString();
        //}


        //Methods
        public void PrintToConsole()
        {
            Console.WriteLine("Flight: " + this.FlightNumber + " Departure: " + this.DepartureCity + " Arrival: " + this.ArrivalCity + " Day: " + this.DayOfWeek);
        }
    }
}

