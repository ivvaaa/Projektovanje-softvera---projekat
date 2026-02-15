using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    public class ObrisiKnjiguSO : SOBase
    {
        private long id;

        public ObrisiKnjiguSO(long id)
        {
            this.id = id;
        }

        protected override void ExecuteConcreteOperation()
        {
            string condition = "idKnjiga = " + id;
            broker.Delete(new Knjiga(), condition);
        }
    }
}
