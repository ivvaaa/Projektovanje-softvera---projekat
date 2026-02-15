using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOp
{
    public class ProveriDostupnostKnjigeSO : SOBase
    {
        private long idKnjige;
        public bool Result { get; private set; }
        public int BrojSlobodnih { get; private set; }

        public ProveriDostupnostKnjigeSO(long idKnjige)
        {
            this.idKnjige = idKnjige;
        }

        protected override void ExecuteConcreteOperation()
        {
            BrojSlobodnih = broker.GetBrojSlobodnihPrimeraka(idKnjige);
            Result = BrojSlobodnih > 0;
        }
    }
}