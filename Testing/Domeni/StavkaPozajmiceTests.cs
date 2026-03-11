using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;
using Xunit;

namespace Testing.Domeni
{
    public class StavkaPozajmiceTests
    {
        // --- Osnovno kreiranje ---

        [Fact]
        public void JeVracena_VracaTrueAkoImaDatumVracanja()
        {
            var s = new StavkaPozajmice { RokPozajmice = DateTime.Today, DatumVracanja = DateTime.Today };
            Assert.True(s.JeVracena);
        }

        [Fact]
        public void JeVracena_VracaFalseAkoNemaDatumVracanja()
        {
            var s = new StavkaPozajmice { RokPozajmice = DateTime.Today.AddDays(5), DatumVracanja = null };
            Assert.False(s.JeVracena);
        }

        [Fact]
        public void JeZakasnela_VracaTrueAkoRokIstekaoINijeVracena()
        {
            var s = new StavkaPozajmice { RokPozajmice = DateTime.Now.AddDays(-5), DatumVracanja = null };
            Assert.True(s.JeZakasnela);
        }

        [Fact]
        public void JeZakasnela_VracaFalseAkoJeVracena()
        {
            var s = new StavkaPozajmice { RokPozajmice = DateTime.Now.AddDays(-5), DatumVracanja = DateTime.Today };
            Assert.False(s.JeZakasnela);
        }

        [Fact]
        public void JeZakasnela_VracaFalseAkoRokNijeIstekao()
        {
            var s = new StavkaPozajmice { RokPozajmice = DateTime.Now.AddDays(5), DatumVracanja = null };
            Assert.False(s.JeZakasnela);
        }

        [Fact]
        public void ToString_VracaAktivnaStatus()
        {
            var s = new StavkaPozajmice { IdKnjige = 3, RokPozajmice = DateTime.Now.AddDays(5), DatumVracanja = null };
            Assert.Contains("Aktivna", s.ToString());
        }

        [Fact]
        public void ToString_VracaVracenaStatus()
        {
            var s = new StavkaPozajmice { IdKnjige = 3, RokPozajmice = DateTime.Today, DatumVracanja = DateTime.Today };
            Assert.Contains("Vraćena", s.ToString());
        }

        [Fact]
        public void ToString_VracaZakasnela()
        {
            var s = new StavkaPozajmice { IdKnjige = 3, RokPozajmice = DateTime.Now.AddDays(-3), DatumVracanja = null };
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

        // --- Validacija ---

        [Fact]
        public void Id_NulaVrednost_BacaArgumentException()
        {
            var s = new StavkaPozajmice();
            Assert.Throws<ArgumentException>(() => s.Id = 0);
        }

        [Fact]
        public void IdPozajmica_NulaVrednost_BacaArgumentException()
        {
            var s = new StavkaPozajmice();
            Assert.Throws<ArgumentException>(() => s.IdPozajmica = 0);
        }

        [Fact]
        public void IdKnjige_NulaVrednost_BacaArgumentException()
        {
            var s = new StavkaPozajmice();
            Assert.Throws<ArgumentException>(() => s.IdKnjige = 0);
        }

        [Fact]
        public void IdKnjige_NegativnaVrednost_BacaArgumentException()
        {
            var s = new StavkaPozajmice();
            Assert.Throws<ArgumentException>(() => s.IdKnjige = -5);
        }

        [Fact]
        public void RokPozajmice_DefaultVrednost_BacaArgumentException()
        {
            var s = new StavkaPozajmice();
            Assert.Throws<ArgumentException>(() => s.RokPozajmice = default);
        }
    }
}

