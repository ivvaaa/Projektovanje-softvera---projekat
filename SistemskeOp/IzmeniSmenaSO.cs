using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    /// <summary>
    /// Sistemska operacija za izmenu postojeće smene bibliotekara.
    /// Menja termin smene i/ili datum za zadatu smenu identifikovanu po bibliotekaru i starom terminu.
    /// </summary>
    public class IzmeniSmenaSO : SOBase
    {
        private BibSmena stara;
        private BibSmena nova;

        /// <summary>
        /// Inicijalizuje operaciju sa starim i novim podacima smene.
        /// </summary>
        /// <param name="stara">Originalna smena koja se menja (identifikator).</param>
        /// <param name="nova">Nova smena sa ažuriranim podacima.</param>
        public IzmeniSmenaSO(BibSmena stara, BibSmena nova)
        {
            this.stara = stara;
            this.nova = nova;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            // Provera: novi datum ne sme biti u prošlosti
            if (nova.Datum.Date < DateTime.Today)
                throw new Exception("Datum smene ne može biti u prošlosti.");

            // Provera: ako se menja datum, ne sme da postoji druga smena istog bibliotekara na novi datum
            if (nova.Datum.Date != stara.Datum.Date)
            {
                string condition = $"[Bib-Smena].idBibliotekar = {nova.IdBibliotekara} AND datum = '{nova.Datum:yyyy-MM-dd}'";
                List<BibSmena> konflikt = broker.GetByCondition(new BibSmena(), condition).Cast<BibSmena>().ToList();

                if (konflikt.Count > 0)
                    throw new Exception($"Bibliotekar već ima smenu zakazanu za {nova.Datum:dd.MM.yyyy}.");
            }

            string setClause = $"idTerminSmene = {nova.IdTerminSmene}, datum = '{nova.Datum:yyyy-MM-dd}'";
            string whereClause = $"idBibliotekar = {stara.IdBibliotekara} AND idTerminSmene = {stara.IdTerminSmene} AND datum = '{stara.Datum:yyyy-MM-dd}'";

            broker.Update(new BibSmena(), setClause, whereClause);
        }
    }
}
