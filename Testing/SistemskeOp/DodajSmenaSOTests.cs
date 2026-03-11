using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;
using SistemskeOp;
using Xunit;

namespace Testing.SistemskeOp
{
    public class DodajSmenaSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var s = new BibSmena { IdBibliotekara = 1, IdTerminSmene = 16, Datum = DateTime.Today.AddDays(1) };
            var so = new DodajSmenaSO(s);
            Assert.NotNull(so);
        }

        [Fact]
        public void ExecuteTemplate_DodajeSmenuUBazu()
        {
            var datum = DateTime.Today.AddDays(new Random().Next(100, 500));
            var s = new BibSmena { IdBibliotekara = 1, IdTerminSmene = 16, Datum = datum };
            new DodajSmenaSO(s).ExecuteTemplate();

            var pretraga = new PretraziSmeneSO("");
            pretraga.ExecuteTemplate();

            Assert.Contains(pretraga.Result, x =>
                x.IdBibliotekara == 1 &&
                x.IdTerminSmene == 16 &&
                x.Datum.Date == datum.Date);
        }

        [Fact]
        public void ExecuteTemplate_BacaIzuzetakAkoBibliotekarVecImaSmenuNaDatum()
        {
            var datum = DateTime.Today.AddDays(new Random().Next(100, 500));

            // Dodaj prvu smenu
            new DodajSmenaSO(new BibSmena { IdBibliotekara = 1, IdTerminSmene = 16, Datum = datum }).ExecuteTemplate();

            // Pokušaj dodati drugu smenu istom bibliotekaru na isti datum
            var so = new DodajSmenaSO(new BibSmena { IdBibliotekara = 1, IdTerminSmene = 17, Datum = datum });
            Assert.Throws<Exception>(() => so.ExecuteTemplate());
        }
    }
}

