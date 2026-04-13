using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CybAir_Airline_App
{
    static class ConnectionManager
    {
        public static string server_ip { get; set; }
        public static int port = 6000;
        public static TcpClient tcp_client { get; set; }
        public static NetworkStream tcp_stream { get; set; }
        public static StreamReader reader { get; set; }
        public static StreamWriter writer { get; set; }
        public static bool listening_for_messages = false;
        public static SecurityManager security { get; set; }
        /// <summary>
        /// closes and disposes all the properties related to the TCP connection with the server
        /// </summary>
        /// <returns></returns>
        public static bool log_out()
        {
            if (tcp_client == null) return false;
            try
            {
                writer.Close();
                reader.Close();
                tcp_stream.Close();
                tcp_client.Close();
                tcp_client.Dispose();
                tcp_client = null;
                tcp_stream = null;
                reader = null;
                writer = null;
                listening_for_messages = false;
                security.aes.Dispose();
                security.aes = null;
                security.writer = null;
                security.reader = null;

                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// Creates and returns StreamReader and StreamWriter for the given TcpClient.
        /// Throws if client is null or disconnected.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static (StreamReader, StreamWriter) get_reader_writer(TcpClient client)
        {
            if (client == null || !client.Connected)
            {
                throw new InvalidOperationException("bad connection!");
            }
            NetworkStream nws = client.GetStream();
            StreamReader reader = new StreamReader(nws, new UTF8Encoding(false));
            StreamWriter writer = new StreamWriter(nws, new UTF8Encoding(false)) { AutoFlush = true };
            return (reader, writer);
        }
    }
}
