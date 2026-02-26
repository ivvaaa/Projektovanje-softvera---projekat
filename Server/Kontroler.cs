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

        //SK9
        public Bibliotekar PrijaviBibliotekara(Bibliotekar b)
        {
            LoginSO so = new LoginSO(b);
            so.ExecuteTemplate();
            return so.Result;
        }

        //SK14
        public void UbaciKnjigu(Knjiga k)
        {
            UbaciKnjiguSO so = new UbaciKnjiguSO(k);
            so.ExecuteTemplate();
        }

        public List<Knjiga> VratiSveKnjige()
        {
            VratiSveKnjigeSO so = new VratiSveKnjigeSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        //vratiListuKnjiga(kriterijumKnjiga) - SK15
        public List<Knjiga> PretraziKnjige(string kriterijum)
        {
            PretraziKnjigeSO so = new PretraziKnjigeSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        //SK16 - PromeniKnjiga
        public void IzmeniKnjigu(Knjiga k)
        {
            IzmeniKnjiguSO so = new IzmeniKnjiguSO(k);
            so.ExecuteTemplate();
        }

        //SK17 - ObrisiKnjiga
        public void ObrisiKnjigu(long id)
        {
            ObrisiKnjiguSO so = new ObrisiKnjiguSO(id);
            so.ExecuteTemplate();
        }

        // SK5 - KreirajClan
        public void KreirajClana(Clan c)
        {
            KreirajClanaSO so = new KreirajClanaSO(c);
            so.ExecuteTemplate();
        }

        public List<Clan> VratiSveClanova()
        {
            VratiSveClanoveSO so = new VratiSveClanoveSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        //vratiListuClan(kriterijumClan) - SK6
        public List<Clan> PretraziClanove(string kriterijum)
        {
            PretraziClanoveSO so = new PretraziClanoveSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        //SK7 - PromeniClan
        public void IzmeniClana(Clan c)
        {
            IzmeniClanaSO so = new IzmeniClanaSO(c);
            so.ExecuteTemplate();
        }

        //SK8
        public void ObrisiClana(long id)
        {
            ObrisiClanaSO so = new ObrisiClanaSO(id);
            so.ExecuteTemplate();
        }

        //SK1
        public long KreirajPozajmicu(Pozajmica p)
        {
            KreirajPozajmicuSO so = new KreirajPozajmicuSO(p);
            so.ExecuteTemplate();
            return so.Result;
        }

        //vratiListuPozajmica(kriterijumClan), prazan kriterijum = sve, SK2
        public List<Pozajmica> PretraziPozajmice(string kriterijum)
        {
            PretraziPozajmiceSO so = new PretraziPozajmiceSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        //PromeniPozajmica - vraćanje knjige (menja StavkaPozajmice)
        public void VratiKnjigu(long idPozajmica, long idKnjiga)
        {
            VratiKnjiguSO so = new VratiKnjiguSO(idPozajmica, idKnjiga);
            so.ExecuteTemplate();
        }

        //vratiListuSviBibliotekar - pomocna za forme
        public List<Bibliotekar> VratiSveBibliotekare()
        {
            VratiSveBibliotekareSO so = new VratiSveBibliotekareSO();
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}
