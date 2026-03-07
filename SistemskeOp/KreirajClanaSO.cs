using Domeni;

namespace SistemskeOp
{
    public class KreirajClanaSO : SOBase
    {
        private Clan clan;

        public KreirajClanaSO(Clan c)
        {
            clan = c;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add(clan);
        }
    }
}
