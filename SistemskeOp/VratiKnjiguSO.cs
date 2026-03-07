using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    //PromeniPozajmica - SK3
    //1: vraćanje knjige (postavlja datumVracanja)
    //2: izmena roka pozajmice
    public class VratiKnjiguSO : SOBase
    {
        private long idPozajmica;
        private long? idKnjiga;      //izmena roka null
        private DateTime? noviRok;   //vracanje null

        //SK3a - vraćanje knjige
        public VratiKnjiguSO(long idPozajmica, long idKnjiga)
        {
            this.idPozajmica = idPozajmica;
            this.idKnjiga = idKnjiga;
            this.noviRok = null;
        }

        //SK3b - izmena roka pozajmice
        public VratiKnjiguSO(long idPozajmica, DateTime noviRok)
        {
            this.idPozajmica = idPozajmica;
            this.idKnjiga = null;
            this.noviRok = noviRok;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (noviRok.HasValue)
            {
                //SK3b: izmena roka za sve aktivne (nevraćene) stavke
                string setClause = $"rokPozajmice = '{noviRok.Value:yyyy-MM-dd}'";
                string condition = $"idPozajmica = {idPozajmica} AND datumVracanja IS NULL";
                broker.Update(new StavkaPozajmice(), setClause, condition);
            }
            else
            {
                //SK3a: vraćanje konkretne knjige
                string setClause = $"datumVracanja = '{DateTime.Now:yyyy-MM-dd}'";
                string condition = $"idPozajmica = {idPozajmica} AND idKnjiga = {idKnjiga} AND datumVracanja IS NULL";
                broker.Update(new StavkaPozajmice(), setClause, condition);
            }
        }
    }
}