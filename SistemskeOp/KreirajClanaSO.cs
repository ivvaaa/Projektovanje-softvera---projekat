using Domeni;

namespace SistemskeOp
{
    /// <summary>
    /// Sistemska operacija za kreiranje novog člana biblioteke (SK5).
    /// Upisuje prosleđenog člana u tabelu <c>Clan</c> u bazi podataka.
    /// </summary>
    public class KreirajClanaSO : SOBase
    {
        private Clan clan;

        /// <summary>
        /// Inicijalizuje operaciju sa podacima novog člana.
        /// </summary>
        /// <param name="c">
        /// Clan koji se upisuje u bazu. Mora imati popunjena polja
        /// <c>Ime</c>, <c>Prezime</c>, <c>Telefon</c>, <c>DatumOd</c>,
        /// <c>DatumDo</c> i <c>IdClanstva</c>.
        /// </param>
        public KreirajClanaSO(Clan c)
        {
            clan = c;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(clan);
        }
    }
}
