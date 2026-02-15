using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace Server
{
        internal class Server
        {
            private Socket socket;
            private List<ClientHandler> klijenti = new List<ClientHandler>();

            public Server()
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }

            public void Start()
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);

                socket.Bind(endPoint);
                socket.Listen(10);

                Thread acceptClientsThread = new Thread(AcceptClients);
                acceptClientsThread.IsBackground = true;
                acceptClientsThread.Start();
            }

            private void AcceptClients()
            {
                try
                {
                    while (true)
                    {
                        Socket klijentskiSoket = socket.Accept();
                        Debug.WriteLine("Novi klijent povezan!");

                        ClientHandler handler = new ClientHandler(klijentskiSoket, klijenti);
                        klijenti.Add(handler);

                        Thread nitKlijenta = new Thread(handler.Handle);
                        nitKlijenta.IsBackground = true;
                        nitKlijenta.Start();
                    }
                }
                catch (SocketException ex)
                {
                    Debug.WriteLine("SocketException: " + ex.Message);
                }
                catch (IOException ex)
                {
                    Debug.WriteLine("IOException: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception: " + ex.Message);
                }
            }

            internal void Stop()
            {
                foreach (var klijent in klijenti)
                {
                    klijent.Close();
                }
                klijenti.Clear();
                socket?.Close();
            }
        }
    }
