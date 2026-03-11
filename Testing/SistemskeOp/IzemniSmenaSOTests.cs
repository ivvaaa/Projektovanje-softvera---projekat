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
    }
}

