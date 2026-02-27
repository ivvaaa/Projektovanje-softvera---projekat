using System.Net.Sockets;
using System.Text.Json;
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
                if (instance == null)
                    instance = new Komunikacija();
                return instance;
            }
        }

        //trenutno ulogovanog bibliotekara
        public static Bibliotekar? UlogovaniBibliotekar { get; set; } = null;

        private Komunikacija() { }

        private JsonNetworkSerializer? serializer;
        private Socket? soket;

        public void PoveziSe()
        {
            if (soket != null && soket.Connected && serializer != null) return;

            try { soket?.Shutdown(SocketShutdown.Both); } catch { }
            try { soket?.Close(); } catch { }
            soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            soket.Connect("127.0.0.1", 9999);
            serializer = new JsonNetworkSerializer(soket);
        }

        //SK9
        public Bibliotekar? PrijaviBibliotekara(Bibliotekar bibliotekar)
        {
            PoveziSe();
            var z = new Zahtev { Operacija = Operacija.PrijaviBibliotekar, Podaci = bibliotekar };
            serializer.Send(z);
            Odgovor o = serializer.Receive<Odgovor>();

            if (o.Signal)
            {
                var b = JsonSerializer.Deserialize<Bibliotekar>((JsonElement)o.Podaci);

                return b;
            }
            return null;
        }

        //knjige
        //SK14 - UbaciKnjiga
        public bool UbaciKnjigu(Knjiga knjiga)
        {
            PoveziSe();
            serializer.Send(new Zahtev { Operacija = Operacija.UbaciKnjigu, Podaci = knjiga });
            Odgovor o = serializer.Receive<Odgovor>();
            return o.Signal;
        }

        public List<Knjiga> VratiSveKnjige()
        {
            PoveziSe();
            serializer.Send(new Zahtev { Operacija = Operacija.VratiSveKnjige });
            Odgovor o = serializer.Receive<Odgovor>();
            if (o.Signal && o.Podaci != null)
                return JsonSerializer.Deserialize<List<Knjiga>>((JsonElement)o.Podaci) ?? new List<Knjiga>();
            return new List<Knjiga>();
        }

        //vratiListuKnjiga(kriterijum) - SK15
        public List<Knjiga> PretraziKnjige(string kriterijum)
        {
            PoveziSe();
            serializer.Send(new Zahtev { Operacija = Operacija.PretraziKnjigu, Podaci = kriterijum });
            Odgovor o = serializer.Receive<Odgovor>();
            if (o.Signal && o.Podaci != null)
                return JsonSerializer.Deserialize<List<Knjiga>>((JsonElement)o.Podaci) ?? new List<Knjiga>();
            return new List<Knjiga>();
        }

        //SK16 - PromeniKnjiga
        public bool IzmeniKnjigu(Knjiga knjiga)
        {
            PoveziSe();
            serializer.Send(new Zahtev { Operacija = Operacija.IzmeniKnjigu, Podaci = knjiga });
            Odgovor o = serializer.Receive<Odgovor>();
            return o.Signal;
        }

        //SK17 - ObrisiKnjiga
        public bool ObrisiKnjigu(long id)
        {
            PoveziSe();
            serializer.Send(new Zahtev { Operacija = Operacija.ObrisiKnjigu, Podaci = id });
            Odgovor o = serializer.Receive<Odgovor>();
            return o.Signal;
        }

        //clanovi
        //SK5 - KreirajClan
        public bool KreirajClana(Clan clan)
        {
            PoveziSe();
            serializer.Send(new Zahtev { Operacija = Operacija.KreirajClana, Podaci = clan });
            Odgovor o = serializer.Receive<Odgovor>();
            return o.Signal;
        }

        //vratiListuSviClan
        public List<Clan> VratiSveClanova()
        {
            PoveziSe();
            serializer.Send(new Zahtev { Operacija = Operacija.VratiSveClanova });
            Odgovor o = serializer.Receive<Odgovor>();
            if (o.Signal && o.Podaci != null)
                return JsonSerializer.Deserialize<List<Clan>>((JsonElement)o.Podaci) ?? new List<Clan>();
            return new List<Clan>();
        }

        //vratiListuClan(kriterijum) - SK6
        public List<Clan> PretraziClanove(string kriterijum)
        {
            PoveziSe();
            serializer.Send(new Zahtev { Operacija = Operacija.PretraziClana, Podaci = kriterijum });
            Odgovor o = serializer.Receive<Odgovor>();
            if (o.Signal && o.Podaci != null)
                return JsonSerializer.Deserialize<List<Clan>>((JsonElement)o.Podaci) ?? new List<Clan>();
            return new List<Clan>();
        }

        //SK7 - PromeniClan
        public bool IzmeniClana(Clan clan)
        {
            PoveziSe();
            serializer.Send(new Zahtev { Operacija = Operacija.IzmeniClana, Podaci = clan });
            Odgovor o = serializer.Receive<Odgovor>();
            return o.Signal;
        }

        //SK8 - ObrisiClan
        public bool ObrisiClana(long id)
        {
            PoveziSe();
            serializer.Send(new Zahtev { Operacija = Operacija.ObrisiClana, Podaci = id });
            Odgovor o = serializer.Receive<Odgovor>();
            return o.Signal;
        }

        //pozajmice
        // SK1 - KreirajPozajmicu
        public long KreirajPozajmicu(Pozajmica pozajmica)
        {
            PoveziSe();
            serializer.Send(new Zahtev { Operacija = Operacija.KreirajPozajmicu, Podaci = pozajmica });
            Odgovor o = serializer.Receive<Odgovor>();
            if (o.Signal)
                return Convert.ToInt64(o.Podaci.ToString());
            return 0;
        }

        //vratiListuPozajmica(kriterijumClan) , prazan kriterijum = sve, SK2
        public List<Pozajmica> PretraziPozajmice(string kriterijum)
        {
            PoveziSe();
            serializer.Send(new Zahtev { Operacija = Operacija.PretraziPozajmicu, Podaci = kriterijum });
            Odgovor o = serializer.Receive<Odgovor>();
            if (o.Signal && o.Podaci != null)
                return JsonSerializer.Deserialize<List<Pozajmica>>((JsonElement)o.Podaci) ?? new List<Pozajmica>();
            return new List<Pozajmica>();
        }

        //PromeniPozajmica - vraćanje knjige
        public bool VratiKnjigu(long idPozajmica, long idKnjiga)
        {
            PoveziSe();
            serializer.Send(new Zahtev
            {
                Operacija = Operacija.VratiKnjigu,
                Podaci = new Dictionary<string, long>
                {
                    { "idPozajmica", idPozajmica },
                    { "idKnjiga", idKnjiga }
                }
            });
            Odgovor o = serializer.Receive<Odgovor>();
            return o.Signal;
        }


    }
}
