using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    public class VratiSvePozajmiceSO : SOBase
    {
        public List<Pozajmica> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetPozajmiceSaStatusom();
        }
    }
}
