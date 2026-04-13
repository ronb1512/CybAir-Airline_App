using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static CybAir_Airline_App.Data;

namespace CybAir_Airline_App
{
    static class ActiveFlightsManager
    {
        /// <summary>
        /// the function reads the data from the flights file if it exists
        /// and returns it as a list of ActiveFlight objects
        /// </summary>
        /// <param name="file_path"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static List<ActiveFlight> get_flights(string file_path)
        {
            if (!File.Exists(file_path))
            {
                throw new FileNotFoundException($"{file_path}: is missing");
            }
            string data = File.ReadAllText(file_path);
            return JsonSerializer.Deserialize<List<ActiveFlight>>(data);
        }

        /// <summary>
        /// the function gets all the data from the flights file if it exists using get_flights
        /// the function writes in the file and add the flight
        /// </summary>
        /// <param name="flight"></param>
        /// <param name="file_path"></param>
        /// <exception cref="FileNotFoundException"></exception>
        public static void add_flight(ActiveFlight flight, string file_path)
        {
            if (!File.Exists(file_path))
            {
                throw new FileNotFoundException($"{file_path}: is missing");
            }
            try
            {
                List<ActiveFlight> all_flights = get_flights(file_path);
                all_flights.Add(flight);
                string data = JsonSerializer.Serialize(all_flights, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(file_path, data);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// the function ittirates through all the flights and returns a flight if it matches the id, time, date
        /// </summary>
        /// <param name="id"></param>
        /// <param name="time"></param>
        /// <param name="date"></param>
        /// <param name="file_path"></param>
        /// <returns></returns>
        public static ActiveFlight found_flight(string id, string time, DateTime date, string file_path)
        {
            try
            {
                List<ActiveFlight> flights = get_flights(file_path);
                foreach (ActiveFlight f in flights)
                {
                    if (f.id == id && f.date == date && f.time == time)
                    {
                        return f;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// the function ittirates through all the flights and returns a flight if it
        /// matches the flight_number, time, date
        /// </summary>
        /// <param name="flight_number"></param>
        /// <param name="date"></param>
        /// <param name="file_path"></param>
        /// <returns></returns>
        public static ActiveFlight found_flight(string flight_number, DateTime date, string file_path)
        {
            try
            {
                List<ActiveFlight> flights = get_flights(file_path);
                foreach (ActiveFlight f in flights)
                {
                    if (f.flight_number.Equals(flight_number) && f.date == date)
                    {
                        return f;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// if the file exists it removes all the flight that their departure date is past todays date
        /// </summary>
        /// <param name="flights_file_path"></param>
        /// <param name="users_file_path"></param>
        /// <exception cref="FileNotFoundException"></exception>
        public static void update_flights(string flights_file_path, string users_file_path)
        {
            if (!File.Exists(flights_file_path))
            {
                throw new FileNotFoundException($"{flights_file_path}: is missing");
            }
            try
            {
                List<ActiveFlight> flights = get_flights(flights_file_path);
                List<ActiveFlight> to_remove = new List<ActiveFlight>();
                foreach (ActiveFlight f in flights)
                {
                    if (f.date < DateTime.Now.AddDays(-1))
                    {
                        to_remove.Add(f);
                        Users.update_flight(f, users_file_path);
                    }
                }
                foreach (ActiveFlight f in to_remove)
                {
                    flights.Remove(f);
                }
                string data = JsonSerializer.Serialize(flights, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(flights_file_path, data);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// if the file exiss it removes the recieved flight and writes the file again
        /// </summary>
        /// <param name="flight"></param>
        /// <param name="file_path"></param>
        public static void remove_flight(ActiveFlight flight, string file_path)
        {
            try
            {
                ActiveFlight f = found_flight(flight.id, flight.time, flight.date, file_path);
                if (f == null) return;
                List<ActiveFlight> all_flights = get_flights(file_path);
                foreach (ActiveFlight active_flight in all_flights)
                {
                    if (active_flight.date == flight.date && active_flight.flight_number == flight.flight_number)
                    {
                        f = active_flight;
                    }
                }
                all_flights.Remove(f);
                string data = JsonSerializer.Serialize(all_flights, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(file_path, data);
            }
            catch { }
        }
    }
}