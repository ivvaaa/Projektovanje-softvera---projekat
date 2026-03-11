using Domeni;
using Xunit;

namespace Testing.Domeni
{
    public class ClanTests
    {
        // --- Osnovno kreiranje ---

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

        // --- Validacija ---

        [Fact]
        public void Ime_PraznaVrednost_BacaArgumentException()
        {
            var c = new Clan();
            Assert.Throws<ArgumentException>(() => c.Ime = "");
        }

        [Fact]
        public void Prezime_PraznaVrednost_BacaArgumentException()
        {
            var c = new Clan();
            Assert.Throws<ArgumentException>(() => c.Prezime = "");
        }

        [Fact]
        public void Telefon_NulaVrednost_BacaArgumentException()
        {
            var c = new Clan();
            Assert.Throws<ArgumentException>(() => c.Telefon = 0);
        }

        [Fact]
        public void Telefon_NegativnaVrednost_BacaArgumentException()
        {
            var c = new Clan();
            Assert.Throws<ArgumentException>(() => c.Telefon = -1);
        }

        [Fact]
        public void Id_NulaVrednost_BacaArgumentException()
        {
            var c = new Clan();
            Assert.Throws<ArgumentException>(() => c.Id = 0);
        }

        [Fact]
        public void DatumOd_DefaultVrednost_BacaArgumentException()
        {
            var c = new Clan();
            Assert.Throws<ArgumentException>(() => c.DatumOd = default);
        }

        [Fact]
        public void DatumDo_DefaultVrednost_BacaArgumentException()
        {
            var c = new Clan();
            Assert.Throws<ArgumentException>(() => c.DatumDo = default);
        }

        [Fact]
        public void DatumDo_PreDatumOd_BacaArgumentException()
        {
            var c = new Clan { DatumOd = new DateTime(2025, 1, 1) };
            Assert.Throws<ArgumentException>(() => c.DatumDo = new DateTime(2024, 1, 1));
        }

        [Fact]
        public void IdClanstva_NulaVrednost_BacaArgumentException()
        {
            var c = new Clan();
            Assert.Throws<ArgumentException>(() => c.IdClanstva = 0);
        }
    }
}
