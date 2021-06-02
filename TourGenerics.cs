using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Search_lib
{
    public abstract class TourGenerics
    {
        public string Country { get; }
        public string Departure_from { get; }
        public string Date_of_departure { get; }
        public string Type_of_transport { get; }
        public string Amount_of_people { get; }
        public string Ratings { get; }
        public TourGenerics(string Country, string Departure_from, string Date_of_departure, string Type_of_transport, string Amount_of_people, string Ratings)
        {
            if (Country is null || Departure_from is null || Date_of_departure is null || Type_of_transport is null || Amount_of_people is null || Ratings is null)
                throw new ArgumentNullException();
            this.Country = Country;
            this.Departure_from = Departure_from;
            this.Date_of_departure = Date_of_departure;
            this.Type_of_transport = Type_of_transport;
            this.Amount_of_people = Amount_of_people;
            this.Ratings = Ratings;
        }
    }
}
