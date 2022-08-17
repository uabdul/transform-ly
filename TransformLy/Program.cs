
using System.Text.Json;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TransformLy;

namespace TransformLyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfFlights = LoadFlightData();
            int userInput = 0;
            int menuExitInput = 3;

            //App menu
            do
            {
                userInput = DisplayMenu();
                switch (userInput)
                {
                    case 1:
                        PrintFlightData(listOfFlights);
                        break;
                    case 2:
                        var listOfOrders = LoadOrderData("Orders.json");
                        var listOfOrderAssignments = AssignOrdersToFlights(listOfFlights, listOfOrders);
                        PrintOrderData(listOfOrderAssignments);
                        break;
                    case 3:
                        break;
                    default:
                        HandleInvalidInput();
                        break;
                }
            } while (userInput != menuExitInput);
        }

        public static List<Flight> LoadFlightData()
        {
            //Currently, flight data is hard coded
            var flightData = new List<Flight>()
            { 
                new Flight(1, "YUL", "YYZ", 1),
                new Flight(2, "YUL", "YYC", 1),
                new Flight(3, "YUL", "YVR", 1),
                new Flight(4, "YUL", "YYZ", 2),
                new Flight(5, "YUL", "YYC", 2),
                new Flight(6, "YUL", "YVR", 2)
            };

            return flightData;
        }

        public static int DisplayMenu()
        {
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1 - Print flight data");
            Console.WriteLine("2 - Assign orders");
            Console.WriteLine("3 - Exit the Transform.Ly app");
            var input = Console.ReadLine();
            return CheckUserInput(input);
        }

        public static int CheckUserInput(string input)
        {
            if (int.TryParse(input, out int validIntegerInput))
            {
                return validIntegerInput;
            }
            else
            {
                return 0;
            }
        }

        public static void HandleInvalidInput()
        {
            Console.WriteLine("Please provide a valid input from the menu options.");
        }

        public static void PrintFlightData(List<Flight> flights)
        {
            foreach (Flight flight in flights)
            {
                flight.PrintToConsole();
            }
        }

        public static List<Order> LoadOrderData(string filepath)
        {

            string OrderJSONData = File.ReadAllText(filepath);
            var responseObject = JsonConvert.DeserializeObject(OrderJSONData) as JObject;
            var list = responseObject.Properties();
            var orders = new List<Order>();
            foreach (var item in list)
            {
                orders.Add(new Order(item.Name, responseObject[item.Name]["destination"].ToString()));
            }
            return orders;
        }

        public static List<Order> AssignOrdersToFlights(List<Flight> listOfFlights, List<Order> listOfOrders)
        {

            var flightDictionaryByArrivalCity = listOfFlights.GroupBy(flight => flight.ArrivalCity).ToDictionary(keySelector: group => group.Key, elementSelector: group => group.ToList());

            foreach (var order in listOfOrders)
            {

                if (flightDictionaryByArrivalCity.ContainsKey(order.Destination))
                {
                    foreach (var flight in flightDictionaryByArrivalCity[order.Destination])
                    {
                        if (order.Destination == flight.ArrivalCity && flight.FlightCapacity > 0)
                        {
                            order.AssignFlight(flight);
                            flight.UpdateFlightCapacity();
                            break;
                        }
                    }
                }
            }
            return listOfOrders;
        }

        public static void PrintOrderData(List<Order> orders)
        {
            foreach (Order order in orders)
            {
                order.PrintToConsole();
            }
        }

    }






}