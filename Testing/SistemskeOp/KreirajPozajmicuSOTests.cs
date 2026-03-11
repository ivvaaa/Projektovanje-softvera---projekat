using Domeni;
using SistemskeOp;
using Xunit;

namespace Testing.SistemskeOp
{
    public class KreirajPozajmicuSOTests
    {
        [Fact]
        public void Konstruktor_PostavljaObjekat()
        {
            var p = new Pozajmica { IdBibliotekar = 1, IdClan = 1, DatumOd = DateTime.Today };
            var so = new KreirajPozajmicuSO(p);
            Assert.NotNull(so);
        }

        [Fact]
        public void Result_PreIzvrsavanja_JeNula()
        {
            var p = new Pozajmica { IdBibliotekar = 1, IdClan = 1, DatumOd = DateTime.Today };
            var so = new KreirajPozajmicuSO(p);
            Assert.Equal(0, so.Result);
        }

        [Fact]
        public void ExecuteTemplate_KreiraPositive_UBazuIVracaId()
        {
            // Uzmi prvu dostupnu knjigu iz baze
            var pretragaKnjiga = new PretraziKnjigeSO("");
            pretragaKnjiga.ExecuteTemplate();
            var knjiga = pretragaKnjiga.Result?.FirstOrDefault(k => k.Dostupna);

            if (knjiga == null)
                return; // nema dostupnih knjiga, preskoči

            var p = new Pozajmica
            {
                IdBibliotekar = 1,
                IdClan = 1,
                DatumOd = DateTime.Today
            };
            p.Stavke.Add(new StavkaPozajmice
            {
                IdKnjige = knjiga.Id,
                RokPozajmice = DateTime.Today.AddDays(14)
            });

            var so = new KreirajPozajmicuSO(p);
            so.ExecuteTemplate();

            // Provjeri da je ID pozajmice postavljen
            Assert.True(so.Result > 0);

            // Provjeri da pozajmica postoji u bazi
            var pretraga = new PretraziPozajmiceSO("");
            pretraga.ExecuteTemplate();
            Assert.Contains(pretraga.Result, x => x.Id == so.Result);
        }

        [Fact]
        public void ExecuteTemplate_BacaIzuzetakAkoKnjigaNijePostupna()
        {
            // Uzmi prvu nedostupnu knjigu
            var pretragaKnjiga = new PretraziKnjigeSO("");
            pretragaKnjiga.ExecuteTemplate();
            var knjiga = pretragaKnjiga.Result?.FirstOrDefault(k => !k.Dostupna);

            if (knjiga == null)
                return; // sve knjige su dostupne, preskoči

            var p = new Pozajmica
            {
                IdBibliotekar = 1,
                IdClan = 1,
                DatumOd = DateTime.Today
            };
            p.Stavke.Add(new StavkaPozajmice
            {
                IdKnjige = knjiga.Id,
                RokPozajmice = DateTime.Today.AddDays(14)
            });

            var so = new KreirajPozajmicuSO(p);
            Assert.Throws<Exception>(() => so.ExecuteTemplate());
        }

        [Fact]
        public void ExecuteTemplate_BacaIzuzetakAkoKnjigaNePostoji()
        {
            var p = new Pozajmica
            {
                IdBibliotekar = 1,
                IdClan = 1,
                DatumOd = DateTime.Today
            };
            p.Stavke.Add(new StavkaPozajmice
            {
                IdKnjige = 999999, // ID koji sigurno ne postoji
                RokPozajmice = DateTime.Today.AddDays(14)
            });

            var so = new KreirajPozajmicuSO(p);
            Assert.Throws<Exception>(() => so.ExecuteTemplate());
        }
    }
}