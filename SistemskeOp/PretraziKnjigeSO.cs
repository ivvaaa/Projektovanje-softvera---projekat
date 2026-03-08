using System;
using System.Collections.Generic;
using System.Linq;
using Domeni;

namespace SistemskeOp
{
    /// <summary>
    /// Sistemska operacija za pretragu knjiga u biblioteci (SK10/SK15).
    /// Prazan kriterijum vraća sve knjige. Za svaku pronađenu knjigu
    /// izračunava broj slobodnih primeraka na osnovu trenutno aktivnih pozajmica.
    /// </summary>
    public class PretraziKnjigeSO : SOBase
    {
        private string kriterijum;

        /// <summary>
        /// Lista pronađenih knjiga sa izračunatim <see cref="Knjiga.BrojSlobodnih"/>.
        /// Popunjava se nakon izvršavanja operacije.
        /// </summary>
        public List<Knjiga> Result { get; private set; }

        /// <summary>
        /// Inicijalizuje operaciju sa kriterijumom pretrage.
        /// </summary>
        /// <param name="kriterijum">
        /// Tekst za pretragu po naslovu knjige, imenu ili prezimenu pisca.
        /// Prazan string ili <c>null</c> vraća sve knjige.
        /// </param>
        public PretraziKnjigeSO(string kriterijum)
        {
            this.kriterijum = kriterijum;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            List<Knjiga> knjige;

            if (string.IsNullOrWhiteSpace(kriterijum))
            {
                knjige = broker.GetAll(new Knjiga()).Cast<Knjiga>().ToList();
            }
            else
            {
                string condition = $"naziv LIKE '%{kriterijum}%' OR imePisca LIKE '%{kriterijum}%' OR prezimePisca LIKE '%{kriterijum}%'";
                knjige = broker.GetByCondition(new Knjiga(), condition).Cast<Knjiga>().ToList();
            }

            // Učitaj sve aktivne stavke da izračunamo broj slobodnih primeraka
            List<StavkaPozajmice> aktivneStavke = broker
                .GetByCondition(new StavkaPozajmice(), "datumVracanja IS NULL")
                .Cast<StavkaPozajmice>().ToList();

            foreach (var knjiga in knjige)
            {
                int pozajmljeno = aktivneStavke.Count(s => s.IdKnjige == knjiga.Id);
                knjiga.BrojSlobodnih = knjiga.BrojPrimeraka - pozajmljeno;
            }

            Result = knjige;
        }
    }
}
