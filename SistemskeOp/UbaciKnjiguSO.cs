using System;
using System.Collections.Generic;
using System.Linq;
using Domeni;

namespace SistemskeOp
{
    /// <summary>
    /// Sistemska operacija za dodavanje nove knjige u biblioteku (SK14).
    /// Upisuje prosleđenu knjigu u tabelu <c>Knjiga</c> u bazi podataka.
    /// </summary>
    public class UbaciKnjiguSO : SOBase
    {
        private Knjiga knjiga;

        /// <summary>
        /// Inicijalizuje operaciju sa knjigom koja se dodaje.
        /// </summary>
        /// <param name="k">
        /// Knjiga koja se upisuje u bazu. Mora imati popunjena polja
        /// <c>Naziv</c>, <c>ImePisca</c>, <c>PrezimePisca</c> i <c>BrojPrimeraka</c>.
        /// </param>
        public UbaciKnjiguSO(Knjiga k)
        {
            knjiga = k;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(knjiga);
        }
    }
}
