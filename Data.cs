using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Search_lib
{
    public class Data
    {
        private List<Tour> All_tours;
        private List<Tour> Acceptable_tours = new List<Tour>();
        public Data(List<Tour> All_tours)
        {
            if (All_tours is null)
                throw new ArgumentNullException(nameof(All_tours));
            this.All_tours = All_tours;
        }
        public void Add_new_tour(Tour New_tour)
        {
            if (New_tour is null)
                throw new ArgumentNullException(nameof(New_tour));
            All_tours.Add(New_tour);
        }
        public void Add_new_tours(List<Tour> New_tours)
        {
            if (New_tours is null)
                throw new ArgumentNullException(nameof(New_tours));
            foreach (Tour tour in New_tours)
            {
                All_tours.Add(tour);
            }
        }
        public void Delete_tour(int Number_of_the_tour)
        {
            All_tours.RemoveAt(Number_of_the_tour);
        }
        public void Clear_all_tours()
        {
            All_tours.Clear();
        }
        public void Search_acceptable_tours(TourPreferences Preferences)
        {
            if (Preferences is null)
                throw new ArgumentNullException("Preference");
            Acceptable_tours.Clear();
            foreach (Tour tour in All_tours)
            {
                bool Country_Preference = String_comparison(tour.Country, Preferences.Country);
                bool Departure_from_Preference = String_comparison(tour.Departure_from, Preferences.Departure_from);
                bool Date_of_departure_Preference = String_comparison(tour.Date_of_departure, Preferences.Date_of_departure);
                bool Type_of_transport_Preference = String_comparison(tour.Type_of_transport, Preferences.Type_of_transport);
                bool Amount_of_people_Preference = String_comparison(tour.Amount_of_people, Preferences.Amount_of_people);
                bool Ratings_Preference = String_comparison(tour.Amount_of_people, Preferences.Amount_of_people);
                bool Cost_Preference = Number_comparison(tour.Cost, Preferences.Maximum_cost);
                bool Duration_Preference = Number_comparison(tour.Duration, Preferences.Maximum_duration_of_tour);
                bool Acceptability_of_tour = Country_Preference & Departure_from_Preference & Date_of_departure_Preference & Type_of_transport_Preference & Amount_of_people_Preference & Ratings_Preference & Cost_Preference & Duration_Preference;
                if (Acceptability_of_tour)
                {
                    Acceptable_tours.Add(tour);
                }
            }
        }
        private bool String_comparison(string Tour_characteristic, string Preference)
        {
            if (Preference == "-")
                return true;
            else if (Tour_characteristic.ToLower() == Preference.ToLower())
                return true;
            else
                return false;
        }
        private bool Number_comparison(string Tour_characteristic, string Preference)
        {
            if (Preference == "-")
                return true;
            try
            {
                if (Convert.ToInt32(Tour_characteristic) <= Convert.ToInt32(Preference))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Tour> Get_all_tours()
        {
            if (All_tours is null)
                throw new ArgumentNullException(nameof(All_tours));
            return All_tours;
        }
        public List<Tour> Get_acceptable_tours()
        {
            if (Acceptable_tours is null)
                throw new ArgumentNullException(nameof(Acceptable_tours));
            return Acceptable_tours;
        }
    }
}
