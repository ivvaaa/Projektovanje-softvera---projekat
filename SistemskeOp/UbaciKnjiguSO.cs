using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    //ubaciKnjiga(Knjiga)
    public class UbaciKnjiguSO : SOBase
    {
        private Knjiga knjiga;

        public UbaciKnjiguSO(Knjiga k)
        {
            knjiga = k;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add(knjiga);
        }
    }
}

