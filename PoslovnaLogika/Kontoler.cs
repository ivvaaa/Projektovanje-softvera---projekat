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

    }
}
