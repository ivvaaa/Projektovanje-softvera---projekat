using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;
using SistemskeOp;
using Xunit;

namespace Testing.SistemskeOp
{
    public class PretraziKnjigeSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var so = new PretraziKnjigeSO("test");
            Assert.NotNull(so);
        }

        [Fact]
        public void Result_PreIzvrsavanja_JeNull()
        {
            var so = new PretraziKnjigeSO("test");
            Assert.Null(so.Result);
        }

        [Fact]
        public void ExecuteTemplate_SaPraznimKriterijumom_VracaSveKnjige()
        {
            var so = new PretraziKnjigeSO("");
            so.ExecuteTemplate();
            Assert.NotNull(so.Result);
        }

        [Fact]
        public void ExecuteTemplate_SaNepostojecimNazivom_VracaPraznaLista()
        {
            var so = new PretraziKnjigeSO("NazivKojiSigurnoNePostoji_XYZ123");
            so.ExecuteTemplate();
            Assert.NotNull(so.Result);
            Assert.Empty(so.Result);
        }
    }
}

