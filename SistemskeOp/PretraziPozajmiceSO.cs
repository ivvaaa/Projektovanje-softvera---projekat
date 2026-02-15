using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    public class PretraziPozajmiceSO : SOBase
    {
        private string kriterijum;
        public List<Pozajmica> Result { get; private set; }

        public PretraziPozajmiceSO(string kriterijum)
        {
            this.kriterijum = kriterijum;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetPozajmiceSaStatusom(kriterijum);
        }
    }
}
