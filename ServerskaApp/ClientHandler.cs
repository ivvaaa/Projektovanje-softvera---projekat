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
                                    Console.WriteLine("Login uspešan za korisnika: "+dbUser.Username);
                                    break;
                                }
                            case Operacija.UbaciKnjigu:
                                {
                                    var knjiga = JsonSerializer.Deserialize<Knjiga>((JsonElement)z.Podaci)!;
                                    k.UbaciKnjigu(knjiga);

                                    serializer.Send(new Odgovor
                                    {
                                        Signal = true,
                                        Poruka = "Knjiga je uspešno ubačena.",
                                        Podaci = null
                                    });
                                    Console.WriteLine("Ubačena knjiga: " + knjiga.Naziv);
                                    break;
                                }

                            case Operacija.PretraziKnjigu:
                                {
                                    var kriterijum = z.Podaci?.ToString() ?? "";
                                    List<Knjiga> lista;

                                    if (string.IsNullOrWhiteSpace(kriterijum))
                                    {
                                        lista = k.VratiSveKnjige();
                                    }
                                    else
                                    {
                                        lista = k.PretraziKnjige(kriterijum);
                                    }

                                    serializer.Send(new Odgovor
                                    {
                                        Signal = true,
                                        Poruka = "OK",
                                        Podaci = lista
                                    });
                                    Console.WriteLine("Vraćeno "+lista.Count+" knjiga.");
                                    break;
                                }

                            case Operacija.IzmeniKnjigu:
                                {
                                    var knjiga = JsonSerializer.Deserialize<Knjiga>((JsonElement)z.Podaci)!;
                                    k.IzmeniKnjigu(knjiga);

                                    serializer.Send(new Odgovor
                                    {
                                        Signal = true,
                                        Poruka = "Knjiga je uspešno izmenjena.",
                                        Podaci = null
                                    });
                                    Console.WriteLine("Izmenjena knjiga sa ID: "+knjiga.Id);
                                    break;
                                }

                            case Operacija.ObrisiKnjigu:
                                {
                                    var id = ((JsonElement)z.Podaci).GetInt64();
                                    k.ObrisiKnjigu(id);

                                    serializer.Send(new Odgovor
                                    {
                                        Signal = true,
                                        Poruka = "Knjiga je uspešno obrisana.",
                                        Podaci = null
                                    });
                                    Console.WriteLine("Obrisana knjiga ID: "+id);
                                    break;
                                }

                            case Operacija.KreirajClana:
                                {
                                    var clan = JsonSerializer.Deserialize<Clan>((JsonElement)z.Podaci)!;
                                    bool uspeh = k.KreirajClana(clan);
                                    serializer.Send(new Odgovor
                                    {
                                        Signal = uspeh,
                                        Poruka = uspeh ? "Član uspešno kreiran." : "Greška pri kreiranju člana.",
                                        Podaci = null
                                    });
                                    break;
                                }

                            case Operacija.PretraziClana:
                                {
                                    string kriterijum = z.Podaci?.ToString() ?? "";
                                    var lista = k.PretraziClanove(kriterijum);
                                    serializer.Send(new Odgovor
                                    {
                                        Signal = true,
                                        Poruka = "OK",
                                        Podaci = lista
                                    });
                                    break;
                                }

                            case Operacija.IzmeniClana:
                                {
                                    var clan = JsonSerializer.Deserialize<Clan>((JsonElement)z.Podaci)!;
                                    bool uspeh = k.IzmeniClana(clan);
                                    serializer.Send(new Odgovor
                                    {
                                        Signal = uspeh,
                                        Poruka = uspeh ? "Član uspešno izmenjen." : "Greška pri izmeni člana.",
                                        Podaci = null
                                    });
                                    break;
                                }

                            case Operacija.ObrisiClana:
                                {
                                    long id = Convert.ToInt64(z.Podaci?.ToString());
                                    bool uspeh = k.ObrisiClana(id);
                                    serializer.Send(new Odgovor
                                    {
                                        Signal = uspeh,
                                        Poruka = uspeh ? "Član uspešno obrisan." : "Greška pri brisanju člana.",
                                        Podaci = null
                                    });
                                    break;
                                }

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
