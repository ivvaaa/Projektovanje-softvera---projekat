using Domeni;
using SistemskeOp;

namespace BibliotekAPI
{
    /// <summary>
    /// Web verzija Kontrolera — identična logika kao u desktop aplikaciji.
    /// Umesto TCP socket poziva, metode se direktno pozivaju iz HTTP controllera.
    /// Registrovan kao Singleton u DI kontejneru (kao što je bio static Instance u desktopu).
    /// </summary>
    public class Kontroler
    {
        // Lista ID-eva trenutno ulogovanih bibliotekara
        private readonly List<long> ulogovani = new();

        // ── AUTENTIFIKACIJA ──────────────────────────────────────────────

        /// <summary>SK9 — Prijava bibliotekara u sistem.</summary>
        public Bibliotekar PrijaviBibliotekara(Bibliotekar b)
        {
            LoginSO so = new LoginSO(b);
            so.ExecuteTemplate();

            if (ulogovani.Contains(so.Result.Id))
                throw new Exception("Korisnik je već prijavljen.");

            ulogovani.Add(so.Result.Id);
            return so.Result;
        }

        /// <summary>Odjava bibliotekara iz sistema.</summary>
        public void OdjaviSe(long id)
        {
            ulogovani.Remove(id);
        }

        // ── KNJIGE ───────────────────────────────────────────────────────

        /// <summary>SK14 — Ubaci novu knjigu u sistem.</summary>
        public void UbaciKnjigu(Knjiga k)
        {
            UbaciKnjiguSO so = new UbaciKnjiguSO(k);
            so.ExecuteTemplate();
        }

        /// <summary>SK10/SK15 — Pretraži knjige. Prazan kriterijum = sve knjige.</summary>
        public List<Knjiga> PretraziKnjige(string kriterijum)
        {
            PretraziKnjigeSO so = new PretraziKnjigeSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        /// <summary>SK16 — Izmeni podatke o knjizi.</summary>
        public void IzmeniKnjigu(Knjiga k)
        {
            IzmeniKnjiguSO so = new IzmeniKnjiguSO(k);
            so.ExecuteTemplate();
        }

        /// <summary>SK17 — Obriši knjigu iz sistema.</summary>
        public void ObrisiKnjigu(long id)
        {
            ObrisiKnjiguSO so = new ObrisiKnjiguSO(id);
            so.ExecuteTemplate();
        }

        // ── ČLANOVI ──────────────────────────────────────────────────────

        /// <summary>SK5 — Kreiraj novog člana biblioteke.</summary>
        public void KreirajClana(Clan c)
        {
            KreirajClanaSO so = new KreirajClanaSO(c);
            so.ExecuteTemplate();
        }

        /// <summary>SK6/SK7 — Pretraži članove. Prazan kriterijum = svi članovi.</summary>
        public List<Clan> PretraziClanove(string kriterijum)
        {
            PretraziClanoveSO so = new PretraziClanoveSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        /// <summary>SK7 — Izmeni podatke o članu.</summary>
        public void IzmeniClana(Clan c)
        {
            IzmeniClanaSO so = new IzmeniClanaSO(c);
            so.ExecuteTemplate();
        }

        /// <summary>SK8 — Obriši člana iz sistema.</summary>
        public void ObrisiClana(long id)
        {
            ObrisiClanaSO so = new ObrisiClanaSO(id);
            so.ExecuteTemplate();
        }

        /// <summary>Pomoćna — vraća sva dostupna članstva (preduslov za SK7).</summary>
        public List<Clanstvo> VratiSvaClanstva()
        {
            PretraziClanoveSO so = new PretraziClanoveSO(true);
            so.ExecuteTemplate();
            return so.ResultClanstva;
        }

        // ── POZAJMICE ────────────────────────────────────────────────────

        /// <summary>SK1 — Kreiraj novu pozajmicu sa stavkama.</summary>
        public long KreirajPozajmicu(Pozajmica p)
        {
            KreirajPozajmicuSO so = new KreirajPozajmicuSO(p);
            so.ExecuteTemplate();
            return so.Result;
        }

        /// <summary>SK2 — Pretraži pozajmice. Prazan kriterijum = sve pozajmice.</summary>
        public List<Pozajmica> PretraziPozajmice(string kriterijum)
        {
            PretraziPozajmiceSO so = new PretraziPozajmiceSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        /// <summary>SK3a — Vrati konkretnu knjigu (postavi datum vraćanja).</summary>
        public void VratiKnjigu(long idPozajmica, long idKnjiga)
        {
            VratiKnjiguSO so = new VratiKnjiguSO(idPozajmica, idKnjiga);
            so.ExecuteTemplate();
        }

        /// <summary>SK3b — Izmeni rok pozajmice za sve aktivne stavke.</summary>
        public void IzmeniRokPozajmice(long idPozajmica, DateTime noviRok)
        {
            VratiKnjiguSO so = new VratiKnjiguSO(idPozajmica, noviRok);
            so.ExecuteTemplate();
        }

        // ── SMENE ────────────────────────────────────────────────────────

        /// <summary>Pretraži smene. Prazan kriterijum = sve smene.</summary>
        public List<BibSmena> PretraziSmene(string kriterijum)
        {
            PretraziSmeneSO so = new PretraziSmeneSO(kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        /// <summary>Dodaj novu smenu bibliotekaru.</summary>
        public void DodajSmenu(BibSmena smena)
        {
            DodajSmenaSO so = new DodajSmenaSO(smena);
            so.ExecuteTemplate();
        }

        /// <summary>Izmeni postojeću smenu.</summary>
        public void IzmeniSmenu(BibSmena stara, BibSmena nova)
        {
            IzmeniSmenaSO so = new IzmeniSmenaSO(stara, nova);
            so.ExecuteTemplate();
        }

        /// <summary>Učitaj sve dostupne termine smena.</summary>
        public List<TerminSmene> VratiSveTermine()
        {
            VratiTermineSO so = new VratiTermineSO();
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}
