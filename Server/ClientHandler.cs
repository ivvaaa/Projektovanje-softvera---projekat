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
                    //SK9
                    case Operacija.PrijaviBibliotekar:
                        var b = serializer.ReadType<Bibliotekar>(zahtev.Podaci);
                        var logBib = Kontroler.Instance.PrijaviBibliotekara(b);
                        if (logBib == null)
                        {
                            odgovor.Signal = false;
                            odgovor.Poruka = "Neispravni kredencijali.";
                        }
                        else
                        {
                            odgovor.Podaci = logBib;
                            odgovor.Poruka = "OK";
                        }
                        break;

                    //SK14
                    case Operacija.UbaciKnjigu:
                        var knjiga = serializer.ReadType<Knjiga>(zahtev.Podaci);
                        Kontroler.Instance.UbaciKnjigu(knjiga);
                        odgovor.Poruka = "Sistem je zapamtio knjigu.";
                        break;

                    //vratiListuSviKnjiga
                    case Operacija.VratiSveKnjige:
                        odgovor.Podaci = Kontroler.Instance.VratiSveKnjige();
                        odgovor.Poruka = "OK";
                        break;

                    //vratiListuKnjiga(kriterijum) - SK15
                    case Operacija.PretraziKnjigu:
                        string kritKnjiga = zahtev.Podaci?.ToString() ?? "";
                        odgovor.Podaci = Kontroler.Instance.PretraziKnjige(kritKnjiga);
                        odgovor.Poruka = "OK";
                        break;

                    //SK16 - PromeniKnjiga
                    case Operacija.IzmeniKnjigu:
                        var knjigaIzmeni = serializer.ReadType<Knjiga>(zahtev.Podaci);
                        Kontroler.Instance.IzmeniKnjigu(knjigaIzmeni);
                        odgovor.Poruka = "Sistem je izmenio knjigu.";
                        break;

                    //SK17 - ObrisiKnjiga
                    case Operacija.ObrisiKnjigu:
                        var idKnjiga = ((JsonElement)zahtev.Podaci).GetInt64();
                        Kontroler.Instance.ObrisiKnjigu(idKnjiga);
                        odgovor.Poruka = "Sistem je obrisao knjigu.";
                        break;

                    //SK5 - KreirajClan
                    case Operacija.KreirajClana:
                        var clan = serializer.ReadType<Clan>(zahtev.Podaci);
                        Kontroler.Instance.KreirajClana(clan);
                        odgovor.Poruka = "Sistem je zapamtio člana.";
                        break;

                    //vratiListuSviClan
                    case Operacija.VratiSveClanova:
                        odgovor.Podaci = Kontroler.Instance.VratiSveClanova();
                        odgovor.Poruka = "OK";
                        break;

                    //vratiListuClan(kriterijum) - SK6
                    case Operacija.PretraziClana:
                        string kritClan = zahtev.Podaci?.ToString() ?? "";
                        odgovor.Podaci = Kontroler.Instance.PretraziClanove(kritClan);
                        odgovor.Poruka = "OK";
                        break;

                    //SK7 - PromeniClan
                    case Operacija.IzmeniClana:
                        var clanIzmeni = serializer.ReadType<Clan>(zahtev.Podaci);
                        Kontroler.Instance.IzmeniClana(clanIzmeni);
                        odgovor.Poruka = "Sistem je izmenio člana.";
                        break;

                    //SK8 - ObrisiClan
                    case Operacija.ObrisiClana:
                        long idClan = Convert.ToInt64(zahtev.Podaci?.ToString());
                        Kontroler.Instance.ObrisiClana(idClan);
                        odgovor.Poruka = "Sistem je obrisao člana.";
                        break;

                    //SK1 - KreirajPozajmica
                    case Operacija.KreirajPozajmicu:
                        var pozajmica = serializer.ReadType<Pozajmica>(zahtev.Podaci);
                        long idPoz = Kontroler.Instance.KreirajPozajmicu(pozajmica);
                        odgovor.Signal = idPoz > 0;
                        odgovor.Podaci = idPoz;
                        odgovor.Poruka = idPoz > 0 ? "Sistem je zapamtio pozajmicu." : "Sistem ne može da zapamti pozajmicu.";
                        break;

                    //vratiListuPozajmica(kriterijumClan) - prazan = sve, SK2
                    case Operacija.PretraziPozajmicu:
                        string kritPoz = zahtev.Podaci?.ToString() ?? "";
                        odgovor.Podaci = Kontroler.Instance.PretraziPozajmice(kritPoz);
                        odgovor.Poruka = "OK";
                        break;

                    //PromeniPozajmica - vraćanje knjige (menja StavkaPozajmice)
                    case Operacija.VratiKnjigu:
                        var podaci = serializer.ReadType<Dictionary<string, long>>(zahtev.Podaci);
                        Kontroler.Instance.VratiKnjigu(podaci["idPozajmica"], podaci["idKnjiga"]);
                        odgovor.Poruka = "Knjiga vraćena.";
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
