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
    public class KreirajClanaSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var c = new Clan
            {
                Ime = "Marko",
                Prezime = "Marković",
                Telefon = 123456,
                DatumOd = DateTime.Today,
                DatumDo = DateTime.Today.AddYears(1),
                IdClanstva = 1
            };
            var so = new KreirajClanaSO(c);
            Assert.NotNull(so);
        }

        [Fact]
        public void ExecuteTemplate_DodajeClanaNBazu()
        {
            var c = new Clan
            {
                Ime = "XUnitTestIme",
                Prezime = "XUnitTestPrezime",
                Telefon = 999888777,
                DatumOd = DateTime.Today,
                DatumDo = DateTime.Today.AddYears(1),
                IdClanstva = 1
            };
            new KreirajClanaSO(c).ExecuteTemplate();

            var pretraga = new PretraziClanoveSO("XUnitTestIme");
            pretraga.ExecuteTemplate();
            Assert.NotNull(pretraga.Result);
            Assert.Contains(pretraga.Result, x => x.Ime == "XUnitTestIme");

            // Cleanup
            var dodat = pretraga.Result.First(x => x.Ime == "XUnitTestIme");
            new ObrisiClanaSO(dodat.Id).ExecuteTemplate();
        }
    }
}
