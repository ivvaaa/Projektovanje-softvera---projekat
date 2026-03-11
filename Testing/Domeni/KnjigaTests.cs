using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;
using Xunit;

namespace Testing.Domeni
{
    public class KnjigaTests
    {
        // --- Osnovno kreiranje ---

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

        // --- Validacija ---

        [Fact]
        public void Naziv_PraznaVrednost_BacaArgumentException()
        {
            var k = new Knjiga();
            Assert.Throws<ArgumentException>(() => k.Naziv = "");
        }

        [Fact]
        public void Naziv_WhitespaceVrednost_BacaArgumentException()
        {
            var k = new Knjiga();
            Assert.Throws<ArgumentException>(() => k.Naziv = "   ");
        }

        [Fact]
        public void ImePisca_PraznaVrednost_BacaArgumentException()
        {
            var k = new Knjiga();
            Assert.Throws<ArgumentException>(() => k.ImePisca = "");
        }

        [Fact]
        public void PrezimePisca_PraznaVrednost_BacaArgumentException()
        {
            var k = new Knjiga();
            Assert.Throws<ArgumentException>(() => k.PrezimePisca = "");
        }

        [Fact]
        public void BrojPrimeraka_NulaVrednost_BacaArgumentException()
        {
            var k = new Knjiga();
            Assert.Throws<ArgumentException>(() => k.BrojPrimeraka = 0);
        }

        [Fact]
        public void BrojPrimeraka_NegativnaVrednost_BacaArgumentException()
        {
            var k = new Knjiga();
            Assert.Throws<ArgumentException>(() => k.BrojPrimeraka = -1);
        }

        [Fact]
        public void Id_NulaVrednost_BacaArgumentException()
        {
            var k = new Knjiga();
            Assert.Throws<ArgumentException>(() => k.Id = 0);
        }

        [Fact]
        public void BrojPrimeraka_ValidnaVrednost_PostavljaIspravno()
        {
            var k = new Knjiga();
            k.BrojPrimeraka = 5;
            Assert.Equal(5, k.BrojPrimeraka);
        }
    }
}

