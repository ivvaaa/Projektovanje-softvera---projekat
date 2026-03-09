using System;
using System.Collections.Generic;
using System.Linq;
using Domeni;

namespace SistemskeOp
{
    /// <summary>
    /// Sistemska operacija za izmenu podataka o knjizi (SK16).
    /// Validira sve ulazne podatke i proverava da novi broj primeraka
    /// nije manji od broja trenutno pozajmljenih primeraka pre ažuriranja.
    /// </summary>
    public class IzmeniKnjiguSO : SOBase
    {
        private Knjiga knjiga;

        /// <summary>
        /// Inicijalizuje operaciju sa ažuriranim podacima knjige.
        /// </summary>
        /// <param name="k">
        /// Knjiga sa novim vrednostima. Mora imati popunjen <c>Id</c> radi identifikacije
        /// i sva obavezna polja: <c>Naziv</c>, <c>ImePisca</c>, <c>PrezimePisca</c>, <c>BrojPrimeraka</c>.
        /// </param>
        public IzmeniKnjiguSO(Knjiga k)
        {
            knjiga = k;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">Ako je prosleđena knjiga <c>null</c>.</exception>
        /// <exception cref="ArgumentException">
        /// Ako je naziv, ime ili prezime pisca prazno, ili ako je broj primeraka manji od 1.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Ako je novi broj primeraka manji od broja trenutno pozajmljenih primeraka.
        /// </exception>
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

            // Provera: novi broj primeraka ne sme biti manji od broja aktivnih pozajmica
            List<IEntity> listaStavki = broker.GetByCondition(new StavkaPozajmice(),
                $"StavkaPozajmice.idKnjiga = {knjiga.Id} AND datumVracanja IS NULL");
            int pozajmljeno = listaStavki.Count;

            if (knjiga.BrojPrimeraka < pozajmljeno)
                throw new InvalidOperationException(
                    $"Ne možete smanjiti broj primeraka na {knjiga.BrojPrimeraka}. " +
                    $"Trenutno je pozajmljeno {pozajmljeno} primeraka.");

            string setClause = $"naziv = '{knjiga.Naziv}', imePisca = '{knjiga.ImePisca}', " +
                               $"prezimePisca = '{knjiga.PrezimePisca}', brojPrimeraka = {knjiga.BrojPrimeraka}";
            broker.Update(knjiga, setClause, $"idKnjiga = {knjiga.Id}");
        }
    }
}
