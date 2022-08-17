
using Microsoft.VisualBasic;
using TransformLy;

namespace TransformLyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfFlights = LoadFlightData();
            PrintFlightData(listOfFlights);
            //var flightDictionaryByArrivalCity = listOfFlights.ToDictionary(keySelector: flight => flight.ArrivalCity, elementSelector: flight => flight);
            var flightDictionaryByArrivalCity = listOfFlights.GroupBy(flight => flight.ArrivalCity).ToDictionary(keySelector: group => group.Key, elementSelector: group => group.ToList());

            foreach (var flightGroup in flightDictionaryByArrivalCity)
            {
                Console.WriteLine($"{flightGroup.Key}={string.Join(", ", flightGroup.Value.Select(s => s.FlightNumber))}");
            }

            //Console.WriteLine(flightDictionaryByArrivalCity);
            //foreach (Flight flight in listOfFlights)
            //{
            //    flight.PrintToConsole();
            //}

            //TO DO
            //2. hash map or dictionary of string (destination) to list of flights; for each flight loaded, we want to take the destiniation and add our flight to the list in that dictionary


            //3. load JSON file and transform if necessary
            //4. take output of 2 and compare with output of 3 - output may be a list of strings
            //5. for each string, console.writeline()
            //List<Flight> listOfFlights = new List<Flight>()
            //{
            //    new Flight() { FlightNumber = 1, DepartureCity = "YUL", ArrivalCity = "YYZ", DayOfWeek = 1 },
            //    new Flight() { FlightNumber = 2, DepartureCity = "YUL", ArrivalCity = "YYC", DayOfWeek = 1 },
            //    new Flight() { FlightNumber = 3, DepartureCity = "YUL", ArrivalCity = "YVR", DayOfWeek = 1 },
            //    new Flight() { FlightNumber = 4, DepartureCity = "YUL", ArrivalCity = "YYZ", DayOfWeek = 2 },
            //    new Flight() { FlightNumber = 5, DepartureCity = "YUL", ArrivalCity = "YYC", DayOfWeek = 2 },
            //    new Flight() { FlightNumber = 6, DepartureCity = "YUL", ArrivalCity = "YVR", DayOfWeek = 2 },


            //};
            //foreach (Flight flight in listOfFlights)
            //    flight.PrintToConsole();

        }

        public static List<Flight> LoadFlightData()
        {
            //Currently, flight data is hard coded
            var flightData = new List<Flight>()
            { 
                new Flight() { FlightNumber = 1, DepartureCity = "YUL", ArrivalCity = "YYZ", DayOfWeek = 1 },
                new Flight() { FlightNumber = 2, DepartureCity = "YUL", ArrivalCity = "YYC", DayOfWeek = 1 },
                new Flight() { FlightNumber = 3, DepartureCity = "YUL", ArrivalCity = "YVR", DayOfWeek = 1 },
                new Flight() { FlightNumber = 4, DepartureCity = "YUL", ArrivalCity = "YYZ", DayOfWeek = 2 },
                new Flight() { FlightNumber = 5, DepartureCity = "YUL", ArrivalCity = "YYC", DayOfWeek = 2 },
                new Flight() { FlightNumber = 6, DepartureCity = "YUL", ArrivalCity = "YVR", DayOfWeek = 2 },
            };

            return flightData;
        }

        public static void PrintFlightData(List<Flight> flights)
        {
            foreach (Flight flight in flights)
            {
                flight.PrintToConsole();
            }
        }


    }






}