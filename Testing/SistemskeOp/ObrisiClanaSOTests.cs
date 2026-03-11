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
    public class ObrisiClanaSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var so = new ObrisiClanaSO(1);
            Assert.NotNull(so);
        }

        [Fact]
        public void ExecuteTemplate_BriseClanaIzBaze()
        {
            var c = new Clan
            {
                Ime = "BrisanjeTestIme",
                Prezime = "BrisanjeTestPrezime",
                Telefon = 444555666,
                DatumOd = DateTime.Today,
                DatumDo = DateTime.Today.AddYears(1),
                IdClanstva = 1
            };
            new KreirajClanaSO(c).ExecuteTemplate();

            var pretraga = new PretraziClanoveSO("BrisanjeTestIme");
            pretraga.ExecuteTemplate();
            var clan = pretraga.Result.First();

            new ObrisiClanaSO(clan.Id).ExecuteTemplate();

            var provjera = new PretraziClanoveSO("BrisanjeTestIme");
            provjera.ExecuteTemplate();
            Assert.Empty(provjera.Result);
        }
    }
}

