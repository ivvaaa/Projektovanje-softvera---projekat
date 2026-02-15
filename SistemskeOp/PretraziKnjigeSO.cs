using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    public class PretraziKnjigeSO : SOBase
    {
        private string kriterijum;
        public List<Knjiga> Result { get; private set; }

        public PretraziKnjigeSO(string kriterijum)
        {
            this.kriterijum = kriterijum;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetKnjigeSaSlobodnim(kriterijum);
        }
    }

}
