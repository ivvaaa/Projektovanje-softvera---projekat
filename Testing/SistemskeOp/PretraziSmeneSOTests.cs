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
    public class PretraziSmeneSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var so = new PretraziSmeneSO("Iva");
            Assert.NotNull(so);
        }

        [Fact]
        public void Result_PreIzvrsavanja_JeNull()
        {
            var so = new PretraziSmeneSO("Iva");
            Assert.Null(so.Result);
        }

        [Fact]
        public void ExecuteTemplate_SaPraznimKriterijumom_VracaRezultate()
        {
            var so = new PretraziSmeneSO("");
            so.ExecuteTemplate();
            Assert.NotNull(so.Result);
        }

        [Fact]
        public void ExecuteTemplate_SaNepostojecimImenom_VracaPraznaLista()
        {
            var so = new PretraziSmeneSO("NikoNePosojiBibliotXYZ999");
            so.ExecuteTemplate();
            Assert.NotNull(so.Result);
            Assert.Empty(so.Result);
        }
    }
}
