using System;
using System.IO;                // IOException
using System.Net.Sockets;
using System.Text.Json;
using Domeni;
using PoslovnaLogika;
using Zajednicki;

namespace ServerskaApp
{
    internal class ClientHandler
    {
        private readonly Socket klijentSoket;

        public ClientHandler(Socket klijentSoket)
        {
            this.klijentSoket = klijentSoket;
        }

        internal void Handle()
        {
            var serializer = new JsonNetworkSerializer(klijentSoket);
            Kontoler k = new Kontoler(); 

            try
            {
                while (true)
                {
                    Zahtev z;
                    try
                    {
                        z = serializer.Receive<Zahtev>();
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Klijent se diskonektovao.");
                        break;
                    }

                    Console.WriteLine($"Stigao je zahtev od klijenta: {z.Operacija}");

                    try
                    {
                        switch (z.Operacija)
                        {
                            case Operacija.PrijaviBibliotekara:
                                {
                                    var b = JsonSerializer.Deserialize<Bibliotekar>((JsonElement)z.Podaci)!;
                                    var dbUser = k.PrijaviBibliotekara(b);

                                    if (dbUser == null)  //nema takvog bibliotekara
                                    {
                                        serializer.Send(new Odgovor
                                        {
                                            Signal = false,
                                            Poruka = "Neispravni kredencijali.",
                                            Podaci = null
                                        });
                                        Console.WriteLine("Login neuspešan: neispravni kredencijali.");
                                        break; // sledeci zahtev
                                    }

                                    serializer.Send(new Odgovor
                                    {
                                        Signal = true,
                                        Poruka = "OK",
                                        Podaci = dbUser
                                    });
                                    Console.WriteLine($"Login uspešan za korisnika: {dbUser.Username}");
                                    break;
                                }
                            //case Operacija.UbaciKnjigu:
                            //    {

                            //    }

                            default:
                                {
                                    serializer.Send(new Odgovor
                                    {
                                        Signal = false,
                                        Poruka = "Nepodržana operacija.",
                                        Podaci = null
                                    });
                                    break;
                                }
                        }
                    }
                    catch (Exception e)
                    {
                        serializer.Send(new Odgovor
                        {
                            Signal = false,
                            Poruka = e.Message,
                            Podaci = null
                        });
                        Console.WriteLine("Došlo je do greške: " + e.Message);
                    }
                }
            }
            finally
            {
                try { klijentSoket.Shutdown(SocketShutdown.Both); } catch { }
                klijentSoket.Close();
            }
        }
    }
}
