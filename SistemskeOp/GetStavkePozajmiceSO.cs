using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    public class GetStavkePozajmiceSO : SOBase
    {
        private long idPozajmice;
        public List<StavkaPozajmice> Result { get; private set; }

        public GetStavkePozajmiceSO(long idPozajmice)
        {
            this.idPozajmice = idPozajmice;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetStavkePozajmice(idPozajmice);
        }
    }
}
