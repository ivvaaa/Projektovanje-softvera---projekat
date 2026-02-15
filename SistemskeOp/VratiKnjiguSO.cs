using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{

    public class VratiKnjiguSO : SOBase
    {
        private long idPozajmica;
        private long idKnjiga;
        public bool Result { get; private set; }

        public VratiKnjiguSO(long idPozajmica, long idKnjiga)
        {
            this.idPozajmica = idPozajmica;
            this.idKnjiga = idKnjiga;
        }

        protected override void ExecuteConcreteOperation()
        {
            string setClause = $"datumVracanja = '{DateTime.Now:yyyy-MM-dd}'";

            string condition = $"idPozajmica = {idPozajmica} AND idKnjiga = {idKnjiga} AND datumVracanja IS NULL";

            broker.Update(new StavkaPozajmice(), setClause, condition);
            Result = true;
        }
    }
}
