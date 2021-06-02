using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Search_lib
{
    public class Tour : TourGenerics
    {
        public string Cost { get; }
        public string Duration { get; }
        public string Agency { get; }
        public string Contact { get; }
        public Tour(string Country, string Departure_from, string Date_of_departure, string Type_of_transport, string Amount_of_people, string Ratings, string Cost, string Duration, string Agency, string Contact)
            : base(Country, Departure_from, Date_of_departure, Type_of_transport, Amount_of_people, Ratings)
        {
            if (Cost is null || Duration is null || Agency is null || Contact is null)
                throw new ArgumentNullException();
            this.Cost = Cost;
            this.Duration = Duration;
            this.Agency = Agency;
            this.Contact = Contact;
        }
    }
}
