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
            List<IEntity> pozajmice = broker.GetByCondition(
                new Pozajmica(), $"idClan = {id}");

            if (pozajmice.Count > 0)
                throw new Exception(
                    $"Član ne može biti obrisan jer ima {pozajmice.Count} pozajmica u sistemu.");

            broker.Delete(new Clan(), $"idClan = {id}");
        }
    }
}
