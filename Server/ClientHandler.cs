using System.Diagnostics;
using System.Net.Sockets;
using System.Text.Json;
using Domeni;
using Zajednicki;

namespace Server
{
    internal class ClientHandler
    {
        private Socket klijent;
        private readonly List<ClientHandler> klijenti;
        private JsonNetworkSerializer serializer;

        public ClientHandler(Socket klijent, List<ClientHandler> klijenti)
        {
            this.klijent = klijent;
            this.klijenti = klijenti;
            serializer = new JsonNetworkSerializer(klijent);
        }

        public void Handle()
        {
            try
            {
                while (true)
                {
                    Zahtev zahtev = serializer.Receive<Zahtev>();
                    Debug.WriteLine("Primljen zahtev: " + zahtev.Operacija);
                    Odgovor odgovor = ProcesuirajZahtev(zahtev);
                    serializer.Send(odgovor);
                }
            }
            catch (SocketException ex)
            {
                Debug.WriteLine("Klijent diskonektovan: " + ex.Message);
            }
            catch (IOException ex)
            {
                Debug.WriteLine("Klijent diskonektovan: " + ex.Message);
            }
            finally
            {
                klijenti.Remove(this);
                serializer.Close();
            }
        }

        private Odgovor ProcesuirajZahtev(Zahtev zahtev)
        {
            Odgovor odgovor = new Odgovor();
            odgovor.Signal = true;

            try
            {
                switch (zahtev.Operacija)
                {
                    case Operacija.PrijaviBibliotekara:
                        var b = serializer.ReadType<Bibliotekar>(zahtev.Podaci);
                        var result = Kontroler.Instance.PrijaviBibliotekara(b);
                        if (result == null)
                        {
                            odgovor.Signal = false;
                            odgovor.Poruka = "Neispravni kredencijali.";
                        }
                        else
                        {
                            odgovor.Podaci = result;
                            odgovor.Poruka = "OK";
                        }
                        break;

                    case Operacija.UbaciKnjigu:
                        var knjiga = serializer.ReadType<Knjiga>(zahtev.Podaci);
                        Kontroler.Instance.SacuvajKnjigu(knjiga);
                        odgovor.Poruka = "Knjiga uspešno sačuvana.";
                        break;

                    case Operacija.PretraziKnjigu:
                        string kritKnjiga = zahtev.Podaci?.ToString() ?? "";
                        List<Knjiga> listaKnjiga;
                        if (string.IsNullOrWhiteSpace(kritKnjiga))
                            listaKnjiga = Kontroler.Instance.VratiSveKnjige();
                        else
                            listaKnjiga = Kontroler.Instance.PretraziKnjige(kritKnjiga);
                        odgovor.Podaci = listaKnjiga;
                        odgovor.Poruka = "OK";
                        break;

                    case Operacija.IzmeniKnjigu:
                        var knjigaIzmeni = serializer.ReadType<Knjiga>(zahtev.Podaci);
                        Kontroler.Instance.IzmeniKnjigu(knjigaIzmeni);
                        odgovor.Poruka = "Knjiga uspešno izmenjena.";
                        break;

                    case Operacija.ObrisiKnjigu:
                        var idKnjiga = ((JsonElement)zahtev.Podaci).GetInt64();
                        Kontroler.Instance.ObrisiKnjigu(idKnjiga);
                        odgovor.Poruka = "Knjiga uspešno obrisana.";
                        break;

                    case Operacija.KreirajClana:
                        var clan = serializer.ReadType<Clan>(zahtev.Podaci);
                        Kontroler.Instance.SacuvajClana(clan);
                        odgovor.Poruka = "Član uspešno kreiran.";
                        break;

                    case Operacija.PretraziClana:
                        string kritClan = zahtev.Podaci?.ToString() ?? "";
                        var listaClan = Kontroler.Instance.PretraziClanove(kritClan);
                        odgovor.Podaci = listaClan;
                        odgovor.Poruka = "OK";
                        break;

                    case Operacija.IzmeniClana:
                        var clanIzmeni = serializer.ReadType<Clan>(zahtev.Podaci);
                        Kontroler.Instance.IzmeniClana(clanIzmeni);
                        odgovor.Poruka = "Član uspešno izmenjen.";
                        break;

                    case Operacija.ObrisiClana:
                        long idClan = Convert.ToInt64(zahtev.Podaci?.ToString());
                        Kontroler.Instance.ObrisiClana(idClan);
                        odgovor.Poruka = "Član uspešno obrisan.";
                        break;

                    case Operacija.KreirajPozajmicu:
                        var pozajmica = serializer.ReadType<Pozajmica>(zahtev.Podaci);
                        long idPoz = Kontroler.Instance.KreirajPozajmicu(pozajmica);
                        odgovor.Signal = idPoz > 0;
                        odgovor.Podaci = idPoz;
                        odgovor.Poruka = idPoz > 0 ? "Pozajmica kreirana." : "Greška.";
                        break;

                    case Operacija.PretraziPozajmicu:
                        string kritPoz = zahtev.Podaci?.ToString() ?? "";
                        var listaPoz = Kontroler.Instance.PretraziPozajmice(kritPoz);
                        odgovor.Podaci = listaPoz;
                        odgovor.Poruka = "OK";
                        break;

                    default:
                        odgovor.Signal = false;
                        odgovor.Poruka = "Nepodržana operacija.";
                        break;
                }
            }
            catch (Exception ex)
            {
                odgovor.Signal = false;
                odgovor.Poruka = ex.Message;
                Debug.WriteLine("Greška: " + ex.Message);
            }

            return odgovor;
        }

        internal void Close()
        {
            klijent?.Close();
        }
    }
}