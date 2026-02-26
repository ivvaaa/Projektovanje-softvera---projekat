using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    //vratiListuSviBibliotekar(Lista<Bibliotekar>)
    public class VratiSveBibliotekareSO : SOBase
    {
        public List<Bibliotekar> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(new Bibliotekar());
            Result = lista.Cast<Bibliotekar>().ToList();
        }
    }
}