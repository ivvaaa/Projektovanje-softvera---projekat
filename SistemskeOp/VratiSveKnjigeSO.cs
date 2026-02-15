using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    public class VratiSveKnjigeSO : SOBase
    {
        public List<Knjiga> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetKnjigeSaSlobodnim();
        }
    }
}

