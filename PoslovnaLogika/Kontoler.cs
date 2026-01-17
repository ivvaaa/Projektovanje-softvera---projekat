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






    }
}
