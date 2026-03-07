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
            //sve clanove i bibliotekare
            List<Clan> sviClanovi = broker.GetAll(new Clan()).Cast<Clan>().ToList();
            List<Bibliotekar> sviBibliotekar = broker.GetAll(new Bibliotekar()).Cast<Bibliotekar>().ToList();

            List<Pozajmica> svePozajmice = broker.GetAll(new Pozajmica()).Cast<Pozajmica>().ToList();
            

            //pozajmice sa stavkama, imenom clana i bibliotekara
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

            // po svim kriterijumima
            if (!string.IsNullOrWhiteSpace(kriterijum))
            {
                string k = kriterijum.ToLower().Trim();
                svePozajmice = svePozajmice.Where(p =>
                    p.Id.ToString().Contains(k) ||
                    p.ImePrezimeClana.ToLower().Contains(k) ||
                    p.ImePrezimeBibliotekar.ToLower().Contains(k) ||
                    p.Stavke.Any(s => s.NazivKnjige.ToLower().Contains(k))
                ).ToList();
            }

            Result = svePozajmice;
        }
    }
}