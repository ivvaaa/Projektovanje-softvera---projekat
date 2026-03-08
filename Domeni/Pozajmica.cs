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
        /// <summary>Jedinstveni identifikator pozajmice.</summary>
        public long Id { get; set; }

        /// <summary>Datum kreiranja pozajmice.</summary>
        public DateTime DatumOd { get; set; }

        /// <summary>Identifikator bibliotekara koji je kreirao pozajmicu.</summary>
        public long IdBibliotekar { get; set; }

        /// <summary>Identifikator člana koji je uzeo knjige.</summary>
        public long IdClan { get; set; }

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
