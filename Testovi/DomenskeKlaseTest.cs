using Domeni;
using Xunit;

namespace Testovi
{
    /// <summary>
    /// Testovi za domensku klasu Bibliotekar.
    /// </summary>
    public class DomenskeKlaseTest
    {
        [Fact]
        public void ImePrezime_VracaImeIPrezime()
        {
            var b = new Bibliotekar { Ime = "Iva", Prezime = "Kostić" };
            Assert.Equal("Iva Kostić", b.ImePrezime);
        }

        [Fact]
        public void ToString_VracaIspravniFormat()
        {
            var b = new Bibliotekar { Ime = "Iva", Prezime = "Kostić", Username = "iva" };
            Assert.Equal("Iva Kostić (iva)", b.ToString());
        }

        [Fact]
        public void TableName_VracaIspravnoIme()
        {
            var b = new Bibliotekar();
            Assert.Equal("Bibliotekar", b.TableName);
        }

        [Fact]
        public void PrimaryKey_VracaIspravniKljuc()
        {
            var b = new Bibliotekar();
            Assert.Equal("idBibliotekar", b.PrimaryKey);
        }

        [Fact]
        public void Values_SadrziIspravneVrednosti()
        {
            var b = new Bibliotekar { Ime = "Iva", Prezime = "Kostić", Username = "iva", Password = "123" };
            Assert.Contains("Iva", b.Values);
            Assert.Contains("Kostić", b.Values);
            Assert.Contains("iva", b.Values);
            Assert.Contains("123", b.Values);
        }

        [Fact]
        public void InsertColumns_SadrziSveKolone()
        {
            var b = new Bibliotekar();
            Assert.Contains("ime", b.InsertColumns);
            Assert.Contains("prezime", b.InsertColumns);
            Assert.Contains("username", b.InsertColumns);
            Assert.Contains("password", b.InsertColumns);
        }
    }

    /// <summary>
    /// Testovi za domensku klasu BibSmena.
    /// </summary>
    public class BibSmenaTests
    {
        [Fact]
        public void ToString_VracaIspravniFormat()
        {
            var s = new BibSmena { Datum = new DateTime(2026, 3, 10) };
            Assert.Equal("Smena: 10.03.2026", s.ToString());
        }

        [Fact]
        public void TableName_VracaIspravnoIme()
        {
            var s = new BibSmena();
            Assert.Equal("[Bib-Smena]", s.TableName);
        }

        [Fact]
        public void PrimaryKey_SadrziSvaTriPolja()
        {
            var s = new BibSmena();
            Assert.Contains("idBibliotekar", s.PrimaryKey);
            Assert.Contains("idTerminSmene", s.PrimaryKey);
            Assert.Contains("datum", s.PrimaryKey);
        }

        [Fact]
        public void Values_SadrziIspravneVrednosti()
        {
            var s = new BibSmena { IdBibliotekara = 1, IdTerminSmene = 16, Datum = new DateTime(2026, 3, 10) };
            Assert.Contains("1", s.Values);
            Assert.Contains("16", s.Values);
            Assert.Contains("2026-03-10", s.Values);
        }

        [Fact]
        public void Join_SadrziObeTabele()
        {
            var s = new BibSmena();
            Assert.Contains("Bibliotekar", s.Join);
            Assert.Contains("TerminSmene", s.Join);
        }
    }

    /// <summary>
    /// Testovi za domensku klasu TerminSmene.
    /// </summary>
    public class TerminSmeneTests
    {
        [Fact]
        public void ToString_VracaTermin()
        {
            var t = new TerminSmene { Termin = "08-12" };
            Assert.Equal("08-12", t.ToString());
        }

        [Fact]
        public void TableName_VracaIspravnoIme()
        {
            var t = new TerminSmene();
            Assert.Equal("TerminSmene", t.TableName);
        }

        [Fact]
        public void PrimaryKey_VracaIspravniKljuc()
        {
            var t = new TerminSmene();
            Assert.Equal("idTerminSmene", t.PrimaryKey);
        }

        [Fact]
        public void Values_SadrziTermin()
        {
            var t = new TerminSmene { Termin = "12-16" };
            Assert.Contains("12-16", t.Values);
        }
    }

