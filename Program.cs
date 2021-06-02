using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Search_lib;
namespace Tourism_Club
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tour tour1 = new Tour("Egypt", "Kyiv", "21.06.2021", "Plane", "3", "4", "25000", "8", "TUI", "https://TUI.com**********");
                Tour tour2 = new Tour("Egypt", "Kyiv", "14.06.2021", "Plane", "2", "3", "20000", "10", "Join UP!", "https://JoinUp.com**********");
                Tour tour3 = new Tour("Egypt", "Odessa", "19.07.2021", "Plane", "1", "5", "11000", "6", "Anextour", "https://Anextour.com**********");
                Tour tour4 = new Tour("Montenegro", "Lviv", "05.07.2021", "Train", "1", "3", "10300", "8", "Join UP!", "https://JoinUp.com**********");
                Tour tour5 = new Tour("Montenegro", "Odessa", "21.06.2021", "Train", "2", "3", "18000", "6", "Join UP!", "https://JoinUp.com**********");
                Tour tour6 = new Tour("Turkey", "Kharkiv", "12.07.2021", "Plane", "1", "5", "18000", "6", "Coral travel", "https://Coraltravel.com**********");
                Tour tour7 = new Tour("Turkey", "Kyiv", "21.06.2021", "Plane", "3", "4", "25000", "8", "Coral travel", "https://Coraltravel.com**********");
                Tour tour8 = new Tour("Turkey", "Odessa", "28.06.2021", "Plane", "2", "4", "16000", "6", "TUI", "https://TUI.com**********");
                Tour tour9 = new Tour("Turkey", "Kyiv", "28.06.2021", "Plane", "4", "4", "28000", "8", "Coral travel", "https://Coraltravel.com**********");
                Tour tour10 = new Tour("Lithuania", "Lviv", "12.07.2021", "Train", "3", "4", "25000", "8", "Join UP!", "https://JoinUp.com**********");
                Tour tour11 = new Tour("Lithuania", "Kharkiv", "01.06.2021", "Bus", "2", "4", "20000", "8", "Join UP!", "https://JoinUp.com**********");
                Tour tour12 = new Tour("Czech Republic", "Kyiv", "24.05.2021", "Bus", "1", "3", "7800", "5", "Anextour", "https://Anextour.com**********");
                Tour tour13 = new Tour("Poland", "Lviv", "24.05.2021", "Bus", "1", "3", "10000", "3", "Piligrim", "https://Piligrim.com**********");
                Tour tour14 = new Tour("Germany", "Kyiv", "21.06.2021", "Train", "1", "4", "12000", "5", "Piligrim", "https://Piligrim.com**********");
                Tour tour15 = new Tour("France", "Kyiv", "01.06.2021", "Plane", "2", "4", "19000", "4", "Piligrim", "https://Piligrim.com**********");
                Tour tour16 = new Tour("Italy", "Odessa", "21.06.2021", "Plane", "3", "3", "20000", "6", "TUI", "https://TUI.com**********");
                Tour tour17 = new Tour("Italy", "Lviv", "14.06.2021", "Plane", "2", "4", "21000", "8", "Join UP!", "https://JoinUp.com**********");
                Tour tour18 = new Tour("Italy", "Kyiv", "14.06.2021", "Plane", "2", "5", "29000", "8", "Anextour", "https://Anextour.com**********");
                List<Tour> tours = new List<Tour>() { tour1, tour2, tour3, tour4, tour5, tour6, tour7, tour8, tour9, tour10, tour11, tour12, tour13, tour14, tour15, tour16, tour17, tour18 };
                Data data = new Data(tours);
                Console.Write("Enter 1 if you're an admin or anything else if you're not: ");
                string is_admin = Console.ReadLine();
                int result_admin;
                bool bool_admin = Int32.TryParse(is_admin, out result_admin);
                if (bool_admin && result_admin == 1)
                    admin_menu(data);
                else
                    menu(data);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
      
        static void menu(Data data)
        {
            int choice;
            bool choice_check;
            Console.WriteLine("_______menu_______\n1) Enter preferences\n2) Show all acceptable tours\n3) Show all avilable tours\n4) End program");
            do
            {
                Console.Write("\nChoose a possible option: ");
                string choice_input = Console.ReadLine();
                choice_check = Int32.TryParse(choice_input, out choice);
            }
            while (choice_check == false || choice < 1 || choice > 4);
            switch (choice)
            {
                case 1:
                    Enter_preferences(data);
                    break;
                case 2:
                    Print_acceptable_tours(data);
                    break;
                case 3:
                    Print_all_tours(data);
                    break;
                case 4:
                    return;
            }
            menu(data);
        }
      
        static void admin_menu(Data data)
        {
            int choice;
            bool choice_check;
            Console.WriteLine("_____Admin menu_____\n1) Enter preferences\n2) Show all acceptable tours\n3) Show all avilable tours\n4) Add new tour\n5) Delete a tour\n6) Delete ALL tours\n7) End program");
            do
            {
                Console.Write("\nChoose a possible option: ");
                string choice_input = Console.ReadLine();
                choice_check = Int32.TryParse(choice_input, out choice);
            }
            while (choice_check == false || choice < 1 || choice > 7);
            switch (choice)
            {
                case 1:
                    Enter_preferences(data);
                    break;
                case 2:
                    Print_acceptable_tours(data);
                    break;
                case 3:
                    Print_all_tours(data);
                    break;
                case 4:
                    Add_new_tour(data);
                    break;
                case 5:
                    Delete_existing_tour(data);
                    break;
                case 6:
                    data.Clear_all_tours();
                    break;
                case 7:
                    return;
            }
            admin_menu(data);
        }
    
        static void Print_all_tours(Data data)
        {
            Console.WriteLine("All avivable tours\n");
            int number = 0;
            List<Tour> data_to_print = data.Get_all_tours();
            if (data_to_print.Count == 0)
                Console.WriteLine("There are no avivable tours\n");
            foreach (Tour tour in data_to_print)
            {
                number++;
                Console.WriteLine($"\n№{number}. To: {tour.Country}, From: {tour.Departure_from}, By: {tour.Type_of_transport}, Date of departure: {tour.Date_of_departure}, Tour duration: {tour.Duration} day/s\nFor {tour.Amount_of_people} person/s, Cost: {tour.Cost} hryvnas, Rating: {tour.Ratings} stars, Tour agency {tour.Agency}\nGo to the tour: {tour.Contact}");
            }
        }
   
        static void Print_acceptable_tours(Data data)
        {
            Console.WriteLine("Acceptable tours according to your preferences\n");
            List<Tour> data_to_print = data.Get_acceptable_tours();
            if (data_to_print.Count == 0)
                Console.WriteLine("There are no tours that satisfy your preferences\n");
            foreach (Tour tour in data_to_print)
            {
                Console.WriteLine($"\nTo: {tour.Country}, From: {tour.Departure_from}, By: {tour.Type_of_transport}, Date of departure: {tour.Date_of_departure}, Tour duration: {tour.Duration} day/s\nFor {tour.Amount_of_people} person/s, Cost: {tour.Cost} hryvnas, Rating: {tour.Ratings} stars, Tour agency {tour.Agency}\nGo to the tour: {tour.Contact}");
            }
        }
    
        static void Add_new_tour(Data data)
        {
            Console.Write("Enter info about new tour\nCountry: ");
            string Country = Console.ReadLine();
            Console.Write("Departure from: ");
            string Departure_from = Console.ReadLine();
            Console.Write("Date of departure: ");
            string Date_of_departure = Console.ReadLine();
            Console.Write("Type of transport: ");
            string Type_of_transport = Console.ReadLine();
            Console.Write("Amount of people: ");
            string Amount_of_people = Console.ReadLine();
            Console.Write("Rating: ");
            string Ratings = Console.ReadLine();
            Console.Write("Cost: ");
            string Cost = Console.ReadLine();
            Console.Write("Duaration of the tour: ");
            string Duration = Console.ReadLine();
            Console.Write("Tour agency: ");
            string Agency = Console.ReadLine();
            Console.Write("Source of tour: ");
            string Contact = Console.ReadLine();
            Tour new_tour = new Tour(Country, Departure_from, Date_of_departure, Type_of_transport, Amount_of_people, Ratings, Cost, Duration, Agency, Contact);
            data.Add_new_tour(new_tour);
        }
    
        static void Delete_existing_tour(Data data)
        {
            Console.Write("Enter number of the tour to delete: ");
            try
            {
                int number_of_tour_to_delete = Convert.ToInt32(Console.ReadLine());
                data.Delete_tour(number_of_tour_to_delete - 1);
            }
            catch (Exception)
            {
                Console.WriteLine("Number of tour to delete is invalid");
            }
        }
   
        static void Enter_preferences(Data data)
        {
            Console.Write("Enter your tour preferences (Enter '-' to ignore item)\nCountry: ");
            string Country = Console.ReadLine();
            Console.Write("Departure from: ");
            string Departure_from = Console.ReadLine();
            Console.Write("Date of departure: ");
            string Date_of_departure = Console.ReadLine();
            Console.Write("Type of transport: ");
            string Type_of_transport = Console.ReadLine();
            Console.Write("Amount of people: ");
            string Amount_of_people = Console.ReadLine();
            Console.Write("Rating: ");
            string Ratings = Console.ReadLine();
            Console.Write("Maximal cost: ");
            string Maximum_cost = Console.ReadLine();
            Console.Write("Maximal duration of the tour: ");
            string Maximum_duration_of_tour = Console.ReadLine();
            TourPreferences preferences = new TourPreferences(Country, Departure_from, Date_of_departure, Type_of_transport, Amount_of_people, Ratings, Maximum_duration_of_tour, Maximum_cost);
            data.Search_acceptable_tours(preferences);
        }
    }
}