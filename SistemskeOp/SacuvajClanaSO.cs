using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    public class SacuvajClanaSO : SOBase
    {
        private Clan clan;

        public SacuvajClanaSO(Clan c)
        {
            clan = c;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add(clan);
        }
    }
}
