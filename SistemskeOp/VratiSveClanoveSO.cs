using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    //vratiListuSviClan(Lista<Clan>)
    public class VratiSveClanoveSO : SOBase
    {
        public List<Clan> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(new Clan());
            Result = lista.Cast<Clan>().ToList();
        }
    }
}

