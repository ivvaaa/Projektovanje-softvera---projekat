using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    //vratiListuSviKnjiga(Lista<Knjiga>)
    public class VratiSveKnjigeSO : SOBase
    {
        public List<Knjiga> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            //ucitaj sve knjige
            List<IEntity> listaKnjiga = broker.GetAll(new Knjiga());
            List<Knjiga> knjige = listaKnjiga.Cast<Knjiga>().ToList();

            //ucitaj sve aktivne stavke pozajmice (datumVracanja IS NULL)
            List<IEntity> listaStavki = broker.GetByCondition(new StavkaPozajmice(), "datumVracanja IS NULL");
            List<StavkaPozajmice> aktivneStavke = listaStavki.Cast<StavkaPozajmice>().ToList();

            //iyracunaj br Slobodnih
            foreach (var knjiga in knjige)
            {
                int pozajmljeno = aktivneStavke.Count(s => s.IdKnjige == knjiga.Id);
                knjiga.BrojSlobodnih = knjiga.BrojPrimeraka - pozajmljeno;
            }

            Result = knjige;
        }
    }
}


