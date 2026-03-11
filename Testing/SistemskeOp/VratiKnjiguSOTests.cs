using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;
using SistemskeOp;
using Xunit;

namespace Testovi.SistemskeOp
{
    public class VratiKnjiguSOTests
    {
        [Fact]
        public void Konstruktor_SK3a_PostavljaObjekat()
        {
            var so = new VratiKnjiguSO(1L, 2L);
            Assert.NotNull(so);
        }

        [Fact]
        public void Konstruktor_SK3b_PostavljaObjekat()
        {
            var so = new VratiKnjiguSO(1L, DateTime.Today.AddDays(7));
            Assert.NotNull(so);
        }
    }
}

