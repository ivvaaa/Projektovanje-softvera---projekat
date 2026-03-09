using BrokerBP;

namespace SistemskeOp
{
    /// <summary>
    /// Apstraktna osnovna klasa za sve sistemske operacije.
    /// Implementira <b>Template Method</b> obrazac: metoda <see cref="ExecuteTemplate"/> definiše
    /// fiksan redosled koraka (otvaranje konekcije → transakcija → konkretna operacija → commit/rollback → zatvaranje),
    /// dok svaka podklasa implementira samo <see cref="ExecuteConcreteOperation"/>.
    /// </summary>
    public abstract class SOBase
    {
        /// <summary>
        /// Instanca brokera za pristup bazi podataka.
        /// Dostupna svim podklasama sistemskih operacija.
        /// </summary>
        protected Broker broker;

        /// <summary>
        /// Inicijalizuje novu instancu i kreira <see cref="Broker"/> za pristup bazi podataka.
        /// </summary>
        public SOBase()
        {
            broker = new Broker();
        }

        /// <summary>
        /// Izvršava sistemsku operaciju prema Template Method obrascu.
        /// Redosled koraka:
        /// <list type="number">
        ///   <item>Otvara konekciju prema bazi podataka.</item>
        ///   <item>Pokreće transakciju.</item>
        ///   <item>Poziva <see cref="ExecuteConcreteOperation"/> iz konkretne podklase.</item>
        ///   <item>Commituje transakciju ako nije bilo grešaka.</item>
        ///   <item>Rollbackuje transakciju u slučaju izuzetka i prosleđuje izuzetak pozivaču.</item>
        ///   <item>Zatvara konekciju u svakom slučaju (finally blok).</item>
        /// </list>
        /// </summary>
        /// <exception cref="Exception">
        /// Prosleđuje svaki izuzetak bačen iz <see cref="ExecuteConcreteOperation"/> nakon rollbacka.
        /// </exception>
        public void ExecuteTemplate()
        {
            try
            {
                broker.OpenConnection();
                broker.BeginTransaction();

                ExecuteConcreteOperation();

                broker.Commit();
            }
            catch (Exception)
            {
                broker.Rollback();
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        /// <summary>
        /// Apstraktna metoda koju svaka konkretna sistemska operacija mora implementirati.
        /// Poziva se unutar aktivne transakcije baze podataka.
        /// Sve izmene baze automatski se commituju ili rollbackuju od strane <see cref="ExecuteTemplate"/>.
        /// </summary>
        protected abstract void ExecuteConcreteOperation();
    }
}
