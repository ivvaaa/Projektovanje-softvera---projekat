using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    /// <summary>
    /// Sistemska operacija za učitavanje svih dostupnih termina smena.
    /// </summary>
    public class VratiTermineSO : SOBase
    {
        /// <summary>Rezultat — lista svih termina smena.</summary>
        public List<TerminSmene> Result { get; private set; }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new TerminSmene()).Cast<TerminSmene>().ToList();
        }
    }
}