    /// <summary>
    /// Testovi za domensku klasu Clan.
    /// </summary>
    public class ClanTests
    {
        [Fact]
        public void ImePrezime_VracaImeIPrezime()
        {
            var c = new Clan { Ime = "Marko", Prezime = "Marković" };
            Assert.Equal("Marko Marković", c.ImePrezime);
        }

        [Fact]
        public void ToString_VracaIspravniFormat()
        {
            var c = new Clan { Ime = "Marko", Prezime = "Marković", Telefon = 123456 };
            Assert.Equal("Marko Marković (Tel: 123456)", c.ToString());
        }

        [Fact]
        public void ClanarinaAktivna_VracaTrueAkoDatumUBuducnosti()
        {
            var c = new Clan { DatumDo = DateTime.Now.AddDays(10) };
            Assert.True(c.ClanarinaAktivna);
        }

        [Fact]
        public void ClanarinaAktivna_VracaFalseAkoDatumUProslosti()
        {
            var c = new Clan { DatumDo = DateTime.Now.AddDays(-1) };
            Assert.False(c.ClanarinaAktivna);
        }

        [Fact]
        public void TableName_VracaIspravnoIme()
        {
            var c = new Clan();
            Assert.Equal("Clan", c.TableName);
        }

        [Fact]
        public void PrimaryKey_VracaIspravniKljuc()
        {
            var c = new Clan();
            Assert.Equal("idClan", c.PrimaryKey);
        }

        [Fact]
        public void Values_SadrziIspravneVrednosti()
        {
            var c = new Clan
            {
                Ime = "Marko",
                Prezime = "Marković",
                Telefon = 123456,
                DatumOd = new DateTime(2025, 1, 1),
                DatumDo = new DateTime(2026, 1, 1),
                IdClanstva = 2
            };
            Assert.Contains("Marko", c.Values);
            Assert.Contains("Marković", c.Values);
            Assert.Contains("123456", c.Values);
        }
    }

    /// <summary>
    /// Testovi za domensku klasu Clanstvo.
    /// </summary>
    public class ClanstvoTests
    {
        [Fact]
        public void ToString_VracaIspravniFormat()
        {
            var c = new Clanstvo { Vrsta = "Godišnja", Cena = 2000 };
            Assert.Equal("Godišnja (2000 RSD)", c.ToString());
        }

        [Fact]
        public void TableName_VracaIspravnoIme()
        {
            var c = new Clanstvo();
            Assert.Equal("Clanstvo", c.TableName);
        }

        [Fact]
        public void PrimaryKey_VracaIspravniKljuc()
        {
            var c = new Clanstvo();
            Assert.Equal("idClanstvo", c.PrimaryKey);
        }

        [Fact]
        public void Values_SadrziCenuIVrstu()
        {
            var c = new Clanstvo { Cena = 2000, Vrsta = "Godišnja" };
            Assert.Contains("2000", c.Values);
            Assert.Contains("Godišnja", c.Values);
        }
    }

    /// <summary>
    /// Testovi za domensku klasu Knjiga.
    /// </summary>
    public class KnjigaTests
    {
        [Fact]
        public void Dostupna_VracaTrueAkoImaSlobodnih()
        {
            var k = new Knjiga { BrojPrimeraka = 3, BrojSlobodnih = 1 };
            Assert.True(k.Dostupna);
        }

        [Fact]
        public void Dostupna_VracaFalseAkoNemaSlobodnih()
        {
            var k = new Knjiga { BrojPrimeraka = 2, BrojSlobodnih = 0 };
            Assert.False(k.Dostupna);
        }

        [Fact]
        public void BrojPrimeraka_PodrazumevanoJedan()
        {
            var k = new Knjiga();
            Assert.Equal(1, k.BrojPrimeraka);
        }

        [Fact]
        public void TableName_VracaIspravnoIme()
        {
            var k = new Knjiga();
            Assert.Equal("Knjiga", k.TableName);
        }

        [Fact]
        public void PrimaryKey_VracaIspravniKljuc()
        {
            var k = new Knjiga();
            Assert.Equal("idKnjiga", k.PrimaryKey);
        }

