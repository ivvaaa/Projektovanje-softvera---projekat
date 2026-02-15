using Domeni;
using SistemskeOp;

namespace Server
{
    internal class Kontroler
    {
        private static Kontroler instance;
        public static Kontroler Instance
        {
            get
            {
                if (instance == null) instance = new Kontroler();
                return instance;
            }
        }

        private Kontroler() { }

        public Bibliotekar PrijaviBibliotekara(Bibliotekar b)
        {
            LoginSO so = new LoginSO(b);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Knjiga> VratiSveKnjige()
        {
            VratiSveKnjigeSO so = new VratiSveKnjigeSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Knjiga> PretraziKnjige(string kriterijum)
        {
            PretraziKnjigeSO so = new PretraziKnjigeSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        public void SacuvajKnjigu(Knjiga k)
        {
            SacuvajKnjiguSO so = new SacuvajKnjiguSO(k);
            so.ExecuteTemplate();
        }

        public void IzmeniKnjigu(Knjiga k)
        {
            IzmeniKnjiguSO so = new IzmeniKnjiguSO(k);
            so.ExecuteTemplate();
        }

        public void ObrisiKnjigu(long id)
        {
            ObrisiKnjiguSO so = new ObrisiKnjiguSO(id);
            so.ExecuteTemplate();
        }

        public List<Clan> PretraziClanove(string kriterijum)
        {
            PretraziClanoveSO so = new PretraziClanoveSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        public void SacuvajClana(Clan c)
        {
            SacuvajClanaSO so = new SacuvajClanaSO(c);
            so.ExecuteTemplate();
        }

        public void IzmeniClana(Clan c)
        {
            IzmeniClanaSO so = new IzmeniClanaSO(c);
            so.ExecuteTemplate();
        }

        public void ObrisiClana(long id)
        {
            ObrisiClanaSO so = new ObrisiClanaSO(id);
            so.ExecuteTemplate();
        }

        public long KreirajPozajmicu(Pozajmica p)
        {
            KreirajPozajmicuSO so = new KreirajPozajmicuSO(p);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Pozajmica> PretraziPozajmice(string kriterijum)
        {
            PretraziPozajmiceSO so = new PretraziPozajmiceSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}