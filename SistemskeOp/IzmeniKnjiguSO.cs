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
            // Validacija
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

            int brojPozajmljenih = broker.GetBrojPozajmljenihPrimeraka(knjiga.Id);

            if (knjiga.BrojPrimeraka < brojPozajmljenih)
            {
                throw new InvalidOperationException(
                    $"Ne možete smanjiti broj primeraka na {knjiga.BrojPrimeraka}. " +
                    $"Trenutno je pozajmljeno {brojPozajmljenih} primeraka.");
            }

            string setClause = $"naziv = '{knjiga.Naziv}', imePisca = '{knjiga.ImePisca}', prezimePisca = '{knjiga.PrezimePisca}', brojPrimeraka = {knjiga.BrojPrimeraka}";
            string condition = $"idKnjiga = {knjiga.Id}";

            broker.Update(knjiga, setClause, condition);
        }
    }
}