using Domeni;
using Xunit;

namespace Testing.Domeni
{
    public class ClanstvoTests
    {
        // --- Osnovno kreiranje ---

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

        // --- Validacija ---

        [Fact]
        public void Vrsta_PraznaVrednost_BacaArgumentException()
        {
            var c = new Clanstvo();
            Assert.Throws<ArgumentException>(() => c.Vrsta = "");
        }

        [Fact]
        public void Vrsta_WhitespaceVrednost_BacaArgumentException()
        {
            var c = new Clanstvo();
            Assert.Throws<ArgumentException>(() => c.Vrsta = "   ");
        }

        [Fact]
        public void Cena_NulaVrednost_BacaArgumentException()
        {
            var c = new Clanstvo();
            Assert.Throws<ArgumentException>(() => c.Cena = 0);
        }

        [Fact]
        public void Cena_NegativnaVrednost_BacaArgumentException()
        {
            var c = new Clanstvo();
            Assert.Throws<ArgumentException>(() => c.Cena = -500);
        }

        [Fact]
        public void Id_NulaVrednost_BacaArgumentException()
        {
            var c = new Clanstvo();
            Assert.Throws<ArgumentException>(() => c.Id = 0);
        }

        [Fact]
        public void Cena_ValidnaVrednost_PostavljaIspravno()
        {
            var c = new Clanstvo();
            c.Cena = 1500;
            Assert.Equal(1500, c.Cena);
        }
    }
}
