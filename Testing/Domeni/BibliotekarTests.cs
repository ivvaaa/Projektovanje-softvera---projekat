using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;
using Xunit;

namespace Testing.Domeni
{
    public class BibliotekarTests
    {
        // --- Osnovno kreiranje ---

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

        [Fact]
        public void Ulogovan_PodrazumevanoFalse()
        {
            var b = new Bibliotekar();
            Assert.False(b.Ulogovan);
        }

        // --- Validacija ---

        [Fact]
        public void Ime_PraznaVrednost_BacaArgumentException()
        {
            var b = new Bibliotekar();
            Assert.Throws<ArgumentException>(() => b.Ime = "");
        }

        [Fact]
        public void Ime_WhitespaceVrednost_BacaArgumentException()
        {
            var b = new Bibliotekar();
            Assert.Throws<ArgumentException>(() => b.Ime = "   ");
        }

        [Fact]
        public void Prezime_PraznaVrednost_BacaArgumentException()
        {
            var b = new Bibliotekar();
            Assert.Throws<ArgumentException>(() => b.Prezime = "");
        }

        [Fact]
        public void Username_PraznaVrednost_BacaArgumentException()
        {
            var b = new Bibliotekar();
            Assert.Throws<ArgumentException>(() => b.Username = "");
        }

        [Fact]
        public void Password_PraznaVrednost_BacaArgumentException()
        {
            var b = new Bibliotekar();
            Assert.Throws<ArgumentException>(() => b.Password = "");
        }

        [Fact]
        public void Id_NulaVrednost_BacaArgumentException()
        {
            var b = new Bibliotekar();
            Assert.Throws<ArgumentException>(() => b.Id = 0);
        }

        [Fact]
        public void Id_NegativnaVrednost_BacaArgumentException()
        {
            var b = new Bibliotekar();
            Assert.Throws<ArgumentException>(() => b.Id = -1);
        }

        [Fact]
        public void Id_PozitivnaVrednost_PostavljaIspravno()
        {
            var b = new Bibliotekar();
            b.Id = 5;
            Assert.Equal(5, b.Id);
        }
    }
}
