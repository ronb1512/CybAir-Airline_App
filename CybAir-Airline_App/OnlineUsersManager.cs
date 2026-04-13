using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static CybAir_Airline_App.Data;

namespace CybAir_Airline_App
{
    static class OnlineUsersManager
    {
        private static Dictionary<User, (TcpClient, SecurityManager)> loged_in_users = new Dictionary<User, (TcpClient, SecurityManager)>();
        /// <summary>
        /// adds the user, tcpclient and security instance to the dictionary
        /// </summary>
        /// <param name="user"></param>
        /// <param name="client"></param>
        /// <param name="security"></param>
        public static void Add(User user, TcpClient client, SecurityManager security)
        {
            loged_in_users[user] = (client, security);
        }
        /// <summary>
        /// return true if the loged_in_users dictionary contains a user as one of its keys that matches the given email
        /// otherwise returns false
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool Contains(string email)
        {
            foreach (User user in loged_in_users.Keys)
            {
                if (user.email.Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// returns a tuple of TcpClient and SecurityManager that match the user in the loged_in_users 
        /// dicionary who's email matches the given email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static (TcpClient, SecurityManager) getConnection(string email)
        {

            foreach (KeyValuePair<User, (TcpClient, SecurityManager)> user in loged_in_users)
            {
                if (user.Key.email.Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    return user.Value;
                }
            }
            return (null, null);

        }
        /// <summary>
        /// finds the user to from the dicionary by the email and removes it if it exists
        /// </summary>
        /// <param name="user"></param>
        public static void RemoveUser(User user)
        {
            User user_to_remove = loged_in_users.Select(kv => kv.Key).FirstOrDefault(u => u.email.Equals(user.email, StringComparison.OrdinalIgnoreCase));
            if (user_to_remove != null)
                loged_in_users.Remove(user_to_remove);
        }
        /// <summary>
        /// returns the list of the loged in users
        /// </summary>
        /// <returns></returns>
        public static IReadOnlyCollection<User> GetOnlineUsers()
        {
            return loged_in_users.Keys.ToList().AsReadOnly();
        }

    }

}
