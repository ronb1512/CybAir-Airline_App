using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using static System.Net.Mime.MediaTypeNames;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net.Mail;
using System.Diagnostics;
using static CybAir_Airline_App.Data;
using System.Runtime.ConstrainedExecution;
using System.Windows.Shapes;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Drawing.Imaging;
using static System.Windows.Forms.LinkLabel;
using CsvHelper;
using System.Globalization;
using System.Windows.Interop;
using SkiaSharp;
using FontAwesome.Sharp;
using System.Security.Cryptography;

namespace CybAir_Airline_App
{
    public class ClientHandler : Server
    {
        public TcpClient tcpClient { get; set; }
        private StreamReader reader;
        private StreamWriter writer;
        private NetworkStream stream;
        private Server form;
        public User user { get; set; }
        public CancellationTokenSource is_user_active { get; set; }
        private SecurityManager security;
        private Queue<DateTime>messages_tracker = new Queue<DateTime>();
        private const int messages_limit = 10;
        /// <summary>
        /// initializes the properties of the tcp connection from the server side
        /// starts the listening loop which stops when the user logs out
        /// </summary>
        /// <param name="tcpClient"></param>
        /// <param name="form"></param>
        public ClientHandler(TcpClient tcpClient, Server form)
        {
            this.tcpClient = tcpClient;
            (reader, writer) = ConnectionManager.get_reader_writer(this.tcpClient);
            writer.AutoFlush = true;
            this.stream = tcpClient.GetStream();
            this.form = form;
            form.FormClosed += form.formClosed;
            this.security = new SecurityManager();
            this.security.writer = writer;
            this.security.reader = reader;
            this.user = null;
            is_user_active = new CancellationTokenSource();

            update_tracker(connection_tracker, 1);
            Debug.WriteLine("debug");
            if (connection_tracker.Count < connections_limit)
            {
                connection_tracker.Enqueue(DateTime.UtcNow);
            }
            else
            {

                is_user_active.Cancel();
                tcpClient.Close();
                tcpClient.Dispose();
            }
            UI.startThread(() =>
            {
                while (!is_user_active.Token.IsCancellationRequested)
                {
                    try
                    {
                        main_socket_thread();
                    }
                    catch { break; }
                }
            });
        }
        /// <summary>
        /// removes all the values in the queue that were enqueued more than seconds ago
        /// </summary>
        /// <param name="q"></param>
        /// <param name="seconds"></param>
        public void update_tracker(Queue<DateTime> q, int seconds)
        {
            while (q.Count() >0)
            {
                DateTime first = q.Peek();
                if ((DateTime.UtcNow - first).TotalSeconds > seconds)
                    q.Dequeue();
                else
                    break;
            }

        }
        /// <summary>
        /// waits until a message from the client is recieved
        /// calls the function according to the message
        /// </summary>
        public void main_socket_thread()
        {
            string message;

            while ((message = this.security.readEncrypted()) != null)
            {
                update_tracker(messages_tracker, 1);
                if (messages_tracker.Count < messages_limit)
                {

                    messages_tracker.Enqueue(DateTime.UtcNow);
                    try
                    {
                        switch (true)
                        {
                            case true when string.IsNullOrWhiteSpace(message):
                                message = all_messages.FAILED.ToString();
                                break;
                            case true when message.StartsWith(all_messages.SIGNUP.ToString()):
                                message = message.Substring(all_messages.SIGNUP.ToString().Length);
                                handle_signup(ref message);
                                break;
                            case true when message.StartsWith(all_messages.LOGIN.ToString()):
                                message = message.Substring(all_messages.LOGIN.ToString().Length);
                                handle_login(ref message);
                                break;
                            case true when message.StartsWith(all_messages.PROFILE_PICTURE.ToString()):
                                getProfilePicture(ref message);
                                break;
                            case true when message.StartsWith(all_messages.LOGOUT.ToString()):
                                handle_logout(ref message);
                                break;
                            case true when message.StartsWith(all_messages.SEARCH.ToString()):
                                message = message.Substring(all_messages.SEARCH.ToString().Length);
                                handle_search(ref message);
                                break;
                            case true when message.StartsWith(all_messages.BOOK.ToString()):
                                message = message.Substring(all_messages.BOOK.ToString().Length);
                                handle_booking(ref message);
                                break;
                            case true when message.StartsWith(all_messages.RESERVATIONS.ToString()):
                                send_bookings(ref message);
                                break;
                            case true when message.StartsWith(all_messages.MAP.ToString()):
                                message = message.Substring(all_messages.MAP.ToString().Length);
                                send_map_data(ref message);
                                break;
                            case true when message.StartsWith(all_messages.CHAT.ToString()):
                                message = message.Substring(all_messages.CHAT.ToString().Length);
                                handle_chat(message);
                                break;
                            case true when message.StartsWith(all_messages.EXITCHAT.ToString()):
                                user = Users.get_user(Users.get_users(users_file_path), user.email);
                                Users.remove_user(users_file_path, user);
                                user.chat_online = false;
                                Users.add_user(user, users_file_path);
                                break;
                            case true when message.StartsWith(all_messages.MESSAGES.ToString()):
                                send_messages(ref message);
                                break;
                            case true when message.StartsWith(all_messages.CANCEL.ToString()):
                                message = message.Substring(all_messages.CANCEL.ToString().Length);
                                handle_cancelation(ref message);
                                break;
                        }
                        if(!message.StartsWith(all_messages.LOGOUT.ToString()))
                            this.security.writeEncrypted(message);
                    }
                    catch
                    {
                        throw;
                    }
                }
                else
                {

                    is_user_active.Cancel();
                    tcpClient.Close();
                    tcpClient.Dispose();
                }
                
            }
        }

