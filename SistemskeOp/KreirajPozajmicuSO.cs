using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    public class KreirajPozajmicuSO : SOBase
    {
        private Pozajmica pozajmica;
        public long Result { get; private set; }

        public KreirajPozajmicuSO(Pozajmica p)
        {
            pozajmica = p;
        }

        protected override void ExecuteConcreteOperation()
        {
            foreach (var stavka in pozajmica.Stavke)
            {
                int brojSlobodnih = broker.GetBrojSlobodnihPrimeraka(stavka.IdKnjige);

                if (brojSlobodnih <= 0)
                {
                    throw new Exception("Knjiga sa ID " + stavka.IdKnjige + " nije dostupna - svi primerci su iznajmljeni.");
                }
            }

            long idPozajmice = broker.AddAndGetId(pozajmica);
            Result = idPozajmice;

            foreach (var stavka in pozajmica.Stavke)
            {
                stavka.IdPozajmica = idPozajmice;
                broker.Add(stavka);
            }
        }
    }
}
