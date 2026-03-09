using System;
using System.Collections.Generic;
using System.Linq;
using Domeni;

namespace SistemskeOp
{
    /// <summary>
    /// Sistemska operacija za brisanje člana biblioteke iz sistema (SK8).
    /// Pre brisanja proverava da li član ima ikakve pozajmice u sistemu —
    /// ako ih ima, brisanje se odbija radi očuvanja integriteta podataka.
    /// </summary>
    public class ObrisiClanaSO : SOBase
    {
        private long id;

        /// <summary>
        /// Inicijalizuje operaciju sa identifikatorom člana koji se briše.
        /// </summary>
        /// <param name="id">Identifikator člana koji se briše iz sistema.</param>
        public ObrisiClanaSO(long id)
        {
            this.id = id;
        }

        /// <inheritdoc/>
        /// <exception cref="Exception">
        /// Baca se ako član ima jednu ili više pozajmica u sistemu
        /// (bez obzira da li su aktivne ili završene).
        /// </exception>
        protected override void ExecuteConcreteOperation()
        {
            // Provera: da li član ima pozajmice u sistemu
            List<IEntity> pozajmice = broker.GetByCondition(new Pozajmica(), $"idClan = {id}");

            if (pozajmice.Count > 0)
                throw new Exception(
                    $"Član ne može biti obrisan jer ima {pozajmice.Count} pozajmica u sistemu.");

            broker.Delete(new Clan(), $"idClan = {id}");
        }
    }
}
