using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    public class ObrisiClanaSO : SOBase
    {
        private long id;

        public ObrisiClanaSO(long id)
        {
            this.id = id;
        }

        protected override void ExecuteConcreteOperation()
        {
            string condition = "idClan = " + id;
            broker.Delete(new Clan(), condition);
        }
    }
}
