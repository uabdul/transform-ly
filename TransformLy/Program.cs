
using Microsoft.VisualBasic;
using TransformLy;

namespace TransformLyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfFlights = LoadFlightData();
            int userInput = 0;

            do
            {
                userInput = DisplayMenu();
                switch (userInput)
                {
                    case 1:
                        PrintFlightData(listOfFlights);
                        break;
                    case 2:
                        //TO DO
                        break;
                    case 3:
                        break;
                    default:
                        HandleInvalidInput();
                        break;
                }
            } while (userInput != 3);
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


    }






}