using System;
using System.Collections.Generic;
using System.Linq;
using Domeni;

namespace SistemskeOp
{
    /// <summary>
    /// Sistemska operacija za pretragu i prikaz pozajmica (SK2).
    /// Za svaku pozajmicu učitava stavke (knjige), puno ime člana i bibliotekara,
    /// broj knjiga i izračunava status: <c>"Aktivna"</c>, <c>"Zakasnelo"</c> ili <c>"Vraceno"</c>.
    /// Prazan kriterijum vraća sve pozajmice.
    /// </summary>
    public class PretraziPozajmiceSO : SOBase
    {
        private string kriterijum;

        /// <summary>
        /// Lista pronađenih pozajmica sa svim popunjenim detaljima (stavke, ime člana, status).
        /// Popunjava se nakon izvršavanja operacije.
        /// </summary>
        public List<Pozajmica> Result { get; private set; }

        /// <summary>
        /// Inicijalizuje operaciju sa kriterijumom pretrage.
        /// </summary>
        /// <param name="kriterijum">
        /// Tekst za pretragu po ID-u pozajmice, imenu člana, imenu bibliotekara
        /// ili naslovu pozajmljene knjige. Prazan string vraća sve pozajmice.
        /// </param>
        public PretraziPozajmiceSO(string kriterijum)
        {
            this.kriterijum = kriterijum;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            // Učitaj sve potrebne entitete za punjenje detalja
            List<Clan> sviClanovi = broker.GetAll(new Clan()).Cast<Clan>().ToList();
            List<Bibliotekar> sviBibliotekar = broker.GetAll(new Bibliotekar()).Cast<Bibliotekar>().ToList();
            List<Pozajmica> svePozajmice = broker.GetAll(new Pozajmica()).Cast<Pozajmica>().ToList();

            foreach (var pozajmica in svePozajmice)
            {
                // Učitaj stavke za ovu pozajmicu
                List<StavkaPozajmice> stavke = broker
                    .GetByCondition(new StavkaPozajmice(), $"StavkaPozajmice.idPozajmica = {pozajmica.Id}")
                    .Cast<StavkaPozajmice>().ToList();
                pozajmica.Stavke = stavke;

                // Popuni ime člana
                Clan clan = sviClanovi.FirstOrDefault(c => c.Id == pozajmica.IdClan);
                pozajmica.ImePrezimeClana = clan != null ? $"{clan.Ime} {clan.Prezime}" : "";

                // Popuni ime bibliotekara
                Bibliotekar bib = sviBibliotekar.FirstOrDefault(b => b.Id == pozajmica.IdBibliotekar);
                pozajmica.ImePrezimeBibliotekar = bib != null ? $"{bib.Ime} {bib.Prezime}" : "";

                pozajmica.BrojKnjiga = stavke.Count;

                // Izračunaj status pozajmice
                bool imaAktivnih = stavke.Any(s => s.DatumVracanja == null);
                bool imaZakasnelih = stavke.Any(s => s.DatumVracanja == null && s.RokPozajmice < DateTime.Today);

                pozajmica.Status = !imaAktivnih ? "Vraceno"
                                 : imaZakasnelih ? "Zakasnelo"
                                 : "Aktivna";
            }

            // Primeni filter po kriterijumu
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