        [Fact]
        public void Values_SadrziIspravneVrednosti()
        {
            var k = new Knjiga { Naziv = "Zločin i kazna", ImePisca = "Fjodor", PrezimePisca = "Dostojevski", BrojPrimeraka = 2 };
            Assert.Contains("Zločin i kazna", k.Values);
            Assert.Contains("Fjodor", k.Values);
            Assert.Contains("Dostojevski", k.Values);
        }
    }

    /// <summary>
    /// Testovi za domensku klasu Pozajmica.
    /// </summary>
    public class PozajmicaTests
    {
        [Fact]
        public void ToString_VracaIspravniFormat()
        {
            var p = new Pozajmica { Id = 5, DatumOd = new DateTime(2026, 3, 1) };
            Assert.Equal("Pozajmica #5 - 01.03.2026", p.ToString());
        }

        [Fact]
        public void Stavke_PodrazumevannoPraznaLista()
        {
            var p = new Pozajmica();
            Assert.NotNull(p.Stavke);
            Assert.Empty(p.Stavke);
        }

        [Fact]
        public void TableName_VracaIspravnoIme()
        {
            var p = new Pozajmica();
            Assert.Equal("Pozajmica", p.TableName);
        }

        [Fact]
        public void PrimaryKey_VracaIspravniKljuc()
        {
            var p = new Pozajmica();
            Assert.Equal("idPozajmica", p.PrimaryKey);
        }

        [Fact]
        public void Values_SadrziIspravneVrednosti()
        {
            var p = new Pozajmica { DatumOd = new DateTime(2026, 3, 1), IdBibliotekar = 1, IdClan = 2 };
            Assert.Contains("2026-03-01", p.Values);
            Assert.Contains("1", p.Values);
            Assert.Contains("2", p.Values);
        }
    }

    /// <summary>
    /// Testovi za domensku klasu StavkaPozajmice.
    /// </summary>
    public class StavkaPozajmiceTests
    {
        [Fact]
        public void JeVracena_VracaTrueAkoImaDatumVracanja()
        {
            var s = new StavkaPozajmice { DatumVracanja = DateTime.Today };
            Assert.True(s.JeVracena);
        }

        [Fact]
        public void JeVracena_VracaFalseAkoNemaDatumVracanja()
        {
            var s = new StavkaPozajmice { DatumVracanja = null };
            Assert.False(s.JeVracena);
        }

        [Fact]
        public void JeZakasnela_VracaTrueAkoRokIstekaoINijeVracena()
        {
            var s = new StavkaPozajmice { DatumVracanja = null, RokPozajmice = DateTime.Now.AddDays(-5) };
            Assert.True(s.JeZakasnela);
        }

        [Fact]
        public void JeZakasnela_VracaFalseAkoJeVracena()
        {
            var s = new StavkaPozajmice { DatumVracanja = DateTime.Today, RokPozajmice = DateTime.Now.AddDays(-5) };
            Assert.False(s.JeZakasnela);
        }

        [Fact]
        public void JeZakasnela_VracaFalseAkoRokNijeIstekao()
        {
            var s = new StavkaPozajmice { DatumVracanja = null, RokPozajmice = DateTime.Now.AddDays(5) };
            Assert.False(s.JeZakasnela);
        }

        [Fact]
        public void ToString_VracaAktivnaStatus()
        {
            var s = new StavkaPozajmice { IdKnjige = 3, DatumVracanja = null, RokPozajmice = DateTime.Now.AddDays(5) };
            Assert.Contains("Aktivna", s.ToString());
        }

        [Fact]
        public void ToString_VracaVracenaStatus()
        {
            var s = new StavkaPozajmice { IdKnjige = 3, DatumVracanja = DateTime.Today };
            Assert.Contains("Vraćena", s.ToString());
        }

        [Fact]
        public void ToString_VracaZakasnela()
        {
            var s = new StavkaPozajmice { IdKnjige = 3, DatumVracanja = null, RokPozajmice = DateTime.Now.AddDays(-3) };
            Assert.Contains("Zakasnela", s.ToString());
        }

        [Fact]
        public void TableName_VracaIspravnoIme()
        {
            var s = new StavkaPozajmice();
            Assert.Equal("StavkaPozajmice", s.TableName);
        }

        [Fact]
        public void Join_SadrziKnjigaTabelu()
        {
            var s = new StavkaPozajmice();
            Assert.Contains("Knjiga", s.Join);
        }
    }
}