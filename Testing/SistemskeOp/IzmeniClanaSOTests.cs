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
    public class IzmeniClanaSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var c = new Clan
            {
                Id = 1,
                Ime = "Marko",
                Prezime = "Marković",
                Telefon = 123456,
                DatumOd = DateTime.Today,
                DatumDo = DateTime.Today.AddYears(1),
                IdClanstva = 1
            };
            var so = new IzmeniClanaSO(c);
            Assert.NotNull(so);
        }

        [Fact]
        public void ExecuteTemplate_IzmenjujeClanaPodatke()
        {
            // Dodaj testnog clana
            var c = new Clan
            {
                Ime = "IzmeniTestIme",
                Prezime = "IzmeniTestPrezime",
                Telefon = 111222333,
                DatumOd = DateTime.Today,
                DatumDo = DateTime.Today.AddYears(1),
                IdClanstva = 1
            };
            new KreirajClanaSO(c).ExecuteTemplate();

            var pretraga = new PretraziClanoveSO("IzmeniTestIme");
            pretraga.ExecuteTemplate();
            var clan = pretraga.Result.First();

            // Izmeni telefon
            clan.Telefon = 999000111;
            new IzmeniClanaSO(clan).ExecuteTemplate();

            // Provjeri
            var provjera = new PretraziClanoveSO("IzmeniTestIme");
            provjera.ExecuteTemplate();
            Assert.Equal(999000111, provjera.Result.First().Telefon);

            // Cleanup
            new ObrisiClanaSO(clan.Id).ExecuteTemplate();
        }
    }
}

