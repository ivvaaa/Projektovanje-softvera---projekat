using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;
using Xunit;

namespace Testing.Domeni
{
    public class TerminSmeneTests
    {
        // --- Osnovno kreiranje ---

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

        [Fact]
        public void InsertColumns_SadrziTermin()
        {
            var t = new TerminSmene();
            Assert.Contains("termin", t.InsertColumns);
        }

        // --- Validacija ---

        [Fact]
        public void Termin_PraznaVrednost_BacaArgumentException()
        {
            var t = new TerminSmene();
            Assert.Throws<ArgumentException>(() => t.Termin = "");
        }

        [Fact]
        public void Termin_WhitespaceVrednost_BacaArgumentException()
        {
            var t = new TerminSmene();
            Assert.Throws<ArgumentException>(() => t.Termin = "   ");
        }

        [Fact]
        public void Id_NulaVrednost_BacaArgumentException()
        {
            var t = new TerminSmene();
            Assert.Throws<ArgumentException>(() => t.Id = 0);
        }

        [Fact]
        public void Id_NegativnaVrednost_BacaArgumentException()
        {
            var t = new TerminSmene();
            Assert.Throws<ArgumentException>(() => t.Id = -3);
        }

        [Fact]
        public void Termin_ValidnaVrednost_PostavljaIspravno()
        {
            var t = new TerminSmene();
            t.Termin = "16-20";
            Assert.Equal("16-20", t.Termin);
        }
    }
}

