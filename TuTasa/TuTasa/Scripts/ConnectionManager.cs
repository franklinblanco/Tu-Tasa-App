using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace TuTasa.Scripts
{
    class ConnectionManager
    {
        #region singleton pattern
        private static ConnectionManager instance = null;
        public static ConnectionManager Instance { get { if (instance == null) { instance = new ConnectionManager(); } return instance; } } //Singleton pattern
        #endregion

        #region connection variables
        private const string _serveripaddress = "104.248.233.17";
        private const int _serverport = 5001;
        private bool isconnected = false;

        TcpClient clientSocket;
        NetworkStream clientStream;
        #endregion

        public bool Connect()
        {
            try
            {
                clientSocket = new TcpClient();
                clientSocket.Connect(IPAddress.Parse(_serveripaddress), _serverport);
                clientStream = clientSocket.GetStream();
                isconnected = true;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }
        public void DisconnectFromServer()
        {
            clientSocket.Close();
            clientStream.Close();
        }
        public string AskForHomePage()
        {
            if (!isconnected)
            {
                DisconnectFromServer();
                Connect();
            }
            SendMessage("1001 mainpage");
            string wholeInfo = ReceiveMessage();
            isconnected = false;
            return wholeInfo;
        }

        #region message sender
        private bool SendMessage(string message)
        {
            try
            {
                byte[] msg = encodeMessage(message);
                clientStream.Write(msg, 0, msg.Length);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }
        #endregion

        #region message receiver
        private string ReceiveMessage()
        {
            byte[] message = new byte[1024];
            try
            {
                int messagesize = clientStream.Read(message, 0, message.Length);
                Array.Resize(ref message, messagesize);
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            return decodeMessage(message);
        }
        #endregion

        #region encoders
        private string decodeMessage(byte[] message)
        {
            return Encoding.Default.GetString(message);
        }
        private byte[] encodeMessage(string message)
        {
            return Encoding.Default.GetBytes(message);
        }
        #endregion
    }
}
