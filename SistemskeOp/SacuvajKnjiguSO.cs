using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    public class SacuvajKnjiguSO : SOBase
    {
        private Knjiga knjiga;

        public SacuvajKnjiguSO(Knjiga k)
        {
            knjiga = k;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add(knjiga);
        }
    }

}
