using Domeni;

namespace SistemskeOp
{
    //vratiListuPozajmica(kriterijumClan, Lista<Pozajmica>)
    //prazan kriterijum = vrati sve (pocetno punjenje forme)
    public class PretraziPozajmiceSO : SOBase
    {
        private string kriterijum;
        public List<Pozajmica> Result { get; private set; }

        public PretraziPozajmiceSO(string kriterijum)
        {
            this.kriterijum = kriterijum;
        }

        protected override void ExecuteConcreteOperation()
        {
            // Ucitaj sve clanove i bibliotekare (potrebni za enrichment i pretragu)
            List<Clan> sviClanovi = broker.GetAll(new Clan()).Cast<Clan>().ToList();
            List<Bibliotekar> sviBibliotekar = broker.GetAll(new Bibliotekar()).Cast<Bibliotekar>().ToList();

            // Ucitaj sve pozajmice (ili filtriraj po ID ako je kriterijum broj)
            List<Pozajmica> svePozajmice;
            if (string.IsNullOrWhiteSpace(kriterijum))
            {
                svePozajmice = broker.GetAll(new Pozajmica()).Cast<Pozajmica>().ToList();
            }
            else
            {
                svePozajmice = broker.GetAll(new Pozajmica()).Cast<Pozajmica>().ToList();
            }

            // Enrich svake pozajmice sa stavkama, imenom clana i bibliotekara
            foreach (var pozajmica in svePozajmice)
            {
                List<StavkaPozajmice> stavke = broker.GetByCondition(new StavkaPozajmice(), $"StavkaPozajmice.idPozajmica = {pozajmica.Id}")
                                                                      .Cast<StavkaPozajmice>().ToList();
                pozajmica.Stavke = stavke;

                Clan clan = sviClanovi.FirstOrDefault(c => c.Id == pozajmica.IdClan);
                pozajmica.ImePrezimeClana = clan != null ? $"{clan.Ime} {clan.Prezime}" : "";

                Bibliotekar bib = sviBibliotekar.FirstOrDefault(b => b.Id == pozajmica.IdBibliotekar);
                pozajmica.ImePrezimeBibliotekar = bib != null ? $"{bib.Ime} {bib.Prezime}" : "";

                pozajmica.BrojKnjiga = stavke.Count;

                bool imaAktivnih = stavke.Any(s => s.DatumVracanja == null);
                bool imaZakasnelih = stavke.Any(s => s.DatumVracanja == null && s.RokPozajmice < DateTime.Today);

                pozajmica.Status = !imaAktivnih ? "Vraceno"
                                 : imaZakasnelih ? "Zakasnelo"
                                 : "Aktivna";
            }

            // Filtriranje po svim kriterijumima (Pozajmica ID, Clan, Bibliotekar, Knjiga)
            if (!string.IsNullOrWhiteSpace(kriterijum))
            {
                string k = kriterijum.ToLower().Trim();
                svePozajmice = svePozajmice.Where(p =>
                    // a) po ID pozajmice
                    p.Id.ToString().Contains(k) ||
                    // b) po clanu (ime ili prezime)
                    p.ImePrezimeClana.ToLower().Contains(k) ||
                    // c) po bibliotekaru (ime ili prezime)
                    p.ImePrezimeBibliotekar.ToLower().Contains(k) ||
                    // d) po nazivu knjige u stavkama
                    p.Stavke.Any(s => s.NazivKnjige.ToLower().Contains(k))
                ).ToList();
            }

            Result = svePozajmice;
        }
    }
}