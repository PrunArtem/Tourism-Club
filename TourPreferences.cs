using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Search_lib
{
    public class TourPreferences : TourGenerics
    {
        public string Maximum_duration_of_tour { get; }
        public string Maximum_cost { get; }
        public TourPreferences(string Country, string Departure_from, string Date_of_departure, string Type_of_transport, string Amount_of_people, string Ratings, string Maximum_duration_of_tour, string Maximum_cost)
            : base(Country, Departure_from, Date_of_departure, Type_of_transport, Amount_of_people, Ratings)
        {
            if (Maximum_duration_of_tour is null || Maximum_cost is null)
                throw new ArgumentNullException();
            this.Maximum_duration_of_tour = Maximum_duration_of_tour;
            this.Maximum_cost = Maximum_cost;
        }
    }
}
