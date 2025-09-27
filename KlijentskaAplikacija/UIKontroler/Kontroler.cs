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
    internal class Kontroler
    {
        public static Kontroler instance;
        public static Kontroler Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new Kontroler();
                }
                return instance;
            }
        }

        private Socket soket;
        private Kontroler()
        {
            soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }

        private JsonNetworkSerializer serializer;

        public void PoveziSe()
        {
            try
            {
                soket.Connect("127.0.0.1", 9999);
                serializer = new JsonNetworkSerializer(soket);
            }
            catch (SocketException){
                throw new Exception("Neuspesno poveyivanje sa serverom!");
            }
            
        }

        public  Bibliotekar PrijaviBibliotekara(Bibliotekar bibliotekar)
        {
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
                throw new Exception(o.Poruka);
            }
        }








    }
}
