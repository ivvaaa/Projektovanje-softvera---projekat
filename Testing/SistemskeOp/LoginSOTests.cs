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
    public class LoginSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var b = new Bibliotekar { Username = "iva", Password = "iva123" };
            var so = new LoginSO(b);
            Assert.NotNull(so);
        }

        [Fact]
        public void Result_PreIzvrsavanja_JeNull()
        {
            var b = new Bibliotekar { Username = "iva", Password = "123" };
            var so = new LoginSO(b);
            Assert.Null(so.Result);
        }

        [Fact]
        public void ExecuteTemplate_NeispravniKredencijali_BacaIzuzetak()
        {
            var b = new Bibliotekar { Username = "nepostoji", Password = "pogresna" };
            var so = new LoginSO(b);
            Assert.Throws<Exception>(() => so.ExecuteTemplate());
        }

        [Fact]
        public void ExecuteTemplate_IspravniKredencijali_ResultNijeNull()
        {
            var b = new Bibliotekar { Username = "iva", Password = "iva123" };
            var so = new LoginSO(b);
            so.ExecuteTemplate();
            Assert.NotNull(so.Result);
        }
    }
}

