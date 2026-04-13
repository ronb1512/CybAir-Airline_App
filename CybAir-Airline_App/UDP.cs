using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CybAir_Airline_App
{
    static class UDP
    {

        const int port = 3500;
        /// <summary>
        /// asks if the client can become the server
        /// </summary>
        /// <returns></returns>
        public static bool canIBeServer()
        {

            UdpClient UDP_client = new UdpClient() { EnableBroadcast = true };
            IPEndPoint all_points = new IPEndPoint(IPAddress.Broadcast, port);
            SecurityManager securityManager = new SecurityManager();

            byte[] request_msg = Encoding.UTF8.GetBytes($"{all_messages.CANI.ToString()}|{securityManager.get_public_key()}");
            IPEndPoint response_points = new IPEndPoint(IPAddress.Any, 0);
            //sends an encrypted request with the udpclient to all the devices on the network on the port
            //sets timeout on the tcpclient
            void request()
            {
                UDP_client.Send(request_msg, request_msg.Length, all_points);
                UDP_client.Client.ReceiveTimeout = 1000;
            }
            //if the timeout runs out or any other error occurs returns false 
            //reads the message with the udpclient, decrypts it and sets the ip of the server and the public rsa key of the server
            //returns true
            bool negative_response()
            {
                try
                {
                    byte[] reply = UDP_client.Receive(ref response_points);

                    string msg = Encoding.UTF8.GetString(reply);
                    byte[] decrypted_bytes = null;

                    decrypted_bytes = Server.rsa.Decrypt(Convert.FromBase64String(msg.Split('~')[0]), RSAEncryptionPadding.OaepSHA1);


                    string decrypted_string = Encoding.UTF8.GetString(decrypted_bytes);

                    if (decrypted_string.StartsWith(all_messages.FAILED.ToString()))
                    {

                        decrypted_string = decrypted_string.Substring(all_messages.FAILED.ToString().Length);

                        ConnectionManager.server_ip = decrypted_string;
                        ConnectionManager.security = new SecurityManager();
                        ConnectionManager.security.rsa_from_public_key(msg.Split('~')[1]);
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (SocketException ex)
                when (ex.SocketErrorCode == SocketError.TimedOut)
                {

                    return false;
                }
                catch
                {

                    return false;
                }


            }
            request();
            if (negative_response())
            {

                UDP_client.Close();
                return false;
            }
            UDP_client.Close();
            return true;
        }
        /// <summary>
        /// activates a thread that runs as long as the server is active
        /// denies all the clients from becoming the server
        /// </summary>
        public static void denyOthers()
        {
            SecurityManager security = new SecurityManager();
            UdpClient socket = new UdpClient();
            IPEndPoint point = new IPEndPoint(IPAddress.Any, port);
            socket.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            socket.Client.Bind(point);
            socket.Client.ReceiveTimeout = 1000;
            //if the timeout runs out or any other error occurs returns false
            //recieves a request message from the tcpclient and sets the public key of the client rsa instance
            //returns true
            bool someone_requested()
            {
                try
                {
                    byte[] request_msg = socket.Receive(ref point);
                    string request_msg_str = Encoding.UTF8.GetString(request_msg);
                    byte[] msg = Encoding.UTF8.GetBytes(request_msg_str.Split('|')[0]);
                    string public_key = request_msg_str.Split('|')[1];

                    if (msg.SequenceEqual(Encoding.UTF8.GetBytes(all_messages.CANI.ToString())))
                    {

                        security.rsa_from_public_key(public_key);
                        return true;
                    }
                    return false;
                }
                catch (SocketException ex)
                when (ex.SocketErrorCode == SocketError.TimedOut)
                {

                    return false;
                }
                catch { return false; }

            }

            //sends a response to the client with the IP of the server and the public rsa key of the server
            void deny()
            {
                string IP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Last(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();
                byte[] encrypted = security.rsa.Encrypt(Encoding.UTF8.GetBytes(all_messages.FAILED.ToString() + IP), RSAEncryptionPadding.OaepSHA1);
                byte[] response =
                    Encoding.UTF8.GetBytes(
                        Convert.ToBase64String(encrypted) +
                        "~"
                        + Server.rsa.ToXmlString(false));

                socket.Send(response, response.Length, point);
            }

            UI.startThread(() =>
            {

                while (!Server.is_running.IsCancellationRequested)
                {
                    if (someone_requested())
                        deny();
                    Thread.Sleep(10);
                }
            });
        }
    }
}
