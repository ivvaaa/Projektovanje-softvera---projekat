using Domeni;
using SistemskeOp;
using Xunit;

namespace Testing.SistemskeOp
{
    public class IzmeniSmenaSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var stara = new BibSmena { IdBibliotekara = 1, IdTerminSmene = 16, Datum = DateTime.Today.AddDays(1) };
            var nova = new BibSmena { IdBibliotekara = 1, IdTerminSmene = 17, Datum = DateTime.Today.AddDays(2) };
            var so = new IzmeniSmenaSO(stara, nova);
            Assert.NotNull(so);
        }

        [Fact]
        public void ExecuteTemplate_BacaIzuzetakAkoJeNoviDatumUProslosti()
        {
            var stara = new BibSmena { IdBibliotekara = 1, IdTerminSmene = 16, Datum = DateTime.Today.AddDays(1) };
            var nova = new BibSmena { IdBibliotekara = 1, IdTerminSmene = 17, Datum = DateTime.Today.AddDays(-3) };
            var so = new IzmeniSmenaSO(stara, nova);
            Assert.Throws<Exception>(() => so.ExecuteTemplate());
        }

        [Fact]
        public void ExecuteTemplate_IzmenjujeTerminSmeneUBazi()
        {
            // Dodaj testnu smenu
            var datum = DateTime.Today.AddDays(new Random().Next(100, 500));
            var stara = new BibSmena { IdBibliotekara = 1, IdTerminSmene = 16, Datum = datum };
            new DodajSmenaSO(stara).ExecuteTemplate();

            // Izmeni termin
            var nova = new BibSmena { IdBibliotekara = 1, IdTerminSmene = 17, Datum = datum };
            new IzmeniSmenaSO(stara, nova).ExecuteTemplate();

            var pretraga = new PretraziSmeneSO("");
            pretraga.ExecuteTemplate();

            Assert.Contains(pretraga.Result, x =>
                x.IdBibliotekara == 1 &&
                x.IdTerminSmene == 17 &&
                x.Datum.Date == datum.Date);

            Assert.DoesNotContain(pretraga.Result, x =>
                x.IdBibliotekara == 1 &&
                x.IdTerminSmene == 16 &&
                x.Datum.Date == datum.Date);
        }

        [Fact]
        public void ExecuteTemplate_BacaIzuzetakAkoBibliotekarVecImaSmenuNaNoviDatum()
        {
            var datum1 = DateTime.Today.AddDays(new Random().Next(100, 500));
            var datum2 = datum1.AddDays(1);

            new DodajSmenaSO(new BibSmena { IdBibliotekara = 1, IdTerminSmene = 16, Datum = datum1 }).ExecuteTemplate();
            new DodajSmenaSO(new BibSmena { IdBibliotekara = 1, IdTerminSmene = 16, Datum = datum2 }).ExecuteTemplate();

            var stara = new BibSmena { IdBibliotekara = 1, IdTerminSmene = 16, Datum = datum1 };
            var nova = new BibSmena { IdBibliotekara = 1, IdTerminSmene = 16, Datum = datum2 };

            Assert.Throws<Exception>(() => new IzmeniSmenaSO(stara, nova).ExecuteTemplate());
        }
    }
}