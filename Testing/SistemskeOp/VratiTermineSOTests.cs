using Domeni;
using SistemskeOp;
using Xunit;

namespace Testing.SistemskeOp
{
    public class VratiTermineSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var so = new VratiTermineSO();
            Assert.NotNull(so);
        }

        [Fact]
        public void Result_PreIzvrsavanja_JeNull()
        {
            var so = new VratiTermineSO();
            Assert.Null(so.Result);
        }

        [Fact]
        public void ExecuteTemplate_VracaTermine()
        {
            var so = new VratiTermineSO();
            so.ExecuteTemplate();
            Assert.NotNull(so.Result);
            Assert.NotEmpty(so.Result);
        }

        [Fact]
        public void ExecuteTemplate_VracaSvaTriTermina()
        {
            var so = new VratiTermineSO();
            so.ExecuteTemplate();
            Assert.Equal(3, so.Result.Count);
        }
    }
}
