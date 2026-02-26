using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    //vratiListuKnjiga(kriterijumKnjiga, Lista<Knjiga>)
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
            //basic
            string condition = $"naziv LIKE '%{kriterijum}%' OR imePisca LIKE '%{kriterijum}%' OR prezimePisca LIKE '%{kriterijum}%'";
            List<IEntity> listaKnjiga = broker.GetByCondition(new Knjiga(), condition);
            List<Knjiga> knjige = listaKnjiga.Cast<Knjiga>().ToList();

            //sve knjige iz akrivnih poz - znaci koje nisu vracene
            List<IEntity> listaStavki = broker.GetByCondition(new StavkaPozajmice(), "datumVracanja IS NULL");
            List<StavkaPozajmice> aktivneStavke = listaStavki.Cast<StavkaPozajmice>().ToList();

            //broj slobodnih za svaku knjigu
            foreach (var knjiga in knjige)
            {
                int pozajmljeno = aktivneStavke.Count(s => s.IdKnjige == knjiga.Id);
                knjiga.BrojSlobodnih = knjiga.BrojPrimeraka - pozajmljeno;
            }

            Result = knjige;
        }
    }
}

