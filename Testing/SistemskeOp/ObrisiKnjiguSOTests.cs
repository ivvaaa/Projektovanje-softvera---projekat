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
    public class ObrisiKnjiguSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var so = new ObrisiKnjiguSO(1);
            Assert.NotNull(so);
        }

        [Fact]
        public void ExecuteTemplate_BacaIzuzetakAkoJeIdNula()
        {
            var so = new ObrisiKnjiguSO(0);
            Assert.Throws<ArgumentException>(() => so.ExecuteTemplate());
        }

        [Fact]
        public void ExecuteTemplate_BacaIzuzetakAkoJeIdNegativni()
        {
            var so = new ObrisiKnjiguSO(-5);
            Assert.Throws<ArgumentException>(() => so.ExecuteTemplate());
        }

        [Fact]
        public void ExecuteTemplate_BriseKnjiguIzBaze()
        {
            // Ubaci testnu knjigu
            var k = new Knjiga { Naziv = "ZaBrisanje_XUnit", ImePisca = "Test", PrezimePisca = "Brisanje", BrojPrimeraka = 1 };
            new UbaciKnjiguSO(k).ExecuteTemplate();

            var pretraga = new PretraziKnjigeSO("ZaBrisanje_XUnit");
            pretraga.ExecuteTemplate();
            var ubacena = pretraga.Result.First();

            // Obriši
            new ObrisiKnjiguSO(ubacena.Id).ExecuteTemplate();

            // Provjeri da više ne postoji
            var provjera = new PretraziKnjigeSO("ZaBrisanje_XUnit");
            provjera.ExecuteTemplate();
            Assert.Empty(provjera.Result);
        }
    }
}
