using System;
using System.Collections.Generic;
using System.Linq;
using Domeni;

namespace SistemskeOp
{
    /// <summary>
    /// Sistemska operacija za izmenu podataka o članu biblioteke (SK7).
    /// Ažurira sva polja člana u bazi podataka osim identifikatora.
    /// </summary>
    public class IzmeniClanaSO : SOBase
    {
        private Clan clan;

        /// <summary>
        /// Inicijalizuje operaciju sa ažuriranim podacima člana.
        /// </summary>
        /// <param name="c">
        /// Clan sa novim vrednostima. Mora imati popunjen <c>Id</c> radi identifikacije,
        /// kao i sva ostala polja: <c>Ime</c>, <c>Prezime</c>, <c>Telefon</c>,
        /// <c>DatumOd</c>, <c>DatumDo</c> i <c>IdClanstva</c>.
        /// </param>
        public IzmeniClanaSO(Clan c)
        {
            clan = c;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            string setClause = $"ime = '{clan.Ime}', prezime = '{clan.Prezime}', " +
                               $"telefon = {clan.Telefon}, datumOd = '{clan.DatumOd:yyyy-MM-dd}', " +
                               $"datumDo = '{clan.DatumDo:yyyy-MM-dd}', idClanstvo = {clan.IdClanstva}";
            string condition = "idClan = " + clan.Id;
            broker.Update(clan, setClause, condition);
        }
    }
}
