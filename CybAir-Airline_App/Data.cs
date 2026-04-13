using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Documents;
using System.Runtime.ConstrainedExecution;
using System.Diagnostics;
using System.Data.SqlTypes;
using System.Reflection;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using System.IO;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Threading;
using System.Windows.Interop;
using System.Net.Sockets;
using System.Net;
using System.Web;
using System.Text.Json;
using FontAwesome.Sharp;
using System.Web.UI.Design.WebControls;
using static CybAir_Airline_App.Data;
using Guna.UI2.AnimatorNS;
using System.Text.Json.Serialization;
using System.Windows.Markup;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Diagnostics.Eventing.Reader;

namespace CybAir_Airline_App
{
    enum all_messages {CANI,SIGNUP,LOGIN,FAILED,EMPTY,SUCCESSFULL,EXISTS, LOGOUT, PROFILE_PICTURE, SEARCH,BOOK,RESERVATIONS,MAP,CHAT,MESSAGES,EXITCHAT,CANCEL }
    
    public static class Data
    {
        public class City {
            public string city { get; set; }
            public string country { get; set; }
            public double lat { get; set; }
            public double lng { get; set; }
            public string iso2 { get; set; }
            public string iso3 { get; set; }

        }
        /// <summary>
        /// transforms the data in the worldcities.csv file to a list of City objects and returns it
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static List<City> getWorldCities()
        {

            List<City> worldCities = new List<City>();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "worldcities.csv");
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"{filePath}: is missing");
            }
            using (var streamReader = new StreamReader(filePath))
            using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {
                worldCities = csvReader.GetRecords<City>().ToList();
            }
            return worldCities;
        }
        public class Seat
        {
            public int row { get; set; }
            public int column { get; set; }
            public string name {  get; set; }
            public string flight_class { get; set; }
            public Seat() { }
            public Seat(int row, int column, string flight_class)
            {
                this.row = row;
                this.column = column;
                this.flight_class = flight_class;
                this.name = "";
            }
            public Seat(int row, int column,string flight_class,string name)
            {
                this.row = row;
                this.column = column;
                this.flight_class = flight_class;
                this.name = name;
            }
        }
        public class BookedFlight {
            public string flight {  get; set; }
            public List<Seat> seats { get; set; }
            public BookedFlight() { }
            public BookedFlight(string flight, List<Seat> seat)
            {
                this.flight = flight;
                this.seats = seat;
            }
        }
        public class User {
            public string name { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public string salt {  get; set; }
            public DateTime birth_date { get; set; }
            public string address { get; set; }
            public byte[] profile_picture { get; set; }
            public bool loged_in { get; set; }
            public List<BookedFlight> booked_flights { get; set; }
            public List<ChatMessage> chat_messages { get; set; }
            public bool chat_online {get; set; }
            public User()
            {
                booked_flights = new List<BookedFlight>();
                loged_in = false;
                chat_messages = new List<ChatMessage>();
                salt = null;
            }
            public User(string name, string email, string password, DateTime birth_date, string address, byte[] profile_picture)
            {
                this.name = name;
                this.email = email;
                this.password = password;
                this.birth_date = birth_date;
                this.address = address;
                this.profile_picture = profile_picture;
                this.booked_flights = new List<BookedFlight>();
                this.loged_in = false;
                this.chat_messages = new List<ChatMessage>();
                this.chat_online = false;
                this.salt=null;
            }
            /// <summary>
            /// goes over all the booked flights of the user and returns if there is a match between the patterns
            /// </summary>
            /// <param name="flight"></param>
            /// <returns></returns>
            public bool flight_booked(ActiveFlight flight)
            {
                foreach (BookedFlight f in booked_flights)
                {
                    if (f.flight.Equals($"{flight.flight_number}|{flight.date}"))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public class Flight {
            public string id { get; set; }   
            public string origin_airport { get; set; }
            public string origin_city { get; set; }
            public string origin_country { get; set; }
            public string destination_airport { get; set; }
            public string destination_city { get; set; }
            public string destination_country { get; set; }
            public int price { get; set; }
            public int flights_per_day { get; set; }
            public string active_days { get; set; }
            public string times {  get; set; }
            
        }
        public class ActiveFlight : Flight
        {
            public string flight_number { get; set; }
            public DateTime date { get; set; }
            public string time { get; set; }
            public int first_class_rows = 5;
            public int buissness_class_rows = 5;
            public int economy_class_rows = 25;
            public int seats_per_row = 6;
            public string code { get; set; }
            public Dictionary<string, List<bool[]>>seats { get; set; }
            /// <summary>
            /// acts like a constructor and initializes all the properties of the class
            /// </summary>
            /// <param name="baseFlight"></param>
            /// <param name="date"></param>
            /// <param name="time"></param>
            public void copy(Flight baseFlight,DateTime date, string time)
            {
                this.id = baseFlight.id;
                this.origin_airport = baseFlight.origin_airport;
                this.origin_city = baseFlight.origin_city;
                this.origin_country = baseFlight.origin_country;
                this.destination_airport = baseFlight.destination_airport;
                this.destination_city = baseFlight.destination_city;
                this.destination_country = baseFlight.destination_country;
                this.price = baseFlight.price;
                this.flights_per_day = baseFlight.flights_per_day;
                this.active_days = baseFlight.active_days;
                this.times = baseFlight.times;
                this.date = date;
                this.time = time;
                List<string>l=times.Trim('[',']').Replace(" ","").Split(',').ToList();
                this.flight_number = $"CA{id}{l.IndexOf(time)}";
                seats = new Dictionary<string, List<bool[]>>();
                List<bool[]> first_class = new List<bool[]>();
                for (int i = 0; i < first_class_rows; i++)
                {
                    first_class.Add(new bool[seats_per_row]);
                }
                List<bool[]> buissness = new List<bool[]>();
                for (int i = 0; i < buissness_class_rows; i++)
                {
                    buissness.Add(new bool[seats_per_row]);
                }
                List<bool[]>economy = new List<bool[]>();
                for(int i=0; i<economy_class_rows; i++)
                {
                    economy.Add(new bool[seats_per_row]);
                }
                seats["First"] = first_class;
                seats["Buissnes"] = buissness;
                seats["Economy"] = economy;

                byte[] salt = SecurityManager.generate_salt();
                this.code = Convert.ToBase64String(SecurityManager.hash_password($"{flight_number}|{this.date}", salt));
            }

            /// <summary>
            /// checks if all the seats in the flight are empty
            /// </summary>
            /// <returns></returns>
            public bool empty_flight()
            {
                return seats.Values
                    .SelectMany(list => list)
                    .All(array => array == null || array.All(item => item == false)); ;
            }
            
            /// <summary>
            /// checks if there is enough space for the number of passengers recieved in the recieved flight class
            /// returns true if available, else returns false        
            /// </summary>
            /// <param name="passengers"></param>
            /// <param name="flight_class"></param>
            /// <returns></returns>
            public bool available(int passengers,string flight_class)
            {
                try
                {
                    int available_seats_in_class = seats[flight_class]
                        .SelectMany(array => array)
                        .Count(str => str == false);
                    return available_seats_in_class >= passengers;
                }
                catch
                {
                    return false;
                }

            }


            /// <summary>
            /// recieves a list of seats and checks if all the selected seats are available
            /// if one seat is not available returns false
            /// else it updates all the seats to be taken
            /// </summary>
            /// <param name="selected_seats"></param>
            /// <returns></returns>
            public bool update_seats(List<Seat>selected_seats)
            {
                List<(string key,bool[]row)>flat= this.seats
                .SelectMany(kv => kv.Value.Select(row => (kv.Key, row)))
                .ToList();
                foreach (Seat s in selected_seats)
                {
                    bool taken = flat[s.row].Item2[s.column];
                    if (taken) { 
                        return false;
                    }
                }
                foreach (Seat s in selected_seats)
                {
                    flat[s.row].Item2[s.column] = true;
                }
                Dictionary<string, List<bool[]>> reversed = flat
                .GroupBy(x => x.key)
                .ToDictionary(g => g.Key, g => g.Select(x => x.row).ToList());
                
                this.seats = reversed;
                return true;
            }
            /// <summary>
            /// recieves a seat and changes the seat from taken to available
            /// </summary>
            /// <param name="s"></param>
            public void cancel_seat(Seat s)
            {
                List<(string key, bool[] row)> flat = this.seats
                .SelectMany(kv => kv.Value.Select(row => (kv.Key, row)))
                .ToList();
                flat[s.row].Item2[s.column] = false;
                Dictionary<string, List<bool[]>> reversed = flat
                .GroupBy(x => x.key)
                .ToDictionary(g => g.Key, g => g.Select(x => x.row).ToList());

                this.seats = reversed;
            }
            
        }
        public class FlightSearchData {
            public string origin { get; set; }
            public string destination { get; set; }
            public DateTime departure_date { get; set; }
            public DateTime return_date { get; set; }
            public int passengers { get; set; }
            public string flight_class { get; set; }
            public FlightSearchData(string origin, string destination, DateTime departure_date, DateTime return_date, int passengers, string flight_class)
            {
                this.origin = origin;
                this.destination = destination;
                this.departure_date = departure_date;
                this.return_date = return_date;
                this.passengers = passengers;
                this.flight_class = flight_class;
            }
        } 
        public class ChatMessage
        {
            public string message { get; set; }
            public string role { get; set; }
            public ChatMessage()
            {

            }
            public ChatMessage(string message, string role)
            {
                this.message = message;
                this.role = role;
            }
        }
        public static class Users
        {
            /// <summary>
            /// recieves a file path and if the file doesnt exist throws an error
            /// if the file exists it returns all the users from the JSON as a list
            /// </summary>
            /// <param name="file_path"></param>
            /// <returns></returns>
            /// <exception cref="FileNotFoundException"></exception>
            public static List<User> get_users(string file_path)
            {
                if (!File.Exists(file_path))
                {
                    throw new FileNotFoundException($"{file_path}: is missing");
                }
                string data = File.ReadAllText(file_path);
                return JsonSerializer.Deserialize<List<User>>(data);
            }
            /// <summary>
            /// recieves a file path and a user to add. if the file doesnt exist throws an error
            /// if the file exists, edits the JSON file and adds the user
            /// </summary>
            /// <param name="user"></param>
            /// <param name="file_path"></param>
            /// <exception cref="FileNotFoundException"></exception>
            public static void add_user(User user, string file_path)
            {
                if (!File.Exists(file_path))
                {
                    throw new FileNotFoundException($"{file_path}: is missing");
                }
                List<Data.User> all_users = get_users(file_path);
                all_users.Add(user);
                string data = JsonSerializer.Serialize(all_users, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(file_path, data);
            }
            /// <summary>
            /// checks if a user exists by email, 
            /// if is_login_check is true then hashes password and compares passwords
            /// </summary>
            /// <param name="users"></param>
            /// <param name="email"></param>
            /// <param name="password"></param>
            /// <param name="is_login_check"></param>
            /// <returns></returns>
            public static bool user_found(List<User> users, string email, string password, bool is_login_check)
            {
                try
                {
                    foreach (User user in users)
                    {
                        if (user.email.Equals(email))
                        {
                            if (!is_login_check)
                            {
                                return true;
                            }
                            else if (user.salt != null)
                            {

                                byte[] salt_btyes = Convert.FromBase64String(user.salt);
                                byte[] hashed_password = SecurityManager.hash_password(password, salt_btyes);
                                if (user.password.Equals(Convert.ToBase64String(hashed_password)))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                    return false;
                }
                catch { return false; }

            }
            /// <summary>
            /// gets the user instance from a list of users by email
            /// </summary>
            /// <param name="users"></param>
            /// <param name="email"></param>
            /// <returns></returns>
            public static User get_user(List<User> users, string email)
            {
                Data.User user = null;
                try
                {
                    foreach (Data.User u in users)
                    {
                        if (u.email.Equals(email))
                        {
                            user = u;
                        }
                    }
                    return user;
                }
                catch { return null; }
            }
            /// <summary>
            /// removes user from the users file
            /// </summary>
            /// <param name="file_path"></param>
            /// <param name="user"></param>
            /// <exception cref="FileNotFoundException"></exception>
            public static void remove_user(string file_path, User user)
            {
                if (!File.Exists(file_path))
                {
                    throw new FileNotFoundException($"{file_path}: is missing");
                }
                try
                {
                    List<User> users = get_users(file_path);
                    User u = get_user(users, user.email);
                    users.Remove(u);
                    string data = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(file_path, data);
                }
                catch { }


            }
            /// <summary>
            /// for each user that contains the reiceved flight, removes the flight from the booked_flight property
            /// </summary>
            /// <param name="flight"></param>
            /// <param name="file_path"></param>
            /// <exception cref="FileNotFoundException"></exception>
            public static void update_flight(ActiveFlight flight, string file_path)
            {
                if (!File.Exists(file_path))
                {
                    throw new FileNotFoundException($"{file_path}: is missing");
                }
                List<User> all_users = get_users(file_path);
                foreach (User user in all_users)
                {
                    if (user.flight_booked(flight))
                    {
                        List<BookedFlight> to_remove = new List<BookedFlight>();
                        foreach (BookedFlight f in user.booked_flights)
                        {
                            if (f.flight.Equals($"{flight.flight_number}|{flight.date}"))
                            {
                                to_remove.Add(f);
                            }
                        }
                        foreach (BookedFlight f in to_remove)
                        {
                            user.booked_flights.Remove(f);
                        }

                    }
                }

                string data = JsonSerializer.Serialize(all_users, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(file_path, data);
            }
        }
    }
    
    
    
}
