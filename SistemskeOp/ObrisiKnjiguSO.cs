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

            if (!broker.KnjigaPostoji(id))
            {
                throw new InvalidOperationException($"Knjiga sa ID={id} ne postoji.");
            }

            int brojPozajmljenih = broker.GetBrojPozajmljenihPrimeraka(id);

            if (brojPozajmljenih > 0)
            {
                throw new InvalidOperationException(
                    $"Knjiga ne može biti obrisana jer ima {brojPozajmljenih} pozajmljenih primeraka.");
            }

            string condition = $"idKnjiga = {id}";
            broker.Delete(new Knjiga(), condition);
        }
    }
}