        /// <summary>
        /// creates a flight and seat from the message
        /// removes the booked seat from the booked flights list of the user
        /// searches the flight and changes the status of the seat to available
        /// </summary>
        /// <param name="message"></param>
        private void handle_cancelation(ref string message)
        {
            try
            {
                if (user == null || tcpClient == null || message == null)
                {
                    message = all_messages.FAILED.ToString();
                    return;
                }
                ActiveFlight flight = JsonSerializer.Deserialize<ActiveFlight>(message.Split('|')[0]);
                Seat seat = JsonSerializer.Deserialize<Seat>(message.Split('|')[1]);
                BookedFlight booked_flight = user.booked_flights.FirstOrDefault(f => f.flight.Equals(flight.flight_number + "|" + flight.date));
                user.booked_flights.Remove(booked_flight);
                Seat seat_to_remove = booked_flight.seats.FirstOrDefault(s => s.row == seat.row && s.column == seat.column);
                booked_flight.seats.Remove(seat_to_remove);
                if (booked_flight.seats.Count != 0)
                    user.booked_flights.Add(booked_flight);
                Users.remove_user(users_file_path, user);
                Users.add_user(user, users_file_path);
                ActiveFlight flight_to_update = ActiveFlightsManager.found_flight(flight.id, flight.time, flight.date, active_flights_path);
                ActiveFlightsManager.remove_flight(flight_to_update, active_flights_path);
                flight_to_update.cancel_seat(seat);
                if (!flight_to_update.empty_flight())
                    ActiveFlightsManager.add_flight(flight_to_update, active_flights_path);
                message = all_messages.SUCCESSFULL.ToString();
            }
            catch
            {
                message = all_messages.FAILED.ToString();
                throw;
            }
        }

        /// <summary>
        /// searches for all the users that contain the flight 
        /// sends the users without the sensetive data 
        /// </summary>
        /// <param name="message"></param>
        private void send_map_data(ref string message)
        {
            if (user == null || tcpClient == null)
            {
                message = all_messages.FAILED.ToString();
                return;
            }
            ActiveFlight flight = JsonSerializer.Deserialize<ActiveFlight>(message);
            List<User> all_users = Users.get_users(users_file_path);
            List<User> users_to_map = new List<User>();
            foreach (User u in all_users)
            {
                if (u.flight_booked(flight))
                {
                    if (!string.IsNullOrEmpty(u.address))
                    {
                        u.password = "";
                        u.email = "";
                        u.booked_flights = new List<BookedFlight>();
                        users_to_map.Add(u);
                    }
                }
            }
            message = $"{all_messages.SUCCESSFULL.ToString()}{JsonSerializer.Serialize(users_to_map)}";
        }

