using Domeni;
using SistemskeOp;
using Xunit;

namespace Testovi
{
    /// <summary>
    /// Testovi za sistemsku operaciju LoginSO.
    /// </summary>
    public class LoginSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var b = new Bibliotekar { Username = "iva", Password = "iva123" };
            var so = new LoginSO(b);
            Assert.NotNull(so);
        }

        [Fact]
        public void Result_PreIzvrsavanja_JeNull()
        {
            var b = new Bibliotekar { Username = "iva", Password = "123" };
            var so = new LoginSO(b);
            Assert.Null(so.Result);
        }
    }

    /// <summary>
    /// Testovi za sistemsku operaciju UbaciKnjiguSO.
    /// </summary>
    public class UbaciKnjiguSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var k = new Knjiga { Naziv = "Test", ImePisca = "Ime", PrezimePisca = "Prez", BrojPrimeraka = 1 };
            var so = new UbaciKnjiguSO(k);
            Assert.NotNull(so);
        }
    }

    /// <summary>
    /// Testovi za sistemsku operaciju IzmeniKnjiguSO — validacija pre baze.
    /// </summary>
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
        public void ExecuteTemplate_BacaIzuzetakAkoJeNazivPrazan()
        {
            var k = new Knjiga { Naziv = "", ImePisca = "Ime", PrezimePisca = "Prez", BrojPrimeraka = 1 };
            var so = new IzmeniKnjiguSO(k);
            Assert.Throws<ArgumentException>(() => so.ExecuteTemplate());
        }

        [Fact]
        public void ExecuteTemplate_BacaIzuzetakAkoJeImePiscaPrazno()
        {
            var k = new Knjiga { Naziv = "Naziv", ImePisca = "", PrezimePisca = "Prez", BrojPrimeraka = 1 };
            var so = new IzmeniKnjiguSO(k);
            Assert.Throws<ArgumentException>(() => so.ExecuteTemplate());
        }

        [Fact]
        public void ExecuteTemplate_BacaIzuzetakAkoJePrezimePiscaPrazno()
        {
            var k = new Knjiga { Naziv = "Naziv", ImePisca = "Ime", PrezimePisca = "", BrojPrimeraka = 1 };
            var so = new IzmeniKnjiguSO(k);
            Assert.Throws<ArgumentException>(() => so.ExecuteTemplate());
        }

        [Fact]
        public void ExecuteTemplate_BacaIzuzetakAkoBrojPrimeraka_ManjiOd1()
        {
            var k = new Knjiga { Naziv = "Naziv", ImePisca = "Ime", PrezimePisca = "Prez", BrojPrimeraka = 0 };
            var so = new IzmeniKnjiguSO(k);
            Assert.Throws<ArgumentException>(() => so.ExecuteTemplate());
        }
    }

    /// <summary>
    /// Testovi za sistemsku operaciju ObrisiKnjiguSO — validacija pre baze.
    /// </summary>
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
    }

    /// <summary>
    /// Testovi za sistemsku operaciju KreirajClanaSO.
    /// </summary>
    public class KreirajClanaSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var c = new Clan { Ime = "Marko", Prezime = "Marković", Telefon = 123456 };
            var so = new KreirajClanaSO(c);
            Assert.NotNull(so);
        }
    }

    /// <summary>
    /// Testovi za sistemsku operaciju PretraziClanoveSO.
    /// </summary>
    public class PretraziClanovaSOTests
    {
        [Fact]
        public void Konstruktor_SaKriterijumom_PostavljaObjekat()
        {
            var so = new PretraziClanoveSO("Marko");
            Assert.NotNull(so);
        }

        [Fact]
        public void Konstruktor_SaRezimomClanstva_PostavljaObjekat()
        {
            var so = new PretraziClanoveSO(true);
            Assert.NotNull(so);
        }

        [Fact]
        public void Result_PreIzvrsavanja_JeNull()
        {
            var so = new PretraziClanoveSO("test");
            Assert.Null(so.Result);
        }

        [Fact]
        public void ResultClanstva_PreIzvrsavanja_JeNull()
        {
            var so = new PretraziClanoveSO(true);
            Assert.Null(so.ResultClanstva);
        }
    }

    /// <summary>
    /// Testovi za sistemsku operaciju IzmeniClanaSO.
    /// </summary>
    public class IzmeniClanaSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var c = new Clan { Id = 1, Ime = "Marko", Prezime = "Marković" };
            var so = new IzmeniClanaSO(c);
            Assert.NotNull(so);
        }
    }

    /// <summary>
    /// Testovi za sistemsku operaciju ObrisiClanaSO.
    /// </summary>
    public class ObrisiClanaSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var so = new ObrisiClanaSO(1);
            Assert.NotNull(so);
        }
    }

    /// <summary>
    /// Testovi za sistemsku operaciju KreirajPozajmicuSO.
    /// </summary>
    public class KreirajPozajmicuSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var p = new Pozajmica { IdBibliotekar = 1, IdClan = 2, DatumOd = DateTime.Today };
            var so = new KreirajPozajmicuSO(p);
            Assert.NotNull(so);
        }

        [Fact]
        public void Result_PreIzvrsavanja_JeNula()
        {
            var p = new Pozajmica { IdBibliotekar = 1, IdClan = 2 };
            var so = new KreirajPozajmicuSO(p);
            Assert.Equal(0, so.Result);
        }
    }

    /// <summary>
    /// Testovi za sistemsku operaciju PretraziPozajmiceSO.
    /// </summary>
    public class PretraziPozajmiceSOTests
    {
        [Fact]
        public void Konstruktor_SaKriterijumom_PostavljaObjekat()
        {
            var so = new PretraziPozajmiceSO("test");
            Assert.NotNull(so);
        }

        [Fact]
        public void Konstruktor_SaPraznimKriterijumom_PostavljaObjekat()
        {
            var so = new PretraziPozajmiceSO("");
            Assert.NotNull(so);
        }

        [Fact]
        public void Result_PreIzvrsavanja_JeNull()
        {
            var so = new PretraziPozajmiceSO("test");
            Assert.Null(so.Result);
        }
    }

    /// <summary>
    /// Testovi za sistemsku operaciju PretraziKnjigeSO.
    /// </summary>
    public class PretraziKnjigeSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var so = new PretraziKnjigeSO("test");
            Assert.NotNull(so);
        }

        [Fact]
        public void Konstruktor_SaPraznimKriterijumom_PostavljaObjekat()
        {
            var so = new PretraziKnjigeSO("");
            Assert.NotNull(so);
        }

        [Fact]
        public void Result_PreIzvrsavanja_JeNull()
        {
            var so = new PretraziKnjigeSO("test");
            Assert.Null(so.Result);
        }
    }

    /// <summary>
    /// Testovi za sistemsku operaciju VratiKnjiguSO.
    /// </summary>
    public class VratiKnjiguSOTests
    {
        [Fact]
        public void Konstruktor_SK3a_PostavljaObjekat()
        {
            var so = new VratiKnjiguSO(1L, 2L);
            Assert.NotNull(so);
        }

        [Fact]
        public void Konstruktor_SK3b_PostavljaObjekat()
        {
            var so = new VratiKnjiguSO(1L, DateTime.Today.AddDays(7));
            Assert.NotNull(so);
        }
    }

    /// <summary>
    /// Testovi za sistemsku operaciju DodajSmenaSO.
    /// </summary>
    public class DodajSmenaSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var s = new BibSmena { IdBibliotekara = 1, IdTerminSmene = 16, Datum = DateTime.Today.AddDays(1) };
            var so = new DodajSmenaSO(s);
            Assert.NotNull(so);
        }
    }

    /// <summary>
    /// Testovi za sistemsku operaciju IzmeniSmenaSO — validacija pre baze.
    /// </summary>
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

    /// <summary>
    /// Testovi za sistemsku operaciju PretraziSmeneSO.
    /// </summary>
    public class PretraziSmeneSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var so = new PretraziSmeneSO("Iva");
            Assert.NotNull(so);
        }

        [Fact]
        public void Konstruktor_SaPraznimKriterijumom_PostavljaObjekat()
        {
            var so = new PretraziSmeneSO("");
            Assert.NotNull(so);
        }

        [Fact]
        public void Result_PreIzvrsavanja_JeNull()
        {
            var so = new PretraziSmeneSO("Iva");
            Assert.Null(so.Result);
        }
    }

    /// <summary>
    /// Testovi za sistemsku operaciju VratiTermineSO.
    /// </summary>
    public class VratiTermineSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var so = new VratiTermineSO();
            Assert.NotNull(so);
        }

        [Fact]
        public void Result_PreIzvrsavanja_JeNull()
        {
            var so = new VratiTermineSO();
            Assert.Null(so.Result);
        }
    }
}