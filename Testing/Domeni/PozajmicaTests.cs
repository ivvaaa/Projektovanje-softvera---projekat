using Domeni;
using Xunit;

namespace Testing.Domeni
{
    public class PozajmicaTests
    {
        // --- Osnovno kreiranje ---

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
        public void DatumVracanja_BezStavki_VracaNull()
        {
            var p = new Pozajmica();
            Assert.Null(p.DatumVracanja);
        }

        [Fact]
        public void DatumVracanja_SaNevraceномStavkom_VracaNull()
        {
            var p = new Pozajmica();
            p.Stavke.Add(new StavkaPozajmice { RokPozajmice = DateTime.Today.AddDays(5), DatumVracanja = null });
            Assert.Null(p.DatumVracanja);
        }

        [Fact]
        public void DatumVracanja_SvimStavkamVracenim_VracaDatum()
        {
            var p = new Pozajmica();
            p.Stavke.Add(new StavkaPozajmice { RokPozajmice = DateTime.Today, DatumVracanja = DateTime.Today });
            Assert.NotNull(p.DatumVracanja);
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

        // --- Validacija ---

        [Fact]
        public void Id_NulaVrednost_BacaArgumentException()
        {
            var p = new Pozajmica();
            Assert.Throws<ArgumentException>(() => p.Id = 0);
        }

        [Fact]
        public void Id_NegativnaVrednost_BacaArgumentException()
        {
            var p = new Pozajmica();
            Assert.Throws<ArgumentException>(() => p.Id = -1);
        }

        [Fact]
        public void DatumOd_DefaultVrednost_BacaArgumentException()
        {
            var p = new Pozajmica();
            Assert.Throws<ArgumentException>(() => p.DatumOd = default);
        }

        [Fact]
        public void IdBibliotekar_NulaVrednost_BacaArgumentException()
        {
            var p = new Pozajmica();
            Assert.Throws<ArgumentException>(() => p.IdBibliotekar = 0);
        }

        [Fact]
        public void IdClan_NulaVrednost_BacaArgumentException()
        {
            var p = new Pozajmica();
            Assert.Throws<ArgumentException>(() => p.IdClan = 0);
        }
    }
}
