using Domeni;
using SistemskeOp;
using Xunit;

namespace Testing.SistemskeOp
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

        [Fact]
        public void ExecuteTemplate_SK3a_PostavljaDatumVracanja()
        {
            // Uzmi neku aktivnu pozajmicu iz baze koja ima nevracenu stavku
            var pretragaPozajmica = new PretraziPozajmiceSO("");
            pretragaPozajmica.ExecuteTemplate();
            var aktivna = pretragaPozajmica.Result?
                .FirstOrDefault(p => p.Stavke.Any(s => !s.JeVracena));

            if (aktivna == null)
                return; // nema aktivnih pozajmica, preskoči

            var stavka = aktivna.Stavke.First(s => !s.JeVracena);

            new VratiKnjiguSO(aktivna.Id, stavka.IdKnjige).ExecuteTemplate();

            var provera = new PretraziPozajmiceSO("");
            provera.ExecuteTemplate();
            var izmenjena = provera.Result.First(p => p.Id == aktivna.Id);
            var izmenjenаStavka = izmenjena.Stavke.First(s => s.IdKnjige == stavka.IdKnjige);

            Assert.True(izmenjenаStavka.JeVracena);
        }

        [Fact]
        public void ExecuteTemplate_SK3b_MenjaRokPozajmice()
        {
            // Uzmi neku aktivnu pozajmicu iz baze
            var pretragaPozajmica = new PretraziPozajmiceSO("");
            pretragaPozajmica.ExecuteTemplate();
            var aktivna = pretragaPozajmica.Result?
                .FirstOrDefault(p => p.Stavke.Any(s => !s.JeVracena));

            if (aktivna == null)
                return; // nema aktivnih pozajmica, preskoči

            var noviRok = DateTime.Today.AddDays(30);
            new VratiKnjiguSO(aktivna.Id, noviRok).ExecuteTemplate();

            // Provjeri da je rok promijenjen
            var provera = new PretraziPozajmiceSO("");
            provera.ExecuteTemplate();
            var izmenjena = provera.Result.First(p => p.Id == aktivna.Id);

            Assert.All(
                izmenjena.Stavke.Where(s => !s.JeVracena),
                s => Assert.Equal(noviRok.Date, s.RokPozajmice.Date)
            );
        }
    }
}