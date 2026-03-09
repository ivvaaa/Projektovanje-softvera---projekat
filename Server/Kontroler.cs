using BrokerBP;
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
                if (instance == null) instance = new Kontroler();
                return instance;
            }
        }

        private Kontroler() { }

        private static List<long> ulogovani = new List<long>();


        //SK9
        public Bibliotekar PrijaviBibliotekara(Bibliotekar b)
        {
            LoginSO so = new LoginSO(b);
            so.ExecuteTemplate();

            if (ulogovani.Contains(so.Result.Id))
                throw new Exception("Korisnik je već prijavljen.");

            ulogovani.Add(so.Result.Id);
            return so.Result;
        }
        public void OdjaviSe(long id)
        {
            ulogovani.Remove(id);
        }

        //SK14
        public void UbaciKnjigu(Knjiga k)
        {
            UbaciKnjiguSO so = new UbaciKnjiguSO(k);
            so.ExecuteTemplate();
        }

        // vratiListuKnjiga(kriterijum) - SK10/SK15, prazan kriterijum = sve knjige
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

        // vratiListuClan(kriterijum) - SK6/SK7, prazan kriterijum = svi clanovi
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

        // pomocna - ucitavanje liste clanstava (SK7 preduslov)
        public List<Clanstvo> VratiSvaClanstva()
        {
            PretraziClanoveSO so = new PretraziClanoveSO(true);
            so.ExecuteTemplate();
            return so.ResultClanstva;
        }

        //SK1
        public long KreirajPozajmicu(Pozajmica p)
        {
            KreirajPozajmicuSO so = new KreirajPozajmicuSO(p);
            so.ExecuteTemplate();
            return so.Result;
        }

        // vratiListuPozajmica(kriterijum) - SK2, prazan kriterijum = sve pozajmice
        public List<Pozajmica> PretraziPozajmice(string kriterijum)
        {
            PretraziPozajmiceSO so = new PretraziPozajmiceSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        // SK3a - PromeniPozajmica: vracanje knjige
        public void VratiKnjigu(long idPozajmica, long idKnjiga)
        {
            VratiKnjiguSO so = new VratiKnjiguSO(idPozajmica, idKnjiga);
            so.ExecuteTemplate();
        }

        // SK3b - PromeniPozajmica: izmena roka pozajmice za aktivne stavke
        public void IzmeniRokPozajmice(long idPozajmica, DateTime noviRok)
        {
            VratiKnjiguSO so = new VratiKnjiguSO(idPozajmica, noviRok);
            so.ExecuteTemplate();
        }

        /// <summary>
        /// Vraća listu smena, filtrirano po kriterijumu ili sve ako je kriterijum prazan.
        /// </summary>
        /// <param name="kriterijum">Ime/prezime bibliotekara za pretragu.</param>
        public List<BibSmena> PretraziSmene(string kriterijum)
        {
            PretraziSmeneSO so = new PretraziSmeneSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        /// <summary>
        /// Dodaje novu smenu bibliotekaru uz proveru duplikata.
        /// </summary>
        /// <param name="smena">Smena koja se dodaje.</param>
        public void DodajSmenu(BibSmena smena)
        {
            DodajSmenaSO so = new DodajSmenaSO(smena);
            so.ExecuteTemplate();
        }

        /// <summary>
        /// Menja termin i/ili datum postojeće smene.
        /// </summary>
        /// <param name="stara">Originalna smena (identifikator).</param>
        /// <param name="nova">Nova smena sa ažuriranim vrednostima.</param>
        public void IzmeniSmenu(BibSmena stara, BibSmena nova)
        {
            IzmeniSmenaSO so = new IzmeniSmenaSO(stara, nova);
            so.ExecuteTemplate();
        }

        /// <summary>
        /// Učitava sve dostupne termine smena iz baze.
        /// </summary>
        /// <summary>Učitava sve dostupne termine smena iz baze.</summary>
        public List<TerminSmene> VratiSveTermine()
        {
            VratiTermineSO so = new VratiTermineSO();
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}