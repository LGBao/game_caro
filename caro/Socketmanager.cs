using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace caro
{
    class Socketmanager
    {

        #region client
        Socket client; 
        public bool ConnectServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP),PORT);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
           

            try
            {
                client.Connect(iep);
                return true;
            }

            catch
            {
                return false;
            }
        }


        #endregion
        #region server

        Socket server;
        public void CreateServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), PORT);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(iep);
            server.Listen(10);


            Thread acceptClient = new Thread(() =>
            {
                client = server.Accept();
            });
            acceptClient.IsBackground = true;
            acceptClient.Start();


        }

        #endregion
        #region Both
        public string IP = "192.168.1.1";
        public int PORT = 9999;
        public bool isServer = true;
        public const int buffer = 1024;
        public bool Send(object data)
        {
            byte[] sendData = serializeData(data);
            
            return SendData(client, sendData);
            
         
        }
        public object Receive()
        {
            byte[] Receivedata = new byte[buffer];
            bool isOK = ReceiveData(client, Receivedata);

            return DEserializeData(Receivedata);
        }
        public bool SendData(Socket target,byte[] data)
        {
            return target.Send(data) == 1 ? true : false;
        }
        public bool ReceiveData(Socket target, byte[] data)
        {
            return target.Receive(data) == 1 ? true : false;
        }

        //lấy IP v4 của card mạng
        public string getLocalIPV4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach(NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if(item.NetworkInterfaceType == _type && item.OperationalStatus==OperationalStatus.Up)
                {
                    foreach(UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if(ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }    
                    }    
                }       
            }
            return output;
        }
        //phân tích thành byte
        public byte[] serializeData(Object o)
        {
            MemoryStream ms = new MemoryStream(); //tạo stream để lưu trữ
            BinaryFormatter bf1 = new BinaryFormatter();// format của kiểu byte
            bf1.Serialize(ms, o);
            return ms.ToArray();
        }
        //biến byte thành object
        public object DEserializeData(byte[] thebyteArray)
        {
            MemoryStream ms = new MemoryStream(thebyteArray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }

        #endregion
    }
}
