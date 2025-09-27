//namespace ServerskaApp
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello, World!");
//        }
//    }
//}

using ServerskaApp;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using Zajednicki;

try
{
    Socket serverskiSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    serverskiSoket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999));
    serverskiSoket.Listen();
    Console.WriteLine("Server je pokrenut!");
    Console.WriteLine("Cekam klijenta...");

    Socket klijentSoket = serverskiSoket.Accept();
    Console.WriteLine("Klijent je povezan!");

    ClientHandler clientHandler = new ClientHandler(klijentSoket);
    clientHandler.Handle();


    Console.ReadLine();
}
catch (SocketException ex)
{
    Console.WriteLine("Greska prilikom pokretanja servera!");
}