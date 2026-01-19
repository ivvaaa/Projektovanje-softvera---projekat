using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text.Json;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using Domeni;
using Zajednicki;



namespace KlijentskaAplikacija.UIKontroler
{
    internal class Komunikacija
    {
        public static Komunikacija instance;
        public static Komunikacija Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new Komunikacija();
                }
                return instance;
            }
        }
        private Komunikacija() { }

        private JsonNetworkSerializer serializer;
        private Socket soket;

        public void PoveziSe()
        {
            if (soket != null && soket.Connected && serializer != null) return; // vec povezano

            try { soket?.Shutdown(SocketShutdown.Both); } catch { }  //brisanje starog
            try { soket?.Close(); } catch { }
            soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            soket.Connect("127.0.0.1", 9999);
            serializer = new JsonNetworkSerializer(soket);

        }

        public  Bibliotekar? PrijaviBibliotekara(Bibliotekar bibliotekar)
        {
            PoveziSe();
            Zahtev z=new Zahtev { 
            Operacija=Operacija.PrijaviBibliotekara,
            Podaci=bibliotekar
            };

            serializer.Send(z);
            Odgovor o = serializer.Receive<Odgovor>();

            if (o.Signal)
            {
                Bibliotekar b = JsonSerializer.Deserialize<Bibliotekar>((JsonElement)o.Podaci);
                return b;
            }
            else
            {
                return null;
            }
        }








    }
}
