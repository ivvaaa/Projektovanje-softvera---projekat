using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    public class IzmeniClanaSO : SOBase
    {
        private Clan clan;

        public IzmeniClanaSO(Clan c)
        {
            clan = c;
        }

        protected override void ExecuteConcreteOperation()
        {
            string setClause = $"ime = '{clan.Ime}', prezime = '{clan.Prezime}', telefon = {clan.Telefon}, datumOd = '{clan.DatumOd:yyyy-MM-dd}', datumDo = '{clan.DatumDo:yyyy-MM-dd}', idClanstvo = {clan.IdClanstva}";
            string condition = "idClan = " + clan.Id;
            broker.Update(new Clan(), setClause, condition);
        }
    }
}