        /// <summary>
        /// matches the booked flights in the user data to active flights and sends them
        /// </summary>
        /// <param name="message"></param>
        private void send_bookings(ref string message)
        {
            try
            {
                if (user == null || this.tcpClient == null)
                {
                    message = all_messages.FAILED.ToString();
                    return;
                }
                List<BookedFlight> booked_flights = user.booked_flights;
                List<ActiveFlight> flights = new List<ActiveFlight>();
                ActiveFlightsManager.update_flights(active_flights_path, users_file_path);
                foreach (BookedFlight f in booked_flights)
                {
                    string number = f.flight.Split('|')[0];
                    DateTime date = DateTime.Parse(f.flight.Split('|')[1], CultureInfo.InvariantCulture);
                    ActiveFlight flight = ActiveFlightsManager.found_flight(number, date, active_flights_path);
                    if (flight != null)
                        flights.Add(flight);
                }
                message = $"{all_messages.SUCCESSFULL.ToString()}~{JsonSerializer.Serialize(flights)}~{JsonSerializer.Serialize(booked_flights)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// updates the chat_online property and sends all the messages from the user data
        /// </summary>
        /// <param name="message"></param>
        private void send_messages(ref string message)
        {
            try
            {
                user = Users.get_user(Users.get_users(users_file_path), user.email);
                message = $"{all_messages.SUCCESSFULL.ToString()}{JsonSerializer.Serialize(user.chat_messages)}";
                Users.remove_user(users_file_path, user);
                user.chat_online = true;
                Users.add_user(user, users_file_path);
            }
            catch
            {
                user = Users.get_user(Users.get_users(users_file_path), user.email);
                Users.remove_user(users_file_path, user);
                user.chat_online = true;
                Users.add_user(user, users_file_path);
                message = all_messages.FAILED.ToString();
            }
        }

        /// <summary>
        /// adds the message to the message list in the user's data
        /// shows the message on the server screen if the current user is clicked
        /// otherwise it add a notification next to the panel of the user
        /// </summary>
        /// <param name="message"></param>
        private void handle_chat(string message)
        {
            ChatMessage msg = JsonSerializer.Deserialize<ChatMessage>(message);
            user = Users.get_user(Users.get_users(users_file_path), user.email);
            Users.remove_user(users_file_path, user);
            user.chat_messages.Add(msg);
            Users.add_user(user, users_file_path);

            if (current_chat_user == null)
            {
                form.Invoke(new Action(() =>
                {
                    form.add_notification(form, user);
                }));
            }
            else if (current_chat_user.email.Equals(user.email, StringComparison.OrdinalIgnoreCase))
            {
                form.Invoke(new Action(() =>
                {
                    form.create_message(msg.message, "client", form);
                }));
            }
            else
            {
                form.Invoke(new Action(() =>
                {
                    form.add_notification(form, user);
                }));
            }
        }

        /// <summary>
        /// if flight is not booked by the user already sends an "exists" message
        /// otherwise it checks that the seats chosen are actually available
        /// if the seats are available it updates the flight's seats and the user's booked flights
        /// </summary>
        /// <param name="message"></param>
        private void handle_booking(ref string message)
        {
            if (user == null || this.tcpClient == null)
            {
                message = all_messages.FAILED.ToString();
                return;
            }
            try
            {
                ActiveFlight flight = JsonSerializer.Deserialize<ActiveFlight>(message.Split('|')[0]);
                if (user.flight_booked(flight))
                {
                    message = $"{all_messages.EXISTS}{all_messages.BOOK}";
                    return;
                }
                List<Seat> selected_seats = JsonSerializer.Deserialize<List<Seat>>(message.Split('|')[1]);
                ActiveFlightsManager.update_flights(active_flights_path, users_file_path);
                List<ActiveFlight> active_flights = ActiveFlightsManager.get_flights(active_flights_path);
                ActiveFlight f = ActiveFlightsManager.found_flight(flight.id, flight.time, flight.date, active_flights_path);
                ActiveFlightsManager.remove_flight(flight, active_flights_path);
                if (f != null)
                {
                    if (!f.update_seats(selected_seats))
                    {
                        ActiveFlightsManager.add_flight(f, active_flights_path);
                        message = all_messages.EXISTS.ToString();
                        return;
                    }
                }
                else
                {
                    f = flight;
                    f.update_seats(selected_seats);
                }
                ActiveFlightsManager.add_flight(f, active_flights_path);
                Users.remove_user(users_file_path, user);
                user.booked_flights.Add(new BookedFlight($"{flight.flight_number}|{flight.date}", selected_seats));
                Users.add_user(user, users_file_path);
                message = all_messages.SUCCESSFULL.ToString();
            }
            catch
            {
                message = all_messages.FAILED.ToString();
            }
        }

        /// <summary>
        /// takes the search data and finds all the active flights that match it
        /// it creates a list of outbound flights and return flights that have enough space 
        /// for the amount of passengers selected and sends the list
        /// </summary>
        /// <param name="message"></param>
        private void handle_search(ref string message)
        {
            if (user == null || this.tcpClient == null)
            {
                message = all_messages.FAILED.ToString();
                return;
            }

            try
            {
                FlightSearchData search_data = JsonSerializer.Deserialize<FlightSearchData>(message);
                if (search_data.return_date < search_data.departure_date || search_data.departure_date < DateTime.Now)
                {
                    message = all_messages.FAILED.ToString();
                }

                List<Flight> getAllFlights()
                {
                    try
                    {
                        List<Flight> flights = new List<Flight>();
                        string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "flights.csv");

                        if (!File.Exists(filePath))
                        {
                            throw new FileNotFoundException($"{filePath}: is missing");
                        }

                        using (var streamReader = new StreamReader(filePath))
                        using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                        {
                            flights = csvReader.GetRecords<Flight>().ToList();
                        }
                        return flights;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                List<Flight> all_flights = getAllFlights();
                List<ActiveFlight> departure_flights = new List<ActiveFlight>();
                List<ActiveFlight> return_flights = new List<ActiveFlight>();

                foreach (Flight flight in all_flights)
                {
                    if (search_data.origin.Equals($"{flight.origin_city}, {flight.origin_country}", StringComparison.OrdinalIgnoreCase) &&
                        search_data.destination.Equals($"{flight.destination_city}, {flight.destination_country}", StringComparison.OrdinalIgnoreCase))
                    {
                        addFlights(flight, departure_flights, search_data.departure_date, search_data.flight_class);
                    }

                    if (search_data.destination.Equals($"{flight.origin_city}, {flight.origin_country}", StringComparison.OrdinalIgnoreCase) &&
                        search_data.origin.Equals($"{flight.destination_city}, {flight.destination_country}", StringComparison.OrdinalIgnoreCase))
                    {
                        addFlights(flight, return_flights, search_data.return_date, search_data.flight_class);
                    }
                }

                void addFlights(Flight flight, List<ActiveFlight> flights, DateTime date, string flight_class)
                {
                    List<string> active_days = flight.active_days.Trim('[', ']').Split(' ').ToList();
                    List<string> times = flight.times.Trim('[', ']').Replace(" ", "").Split(',').ToList();
                    int dayofweek = (int)date.DayOfWeek + 1;
                    if (active_days.Contains(dayofweek.ToString()))
                    {
                        for (int i = 0; i < flight.flights_per_day; i++)
                        {
                            ActiveFlight f = ActiveFlightsManager.found_flight(flight.id, times[i], date, active_flights_path);
                            if (f != null)
                            {
                                if (f.available(search_data.passengers, search_data.flight_class))
                                {
                                    flights.Add(f);
                                }
                            }
                            else
                            {
                                ActiveFlight activeFlight = new ActiveFlight();
                                activeFlight.copy(flight, date, times[i]);
                                flights.Add(activeFlight);
                            }
                        }
                    }
                }

                message = all_messages.SUCCESSFULL.ToString() + JsonSerializer.Serialize(departure_flights) + "|" + JsonSerializer.Serialize(return_flights);
            }
            catch
            {
                message = all_messages.FAILED.ToString();
            }
        }

        /// <summary>
        /// sends the name of the user
        /// if the profile picture is not null it sends the picture aswell
        /// </summary>
        /// <param name="message"></param>
        private void getProfilePicture(ref string message)
        {
            try
            {
                if (this.user == null) message = all_messages.FAILED.ToString();
                else if (!this.user.loged_in)
                {
                    message = all_messages.FAILED.ToString();
                }
                else
                {
                    if (this.user.profile_picture == null)
                    {
                        message = $"{all_messages.SUCCESSFULL.ToString()}{this.user.name}";
                    }
                    else
                    {
                        message = $"{all_messages.SUCCESSFULL.ToString()}{this.user.name},{Convert.ToBase64String(this.user.profile_picture)}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                message = all_messages.FAILED.ToString();
            }
        }
        /// <summary>
        /// removes the user from the online users list
        /// updates the chat_online property of the user to be false
        /// </summary>
        /// <param name="message"></param>
        public void handle_logout(ref string message)
        {

            if (this.user == null)
            {
                return;
            }
            try
            {
                OnlineUsersManager.RemoveUser(user);
                this.is_user_active.Cancel();
                Users.remove_user(users_file_path, user);
                user.chat_online = false;
                Users.add_user(user, users_file_path);
                user = null;

            }
            catch { }

        }
        /// <summary>
        /// gets the user data and checks that it is valid
        /// if its valid it checks that the user does not already exist and adds the user
        /// to the users file
        /// otherwise it sends a faild message
        /// </summary>
        /// <param name="message"></param>
        public void handle_signup(ref string message)
        {
            
            try
            {
                User user = JsonSerializer.Deserialize<User>(message);
                List<User> users = Users.get_users(users_file_path);
                
                //the function checks that all the properties of the user data
                //is valid
                bool is_valid()
                {
                    if (string.IsNullOrWhiteSpace(user.name)) return false;
                    if (string.IsNullOrWhiteSpace(user.email)) return false;
                    if (string.IsNullOrWhiteSpace(user.password)) return false;
                    if (user.birth_date == null) return false;
                    if (user.loged_in) return false;
                    string pattern = @"^[A-Za-z]{2,} [A-Za-z]{2,}$";
                    if (!Regex.IsMatch(user.name.Trim(), pattern)) return false;
                    pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).{8,}$";
                    //if (!Regex.IsMatch(user.password.Trim(), pattern))
                    //{
                    //    return false;
                    //}
                    try
                    {
                        MailAddress valid_email = new MailAddress(user.email);
                    }
                    catch
                    {
                        return false;
                    }

                    if (user.birth_date > DateTime.Now) return false;
                    if ((DateTime.Now - user.birth_date).Days < 18 * 365) return false;
                    if (!string.IsNullOrWhiteSpace(user.address))
                    {
                        List<City> citysList = Data.getWorldCities();
                        List<string> addresses = new List<string>();
                        foreach (City city in citysList)
                        {

                            if (city.city != "" && city.country != "")
                                addresses.Add($"{city.city}, {city.country}");

                        }
                        if (!addresses.Contains(user.address.Trim())) return false;
                    }
                    
                    if (user.profile_picture != null)
                    {
                        try
                        {
                            using (MemoryStream ms = new MemoryStream(user.profile_picture))
                            {
                                Image img = Image.FromStream(ms);

                                if (!img.RawFormat.Equals(ImageFormat.Png) && !img.RawFormat.Equals(ImageFormat.Jpeg))
                                {
                                    return false;
                                }

                            }
                            if(user.profile_picture.Length>1*1024*1024)return false;
                        }
                        catch (Exception)
                        {
                            return false;
                        }
                    }

                    return true;
                }

                if (is_valid())
                {
                    if (!Users.user_found(users, user.email, user.password, false))
                    {
                        user.loged_in = true;
                        byte[] salt = SecurityManager.generate_salt();
                        user.salt = Convert.ToBase64String(salt);
                        byte[] password = SecurityManager.hash_password(user.password, salt);
                        user.password = Convert.ToBase64String(password);
                        this.user = user;
                        OnlineUsersManager.Add(user, tcpClient, this.security);
                        Users.add_user(user, users_file_path);

                        message = all_messages.SUCCESSFULL.ToString();
                        form.Invoke(new Action(() =>
                        {
                            form.create_chat_user(this.user, form);
                        }));
                    }
                    else
                    {

                        message = all_messages.EXISTS.ToString();

                    }

                }
                else
                {

                    message = all_messages.FAILED.ToString();

                }
            }
            catch 
            {
                message = all_messages.FAILED.ToString();
            }

        }
        /// <summary>
        /// checks that the user exists by the email
        /// hashes the password and the salt and checks that they match
        ///if the user is not in the loged in users list it adds him
        /// </summary>
        /// <param name="message"></param>
        public void handle_login(ref string message)
        {
            try
            {
                Dictionary<string, string> data = JsonSerializer.Deserialize<Dictionary<string, string>>(message);

                string email = data.Keys.First();
                string password = data[email];
                if (Users.user_found(Users.get_users(users_file_path), email, password, true))
                {

                    User user = Users.get_user(Users.get_users(users_file_path), email);
                    if (OnlineUsersManager.Contains(email))
                    {
                        message = all_messages.EXISTS.ToString();
                    }
                    else
                    {
                        message = all_messages.SUCCESSFULL.ToString();
                        user.loged_in = true;
                        this.user = user;
                        OnlineUsersManager.Add(user, tcpClient, this.security);

                    }
                }
                else
                {
                    message = all_messages.FAILED.ToString();
                }
            }
            catch
            {
                message = all_messages.FAILED.ToString();
            }

        }


    }
}
