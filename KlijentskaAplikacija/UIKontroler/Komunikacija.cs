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

        private JsonNetworkSerializer? serializer;
        private Socket? soket;

        public void PoveziSe()
        {
            if (soket != null && soket.Connected && serializer != null) return; 

            try { soket?.Shutdown(SocketShutdown.Both); } catch { }  //brisanje starog
            try { soket?.Close(); } catch { }
            soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            soket.Connect("127.0.0.1", 9999);
            serializer = new JsonNetworkSerializer(soket);

        }

        public  Bibliotekar? PrijaviBibliotekara(Bibliotekar bibliotekar)
        {
            PoveziSe();
            Zahtev z=new Zahtev 
            { 
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

        //--------------------KNJIGA
        public bool UbaciKnjigu(Knjiga knjiga)
        {
            PoveziSe();
            Zahtev z = new Zahtev
            {
                Operacija = Operacija.UbaciKnjigu,
                Podaci = knjiga
            };

            serializer.Send(z);
            Odgovor o = serializer.Receive<Odgovor>();

            return o.Signal;
        }

        public List<Knjiga> PretraziKnjige(string kriterijum = "")
        {
            PoveziSe();
            Zahtev z = new Zahtev
            {
                Operacija = Operacija.PretraziKnjigu,
                Podaci = kriterijum
            };

            serializer.Send(z);
            Odgovor o = serializer.Receive<Odgovor>();

            if (o.Signal)
            {
                var lista = JsonSerializer.Deserialize<List<Knjiga>>((JsonElement)o.Podaci);
                if (lista == null)
                {
                    return new List<Knjiga>();
                }
                return lista;
            }
            else
            {
                return new List<Knjiga>();
            }
        }

        public bool IzmeniKnjigu(Knjiga knjiga)
        {
            PoveziSe();
            Zahtev z = new Zahtev
            {
                Operacija = Operacija.IzmeniKnjigu,
                Podaci = knjiga
            };

            serializer.Send(z);
            Odgovor o = serializer.Receive<Odgovor>();

            return o.Signal;
        }

        public bool ObrisiKnjigu(long id)
        {
            PoveziSe();
            Zahtev z = new Zahtev
            {
                Operacija = Operacija.ObrisiKnjigu,
                Podaci = id
            };

            serializer.Send(z);
            Odgovor o = serializer.Receive<Odgovor>();

            return o.Signal;
        }

        //--------------------CLAN
        public bool KreirajClana(Clan clan)
        {
            PoveziSe();
            Zahtev z = new Zahtev
            {
                Operacija = Operacija.KreirajClana,
                Podaci = clan
            };

            serializer.Send(z);
            Odgovor o = serializer.Receive<Odgovor>();
            return o.Signal;
        }

        public List<Clan> PretraziClanove(string kriterijum)
        {
            PoveziSe();
            Zahtev z = new Zahtev
            {
                Operacija = Operacija.PretraziClana,
                Podaci = kriterijum
            };

            serializer.Send(z);
            Odgovor o = serializer.Receive<Odgovor>();

            if (o.Signal && o.Podaci != null)
            {
                return JsonSerializer.Deserialize<List<Clan>>((JsonElement)o.Podaci) ?? new List<Clan>();
            }
            return new List<Clan>();
        }

        public bool IzmeniClana(Clan clan)
        {
            PoveziSe();
            Zahtev z = new Zahtev
            {
                Operacija = Operacija.IzmeniClana,
                Podaci = clan
            };

            serializer.Send(z);
            Odgovor o = serializer.Receive<Odgovor>();
            return o.Signal;
        }

        public bool ObrisiClana(long id)
        {
            PoveziSe();
            Zahtev z = new Zahtev
            {
                Operacija = Operacija.ObrisiClana,
                Podaci = id
            };

            serializer.Send(z);
            Odgovor o = serializer.Receive<Odgovor>();
            return o.Signal;
        }

        // --------POZAJMICA

        public long KreirajPozajmicu(Pozajmica pozajmica)
        {
            PoveziSe();
            Zahtev z = new Zahtev
            {
                Operacija = Operacija.KreirajPozajmicu,
                Podaci = pozajmica
            };

            serializer.Send(z);
            Odgovor o = serializer.Receive<Odgovor>();

            if (o.Signal)
            {
                return Convert.ToInt64(o.Podaci.ToString());
            }
            return 0;
        }

        public List<Pozajmica> PretraziPozajmice(string kriterijum)
        {
            PoveziSe();
            Zahtev z = new Zahtev
            {
                Operacija = Operacija.PretraziPozajmicu,
                Podaci = kriterijum
            };

            serializer.Send(z);
            Odgovor o = serializer.Receive<Odgovor>();

            if (o.Signal && o.Podaci != null)
            {
                return JsonSerializer.Deserialize<List<Pozajmica>>((JsonElement)o.Podaci) ?? new List<Pozajmica>();
            }
            return new List<Pozajmica>();
        }



    }
}
