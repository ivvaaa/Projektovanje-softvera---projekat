using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domeni;

namespace SistemskeOp
{
    /// <summary>
    /// Sistemska operacija za dodavanje nove smene bibliotekaru.
    /// Proverava da li bibliotekar već ima smenu na isti datum pre dodavanja.
    /// </summary>
    public class DodajSmenaSO : SOBase
    {
        private BibSmena smena;

        /// <summary>
        /// Inicijalizuje operaciju sa smenom koju treba dodati.
        /// </summary>
        /// <param name="smena">Smena koja se dodaje.</param>
        public DodajSmenaSO(BibSmena smena)
        {
            this.smena = smena;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            // Provera: da li bibliotekar već ima smenu na taj datum
            string condition = $"[Bib-Smena].idBibliotekar = {smena.IdBibliotekara} AND datum = '{smena.Datum:yyyy-MM-dd}'";
            List<BibSmena> postojece = broker.GetByCondition(new BibSmena(), condition).Cast<BibSmena>().ToList();

            if (postojece.Count > 0)
                throw new Exception($"Bibliotekar već ima smenu zakazanu za {smena.Datum:dd.MM.yyyy}.");

            broker.Add(smena);
        }
    }
}