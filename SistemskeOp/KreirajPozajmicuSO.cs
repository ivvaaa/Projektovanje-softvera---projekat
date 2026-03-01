using Domeni;

namespace SistemskeOp
{
    public class KreirajPozajmicuSO : SOBase
    {
        private Pozajmica pozajmica;
        public long Result { get; private set; }

        public KreirajPozajmicuSO(Pozajmica p)
        {
            pozajmica = p;
        }

        protected override void ExecuteConcreteOperation()
        {
            //ucitaj sve aktivne stavke, pa dostupnost
            List<IEntity> listaStavki = broker.GetByCondition(new StavkaPozajmice(), "datumVracanja IS NULL");
            List<StavkaPozajmice> aktivneStavke = listaStavki.Cast<StavkaPozajmice>().ToList();

            foreach (var stavka in pozajmica.Stavke) //svakak knjiga u poz koju sada kriramo
            {
                //ucitaj knjgu da dobijemo broj primeraka
                List<IEntity> listaKnjiga = broker.GetByCondition(new Knjiga(), $"idKnjiga = {stavka.IdKnjige}");
                Knjiga knjiga = listaKnjiga.Cast<Knjiga>().FirstOrDefault();

                if (knjiga == null)
                    throw new Exception($"Knjiga sa ID {stavka.IdKnjige} ne postoji.");

                int pozajmljeno = aktivneStavke.Count(s => s.IdKnjige == stavka.IdKnjige); //koliko je bas te knjige pozajmljeno
                int slobodnih = knjiga.BrojPrimeraka - pozajmljeno; //koliko u iance imamo - koliko je polajmljeno

                if (slobodnih <= 0)
                    throw new Exception($"Knjiga '{knjiga.Naziv}' nije dostupna — svi primerci su pozajmljeni.");
            }

            long idPozajmice = broker.AddAndGetId(pozajmica); //upisuje red u tabelu Pozajmica, da bi mogli da pravimo stavke 
            Result = idPozajmice;

            foreach (var stavka in pozajmica.Stavke)
            {
                stavka.IdPozajmica = idPozajmice;
                broker.Add(stavka);
            }
        }
    }
}
