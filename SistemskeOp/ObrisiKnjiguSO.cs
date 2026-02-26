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
            if (id <= 0)
                throw new ArgumentException("ID knjige mora biti pozitivan broj.");

            List<IEntity> listaKnjiga = broker.GetByCondition(new Knjiga(), $"idKnjiga = {id}"); //da li knjiga postoji
            if (listaKnjiga.Count == 0)
                throw new InvalidOperationException($"Knjiga sa ID={id} ne postoji.");
            //da li je knjiga pozajmljena
            List<IEntity> listaStavki = broker.GetByCondition(new StavkaPozajmice(), $"idKnjiga = {id} AND datumVracanja IS NULL");
            if (listaStavki.Count > 0)
                throw new InvalidOperationException(
                    $"Knjiga ne može biti obrisana jer ima {listaStavki.Count} pozajmljenih primeraka.");

            broker.Delete(new Knjiga(), $"idKnjiga = {id}");
        }
    }
}
