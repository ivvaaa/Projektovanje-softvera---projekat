using Domeni;

namespace SistemskeOp
{
    // signal PromeniKnjiga(Knjiga)
    public class IzmeniKnjiguSO : SOBase
    {
        private Knjiga knjiga;

        public IzmeniKnjiguSO(Knjiga k)
        {
            knjiga = k;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (knjiga == null)
                throw new ArgumentNullException(nameof(knjiga), "Knjiga ne može biti null.");
            if (string.IsNullOrWhiteSpace(knjiga.Naziv))
                throw new ArgumentException("Naziv knjige je obavezan.");
            if (string.IsNullOrWhiteSpace(knjiga.ImePisca))
                throw new ArgumentException("Ime pisca je obavezno.");
            if (string.IsNullOrWhiteSpace(knjiga.PrezimePisca))
                throw new ArgumentException("Prezime pisca je obavezno.");
            if (knjiga.BrojPrimeraka < 1)
                throw new ArgumentException("Broj primeraka mora biti najmanje 1.");

            //provera-  broj aktivnih pozajmica za ovu knjigu
            List<IEntity> listaStavki = broker.GetByCondition(new StavkaPozajmice(), $"StavkaPozajmice.idKnjiga = {knjiga.Id} AND datumVracanja IS NULL");
            int pozajmljeno = listaStavki.Count;

            if (knjiga.BrojPrimeraka < pozajmljeno)
                throw new InvalidOperationException(
                    $"Ne možete smanjiti broj primeraka na {knjiga.BrojPrimeraka}. " +
                    $"Trenutno je pozajmljeno {pozajmljeno} primeraka.");

            string setClause = $"naziv = '{knjiga.Naziv}', imePisca = '{knjiga.ImePisca}', prezimePisca = '{knjiga.PrezimePisca}', brojPrimeraka = {knjiga.BrojPrimeraka}";
            broker.Update(knjiga, setClause, $"idKnjiga = {knjiga.Id}");
        }
    }
}
