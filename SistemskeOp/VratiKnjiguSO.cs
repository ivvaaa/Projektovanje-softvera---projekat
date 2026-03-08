using System;
using System.Collections.Generic;
using System.Linq;
using Domeni;

namespace SistemskeOp
{
    /// <summary>
    /// Sistemska operacija za izmenu pozajmice (SK3). Podržava dva međusobno isključiva scenarija:
    /// <list type="bullet">
    ///   <item>
    ///     <b>SK3a — Vraćanje knjige:</b> postavlja <c>datumVracanja</c> na današnji datum
    ///     za stavku sa konkretnom knjigom u okviru date pozajmice.
    ///   </item>
    ///   <item>
    ///     <b>SK3b — Izmena roka:</b> menja <c>rokPozajmice</c> za sve nevraćene stavke
    ///     u okviru date pozajmice.
    ///   </item>
    /// </list>
    /// Koji scenarij se koristi određuje se izborom konstruktora.
    /// </summary>
    public class VratiKnjiguSO : SOBase
    {
        private long idPozajmica;
        private long? idKnjiga;     // null u SK3b scenariju
        private DateTime? noviRok;  // null u SK3a scenariju

        /// <summary>
        /// Inicijalizuje operaciju za vraćanje konkretne knjige (SK3a).
        /// Postavlja <c>datumVracanja = danas</c> za odgovarajuću aktivnu stavku.
        /// </summary>
        /// <param name="idPozajmica">Identifikator pozajmice u kojoj se knjiga vraća.</param>
        /// <param name="idKnjiga">Identifikator knjige koja se vraća.</param>
        public VratiKnjiguSO(long idPozajmica, long idKnjiga)
        {
            this.idPozajmica = idPozajmica;
            this.idKnjiga = idKnjiga;
            this.noviRok = null;
        }

        /// <summary>
        /// Inicijalizuje operaciju za izmenu roka pozajmice (SK3b).
        /// Menja <c>rokPozajmice</c> za sve nevraćene stavke date pozajmice.
        /// </summary>
        /// <param name="idPozajmica">Identifikator pozajmice čiji se rok menja.</param>
        /// <param name="noviRok">Novi datum roka vraćanja knjiga.</param>
        public VratiKnjiguSO(long idPozajmica, DateTime noviRok)
        {
            this.idPozajmica = idPozajmica;
            this.idKnjiga = null;
            this.noviRok = noviRok;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            if (noviRok.HasValue)
            {
                // SK3b: izmena roka za sve aktivne (nevraćene) stavke
                string setClause = $"rokPozajmice = '{noviRok.Value:yyyy-MM-dd}'";
                string condition = $"idPozajmica = {idPozajmica} AND datumVracanja IS NULL";
                broker.Update(new StavkaPozajmice(), setClause, condition);
            }
            else
            {
                // SK3a: vraćanje konkretne knjige — postavi datum vraćanja
                string setClause = $"datumVracanja = '{DateTime.Now:yyyy-MM-dd}'";
                string condition = $"idPozajmica = {idPozajmica} AND idKnjiga = {idKnjiga} AND datumVracanja IS NULL";
                broker.Update(new StavkaPozajmice(), setClause, condition);
            }
        }
    }
}
