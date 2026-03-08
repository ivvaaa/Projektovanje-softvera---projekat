using System;
using System.Collections.Generic;
using System.Linq;
using Domeni;

namespace SistemskeOp
{
    /// <summary>
    /// Sistemska operacija za brisanje knjige iz sistema (SK17).
    /// Pre brisanja proverava da li knjiga postoji i da nema aktivnih (nevraćenih) pozajmica.
    /// </summary>
    public class ObrisiKnjiguSO : SOBase
    {
        private long id;

        /// <summary>
        /// Inicijalizuje operaciju sa identifikatorom knjige koja se briše.
        /// </summary>
        /// <param name="id">Identifikator knjige. Mora biti pozitivan broj.</param>
        public ObrisiKnjiguSO(long id)
        {
            this.id = id;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentException">Ako identifikator knjige nije pozitivan broj.</exception>
        /// <exception cref="InvalidOperationException">
        /// Ako knjiga sa zadatim ID-em ne postoji u bazi,
        /// ili ako knjiga ima pozajmljene primerke koji još nisu vraćeni.
        /// </exception>
        protected override void ExecuteConcreteOperation()
        {
            if (id <= 0)
                throw new ArgumentException("ID knjige mora biti pozitivan broj.");

            // Provera: da li knjiga uopšte postoji
            List<IEntity> listaKnjiga = broker.GetByCondition(new Knjiga(), $"idKnjiga = {id}");
            if (listaKnjiga.Count == 0)
                throw new InvalidOperationException($"Knjiga sa ID={id} ne postoji.");

            // Provera: da li knjiga ima aktivne (nevraćene) pozajmice
            List<IEntity> listaStavki = broker.GetByCondition(new StavkaPozajmice(),
                $"StavkaPozajmice.idKnjiga = {id} AND datumVracanja IS NULL");
            if (listaStavki.Count > 0)
                throw new InvalidOperationException(
                    $"Knjiga ne može biti obrisana jer ima {listaStavki.Count} pozajmljenih primeraka.");

            broker.Delete(new Knjiga(), $"idKnjiga = {id}");
        }
    }
}
