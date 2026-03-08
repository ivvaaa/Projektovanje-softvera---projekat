using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    /// <summary>
    /// Sistemska operacija za pretragu i učitavanje smena bibliotekara.
    /// Prazan kriterijum vraća sve smene, inače filtrira po imenu/prezimenu bibliotekara.
    /// </summary>
    public class PretraziSmeneSO : SOBase
    {
        private string kriterijum;

        /// <summary>Rezultat operacije — lista pronađenih smena.</summary>
        public List<BibSmena> Result { get; private set; }

        /// <summary>
        /// Inicijalizuje operaciju sa zadatim kriterijumom pretrage.
        /// </summary>
        /// <param name="kriterijum">Tekst za pretragu po imenu/prezimenu bibliotekara. Prazan string vraća sve.</param>
        public PretraziSmeneSO(string kriterijum)
        {
            this.kriterijum = kriterijum;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            List<BibSmena> smene;

            if (string.IsNullOrWhiteSpace(kriterijum))
            {
                smene = broker.GetAll(new BibSmena()).Cast<BibSmena>().ToList();
            }
            else
            {
                // BibSmena JOIN već uključuje Bibliotekar tabelu
                string condition = $"b.ime LIKE '%{kriterijum}%' OR b.prezime LIKE '%{kriterijum}%'";
                smene = broker.GetByCondition(new BibSmena(), condition).Cast<BibSmena>().ToList();
            }

            // Učitaj sve bibliotekare i termine da popunimo NazivTermina i ImeBibliotekara
            List<Bibliotekar> svi = broker.GetAll(new Bibliotekar()).Cast<Bibliotekar>().ToList();
            List<TerminSmene> termini = broker.GetAll(new TerminSmene()).Cast<TerminSmene>().ToList();

            foreach (var smena in smene)
            {
                var bib = svi.FirstOrDefault(b => b.Id == smena.IdBibliotekara);
                smena.ImeBibliotekara = bib != null ? $"{bib.Ime} {bib.Prezime}" : "";

                var termin = termini.FirstOrDefault(t => t.Id == smena.IdTerminSmene);
                smena.NazivTermina = termin != null ? termin.Termin : "";
            }

            Result = smene;
        }
    }
}