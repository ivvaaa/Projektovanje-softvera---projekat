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
    public class PretraziClanovaSOTests
    {
        [Fact]
        public void Konstruktor_SaKriterijumom_PostavljaObjekat()
        {
            var so = new PretraziClanoveSO("Marko");
            Assert.NotNull(so);
        }

        [Fact]
        public void Result_PreIzvrsavanja_JeNull()
        {
            var so = new PretraziClanoveSO("test");
            Assert.Null(so.Result);
        }

        [Fact]
        public void ExecuteTemplate_VracaRezultate()
        {
            var so = new PretraziClanoveSO("");
            so.ExecuteTemplate();
            Assert.NotNull(so.Result);
        }

        [Fact]
        public void ExecuteTemplate_SaNepostojecimImenom_VracaPraznaLista()
        {
            var so = new PretraziClanoveSO("NikoXYZ999");
            so.ExecuteTemplate();
            Assert.NotNull(so.Result);
            Assert.Empty(so.Result);
        }
    }
}
