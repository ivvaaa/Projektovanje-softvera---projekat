using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;
using SistemskeOp;
using Xunit;

namespace Testovi.SistemskeOp
{
    public class UbaciKnjiguSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var k = new Knjiga { Naziv = "Test", ImePisca = "Ime", PrezimePisca = "Prez", BrojPrimeraka = 1 };
            var so = new UbaciKnjiguSO(k);
            Assert.NotNull(so);
        }

        [Fact]
        public void ExecuteTemplate_DodajeKnjiguUBazu()
        {
            var k = new Knjiga { Naziv = "TestKnjigaXUnit", ImePisca = "XUnit", PrezimePisca = "Test", BrojPrimeraka = 1 };
            var so = new UbaciKnjiguSO(k);
            so.ExecuteTemplate();

            // Provjeri da li je knjiga stvarno dodata
            var pretraga = new PretraziKnjigeSO("TestKnjigaXUnit");
            pretraga.ExecuteTemplate();
            Assert.NotNull(pretraga.Result);
            Assert.Contains(pretraga.Result, x => x.Naziv == "TestKnjigaXUnit");

            // Cleanup
            var obrisana = pretraga.Result.First(x => x.Naziv == "TestKnjigaXUnit");
            new ObrisiKnjiguSO(obrisana.Id).ExecuteTemplate();
        }
    }
}

