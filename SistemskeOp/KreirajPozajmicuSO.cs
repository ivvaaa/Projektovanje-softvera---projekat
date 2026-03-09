using System;
using System.Collections.Generic;
using System.Linq;
using Domeni;

namespace SistemskeOp
{
    /// <summary>
    /// Sistemska operacija za kreiranje nove pozajmice (SK1).
    /// Pre upisa proverava dostupnost svake tražene knjige — ako i jedna nije dostupna,
    /// cela operacija se odbija. Nakon uspešne provere upisuje pozajmicu i sve njene stavke.
    /// </summary>
    public class KreirajPozajmicuSO : SOBase
    {
        private Pozajmica pozajmica;

        /// <summary>
        /// Identifikator novokreirane pozajmice u bazi podataka.
        /// Popunjava se nakon uspešnog izvršavanja operacije.
        /// </summary>
        public long Result { get; private set; }

        /// <summary>
        /// Inicijalizuje operaciju sa pozajmicom koja se kreira.
        /// </summary>
        /// <param name="p">
        /// Pozajmica sa popunjenom listom <see cref="Pozajmica.Stavke"/>.
        /// Svaka stavka mora imati <c>IdKnjige</c> i <c>RokPozajmice</c>.
        /// </param>
        public KreirajPozajmicuSO(Pozajmica p)
        {
            pozajmica = p;
        }

        /// <inheritdoc/>
        /// <exception cref="Exception">
        /// Baca se ako knjiga sa zadatim ID-em ne postoji,
        /// ili ako su svi primerci te knjige trenutno pozajmljeni.
        /// </exception>
        protected override void ExecuteConcreteOperation()
        {
            // Učitaj sve aktivne stavke da bismo proverili dostupnost
            List<IEntity> listaStavki = broker.GetByCondition(new StavkaPozajmice(), "datumVracanja IS NULL");
            List<StavkaPozajmice> aktivneStavke = listaStavki.Cast<StavkaPozajmice>().ToList();

            foreach (var stavka in pozajmica.Stavke)
            {
                // Proveri da li knjiga postoji
                List<IEntity> listaKnjiga = broker.GetByCondition(new Knjiga(), $"idKnjiga = {stavka.IdKnjige}");
                Knjiga knjiga = listaKnjiga.Cast<Knjiga>().FirstOrDefault();

                if (knjiga == null)
                    throw new Exception($"Knjiga sa ID {stavka.IdKnjige} ne postoji.");

                // Proveri dostupnost: ukupno - pozajmljeno = slobodno
                int pozajmljeno = aktivneStavke.Count(s => s.IdKnjige == stavka.IdKnjige);
                int slobodnih = knjiga.BrojPrimeraka - pozajmljeno;

                if (slobodnih <= 0)
                    throw new Exception($"Knjiga '{knjiga.Naziv}' nije dostupna — svi primerci su pozajmljeni.");
            }

            // Upiši pozajmicu i odmah dobij njen ID (potreban za stavke)
            long idPozajmice = broker.AddAndGetId(pozajmica);
            Result = idPozajmice;

            // Upiši svaku stavku sa ispravnim ID-em pozajmice
            foreach (var stavka in pozajmica.Stavke)
            {
                stavka.IdPozajmica = idPozajmice;
                broker.Add(stavka);
            }
        }
    }
}
