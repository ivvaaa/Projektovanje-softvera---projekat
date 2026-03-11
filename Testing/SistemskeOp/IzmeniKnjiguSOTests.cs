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
    public class IzmeniKnjiguSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var k = new Knjiga { Naziv = "Test", ImePisca = "Ime", PrezimePisca = "Prez", BrojPrimeraka = 1 };
            var so = new IzmeniKnjiguSO(k);
            Assert.NotNull(so);
        }

        [Fact]
        public void ExecuteTemplate_BacaIzuzetakAkoJeKnjigaNull()
        {
            var so = new IzmeniKnjiguSO(null);
            Assert.Throws<ArgumentNullException>(() => so.ExecuteTemplate());
        }

        [Fact]
        public void ExecuteTemplate_IzmenjujeKnjiguUBazi()
        {
            // Ubaci testnu knjigu
            var k = new Knjiga { Naziv = "OriginalniNaziv_XUnit", ImePisca = "Autor", PrezimePisca = "Test", BrojPrimeraka = 1 };
            new UbaciKnjiguSO(k).ExecuteTemplate();

            var pretraga = new PretraziKnjigeSO("OriginalniNaziv_XUnit");
            pretraga.ExecuteTemplate();
            var ubacena = pretraga.Result.First();

            // Izmeni
            ubacena.Naziv = "IzmenjeniNaziv_XUnit";
            new IzmeniKnjiguSO(ubacena).ExecuteTemplate();

            // Provjeri izmenu
            var provjera = new PretraziKnjigeSO("IzmenjeniNaziv_XUnit");
            provjera.ExecuteTemplate();
            Assert.NotEmpty(provjera.Result);

            // Cleanup
            new ObrisiKnjiguSO(ubacena.Id).ExecuteTemplate();
        }
    }
}
