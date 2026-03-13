using Microsoft.Data.SqlClient;

namespace Domeni
{
    /// <summary>
    /// Predstavlja pozajmicu — transakciju u kojoj bibliotekar izdaje knjige članu biblioteke.
    /// Sadrži listu stavki <see cref="StavkaPozajmice"/>, svaka od kojih odgovara jednoj knjizi.
    /// Implementira <see cref="IEntity"/> za pristup tabeli <c>Pozajmica</c> u bazi podataka.
    /// </summary>
    public class Pozajmica : IEntity
    {
        private long _id;
        private DateTime _datumOd;
        private long _idBibliotekar;
        private long _idClan;

        /// <summary>
        /// Jedinstveni identifikator pozajmice.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost manja od ili jednaka nuli.</exception>
        public long Id
        {
            get => _id;
            set
            {
                if (value <0)
                    throw new ArgumentException("Id mora biti pozitivan broj.");
                _id = value;
            }
        }

        /// <summary>
        /// Datum kreiranja pozajmice.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost default (nije postavljena).</exception>
        public DateTime DatumOd
        {
            get => _datumOd;
            set
            {
                if (value == default)
                    throw new ArgumentException("DatumOd mora biti postavljen.");
                _datumOd = value;
            }
        }

        /// <summary>
        /// Identifikator bibliotekara koji je kreirao pozajmicu.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost manja od ili jednaka nuli.</exception>
        public long IdBibliotekar
        {
            get => _idBibliotekar;
            set
            {
                if (value <0)
                    throw new ArgumentException("IdBibliotekar mora biti pozitivan broj.");
                _idBibliotekar = value;
            }
        }

        /// <summary>
        /// Identifikator člana koji je uzeo knjige.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost manja od ili jednaka nuli.</exception>
        public long IdClan
        {
            get => _idClan;
            set
            {
                if (value < 0)
                    throw new ArgumentException("IdClan mora biti pozitivan broj.");
                _idClan = value;
            }
        }

        /// <summary>
        /// Lista stavki pozajmice (knjige koje su pozajmljene).
        /// Popunjava se u <see cref="SistemskeOp.PretraziPozajmiceSO"/>.
        /// </summary>
        public List<StavkaPozajmice> Stavke { get; set; } = new List<StavkaPozajmice>();

        /// <summary>
        /// Puno ime člana ("Ime Prezime").
        /// Nije kolona u bazi — popunjava se u sistemskim operacijama.
        /// </summary>
        public string ImePrezimeClana { get; set; }

        /// <summary>
        /// Puno ime bibliotekara ("Ime Prezime").
        /// Nije kolona u bazi — popunjava se u sistemskim operacijama.
        /// </summary>
        public string ImePrezimeBibliotekar { get; set; }

        /// <summary>
        /// Broj knjiga u pozajmici (broj stavki).
        /// Izračunava se u sistemskim operacijama.
        /// </summary>
        public int BrojKnjiga { get; set; }

        /// <summary>
        /// Tekstualni status pozajmice: "Aktivna", "Zakasnelo" ili "Vraceno".
        /// Izračunava se u sistemskim operacijama na osnovu stavki.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Vraća datum kada su sve knjige vraćene, ili <c>null</c> ako pozajmica još nije zatvorena.
        /// Uzima maksimalni datum vraćanja od svih stavki.
        /// </summary>
        public DateTime? DatumVracanja =>
            Stavke != null && Stavke.Count > 0 && Stavke.All(s => s.DatumVracanja.HasValue)
                ? Stavke.Max(s => s.DatumVracanja)
                : null;

        /// <inheritdoc/>
        public string TableName => "Pozajmica";

        /// <inheritdoc/>
        public string InsertColumns => "datumOd, idBibliotekar, idClan";

        /// <inheritdoc/>
        public string Values => $"'{DatumOd:yyyy-MM-dd}', {IdBibliotekar}, {IdClan}";

        /// <inheritdoc/>
        public string PrimaryKey => "idPozajmica";

        /// <inheritdoc/>
        public string Join => "";

        /// <inheritdoc/>
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new Pozajmica
                {
                    Id = (long)reader["idPozajmica"],
                    DatumOd = (DateTime)reader["datumOd"],
                    IdBibliotekar = (long)reader["idBibliotekar"],
                    IdClan = (long)reader["idClan"]
                });
            }
            return lista;
        }

        /// <summary>
        /// Vraća tekstualni prikaz pozajmice u obliku "Pozajmica #ID - dd.MM.yyyy".
        /// </summary>
        public override string ToString() => $"Pozajmica #{Id} - {DatumOd:dd.MM.yyyy}";
    }
}
