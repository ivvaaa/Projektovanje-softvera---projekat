using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    //vratiListuKnjiga(kriterijumKnjiga, Lista<Knjiga>) - SK10/SK15
    //prazan kriterijum = vrati sve knjige
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
            List<Knjiga> knjige;

            if (string.IsNullOrWhiteSpace(kriterijum))
            {
                knjige = broker.GetAll(new Knjiga()).Cast<Knjiga>().ToList();
            }
            else
            {
                string condition = $"naziv LIKE '%{kriterijum}%' OR imePisca LIKE '%{kriterijum}%' OR prezimePisca LIKE '%{kriterijum}%'";
                knjige = broker.GetByCondition(new Knjiga(), condition).Cast<Knjiga>().ToList();
            }

            //BrojSlobodnih za sve knjige
            List<StavkaPozajmice> aktivneStavke = broker
                .GetByCondition(new StavkaPozajmice(), "datumVracanja IS NULL")
                .Cast<StavkaPozajmice>().ToList();

            foreach (var knjiga in knjige)
            {
                int pozajmljeno = aktivneStavke.Count(s => s.IdKnjige == knjiga.Id);
                knjiga.BrojSlobodnih = knjiga.BrojPrimeraka - pozajmljeno;
            }

            Result = knjige;
        }
    }
}