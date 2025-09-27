using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Domeni;
using PoslovnaLogika;
using Zajednicki;
using System.Net.Sockets;
using System.Text.Json;


namespace ServerskaApp
{
    internal class ClientHandler
    {
        private Socket klijentSoket;

        public ClientHandler(Socket klijentSoket)
        {
            this.klijentSoket = klijentSoket;
        }

        internal void Handle()
        {
            JsonNetworkSerializer serializer= new JsonNetworkSerializer(klijentSoket);

            while (true)
            {
                Kontoler k= new Kontoler();
                Zahtev z=serializer.Receive<Zahtev>();
                Console.WriteLine("Stigao je zahtev od klijenta:{z.Operacija}");

                try
                {
                    if (z.Operacija == Operacija.PrijaviBibliotekara)
                    {
                        Bibliotekar b = JsonSerializer.Deserialize<Bibliotekar>((JsonElement)z.Podaci);

                        Bibliotekar bOdgovor = k.PrijaviBibliotekara(b);

                        Odgovor o = new Odgovor
                        {
                            Signal =true,
                            Poruka="Korisnik uspesno prijavljen!",
                            Podaci=bOdgovor
                        };
                        serializer.Send(o);
                        Console.WriteLine("Bibliotekaru je poslat odgovor. Uspeno prijavljivanje!");
                    }
                    //else if (z.Operacija==Operacija.V){

                    //}


                }
                catch (Exception e)
                {
                    Odgovor o = new Odgovor
                    {
                        Signal = false,
                        Poruka = e.Message
                    };
                    serializer.Send(o);
                    Console.WriteLine("Doslo je do greske, Bibliotekaru je poslata poruka "+ e.Message);
                }
            }

        }






    }
}
