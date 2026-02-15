using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    public class IzmeniKnjiguSO : SOBase
    {
        private Knjiga knjiga;

        public IzmeniKnjiguSO(Knjiga k)
        {
            knjiga = k;
        }

        protected override void ExecuteConcreteOperation()
        {
            string setClause = $"naziv = '{knjiga.Naziv}', imePisca = '{knjiga.ImePisca}', prezimePisca = '{knjiga.PrezimePisca}', brojPrimeraka = {knjiga.BrojPrimeraka}";
            string condition = "idKnjiga = " + knjiga.Id;
            broker.Update(new Knjiga(), setClause, condition);
        }
    }
}
