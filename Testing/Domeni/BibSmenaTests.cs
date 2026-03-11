using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;
using global::Domeni;
using Xunit;

namespace Testing.Domeni
{

        public class BibSmenaTests
        {
            // --- Osnovno kreiranje ---

            [Fact]
            public void ToString_VracaIspravniFormat()
            {
                var s = new BibSmena { IdBibliotekara = 1, IdTerminSmene = 16, Datum = new DateTime(2026, 3, 10) };
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

            // --- Validacija ---

            [Fact]
            public void IdBibliotekara_NulaVrednost_BacaArgumentException()
            {
                var s = new BibSmena();
                Assert.Throws<ArgumentException>(() => s.IdBibliotekara = 0);
            }

            [Fact]
            public void IdBibliotekara_NegativnaVrednost_BacaArgumentException()
            {
                var s = new BibSmena();
                Assert.Throws<ArgumentException>(() => s.IdBibliotekara = -1);
            }

            [Fact]
            public void IdTerminSmene_NulaVrednost_BacaArgumentException()
            {
                var s = new BibSmena();
                Assert.Throws<ArgumentException>(() => s.IdTerminSmene = 0);
            }

            [Fact]
            public void Datum_DefaultVrednost_BacaArgumentException()
            {
                var s = new BibSmena();
                Assert.Throws<ArgumentException>(() => s.Datum = default);
            }

            [Fact]
            public void Datum_ValidnaVrednost_PostavljaIspravno()
            {
                var s = new BibSmena();
                var datum = new DateTime(2026, 5, 1);
                s.Datum = datum;
                Assert.Equal(datum, s.Datum);
            }
        }
    }

