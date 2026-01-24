using Domeni;
using BrokerBP;

namespace PoslovnaLogika
{
    public class Kontoler
    {
        private Broker bbp=new Broker();

        public Bibliotekar? PrijaviBibliotekara(Bibliotekar b)
        {
            bbp.Connect();
            try
            {
                Bibliotekar bibliotekar = bbp.GetBibliotekarByUserPass(b);
                return bibliotekar;
            }
            finally
            {
                bbp.Disconnect();
            }
        }

        //--------KNJIGA
        public void UbaciKnjigu(Knjiga knjiga)
        {
            bbp.Connect();
            try
            {
                bbp.UbaciKnjigu(knjiga);
            }
            finally
            {
                bbp.Disconnect();
            }
        }

        public List<Knjiga> VratiSveKnjige()
        {
            bbp.Connect();
            try
            {
                return bbp.VratiSveKnjige();
            }
            finally
            {
                bbp.Disconnect();
            }
        }

        public List<Knjiga> PretraziKnjige(string kriterijum)
        {
            bbp.Connect();
            try
            {
                return bbp.PretraziKnjige(kriterijum);
            }
            finally
            {
                bbp.Disconnect();
            }
        }

        public void IzmeniKnjigu(Knjiga knjiga)
        {
            bbp.Connect();
            try
            {
                bbp.IzmeniKnjigu(knjiga);
            }
            finally
            {
                bbp.Disconnect();
            }
        }

        public void ObrisiKnjigu(long id)
        {
            bbp.Connect();
            try
            {
                bbp.ObrisiKnjigu(id);
            }
            finally
            {
                bbp.Disconnect();
            }
        }

        //--------CLAN
        public bool KreirajClana(Clan clan)
        {
            bbp.Connect();
            try
            {
                return bbp.KreirajClana(clan);
            }
            finally
            {
                bbp.Disconnect();
            }
        }

        public List<Clan> PretraziClanove(string kriterijum)
        {
            bbp.Connect();
            try
            {
                return bbp.PretraziClanove(kriterijum);
            }
            finally
            {
                bbp.Disconnect();
            }
        }

        public bool IzmeniClana(Clan clan)
        {
            bbp.Connect();
            try
            {
                return bbp.IzmeniClana(clan);
            }
            finally
            {
                bbp.Disconnect();
            }
        }

        public bool ObrisiClana(long id)
        {
            bbp.Connect();
            try
            {
                return bbp.ObrisiClana(id);
            }
            finally
            {
                bbp.Disconnect();
            }
        }


        // ------- poazjmica

        public long KreirajPozajmicu(Pozajmica p)
        {
            bbp.Connect();
            try
            {
                return bbp.KreirajPozajmicu(p);
            }
            finally
            {
                bbp.Disconnect();
            }
        }

        public List<Pozajmica> PretraziPozajmice(string kriterijum)
        {
            bbp.Connect();
            try
            {
                return bbp.PretraziPozajmice(kriterijum);
            }
            finally
            {
                bbp.Disconnect();
            }
        }

        public List<StavkaPozajmice> GetStavkePozajmice(long idPozajmice)
        {
            bbp.Connect();
            try
            {
                return bbp.GetStavkePozajmice(idPozajmice);
            }
            finally
            {
                bbp.Disconnect();
            }
        }

    }
}
