using Microsoft.Data.SqlClient;

namespace Domeni
{
    /// <summary>
    /// Predstavlja člana biblioteke koji može pozajmljivati knjige.
    /// Implementira <see cref="IEntity"/> za pristup tabeli <c>Clan</c> u bazi podataka.
    /// </summary>
    public class Clan : IEntity
    {
        /// <summary>Jedinstveni identifikator člana u bazi podataka.</summary>
        public long Id { get; set; }

        /// <summary>Ime člana.</summary>
        public string Ime { get; set; }

        /// <summary>Prezime člana.</summary>
        public string Prezime { get; set; }

        /// <summary>Kontakt telefon člana.</summary>
        public long Telefon { get; set; }

        /// <summary>Datum od kada važi aktivno članstvo.</summary>
        public DateTime DatumOd { get; set; }

        /// <summary>Datum do kada važi aktivno članstvo.</summary>
        public DateTime DatumDo { get; set; }

        /// <summary>Identifikator tipa članarine koji član ima (strani ključ ka tabeli <c>Clanstvo</c>).</summary>
        public long IdClanstva { get; set; }

        /// <summary>Vraća puno ime u obliku "Ime Prezime".</summary>
        public string ImePrezime => $"{Ime} {Prezime}";

        /// <summary>
        /// Vraća <c>true</c> ako je datum isteka članarine u budućnosti ili danas,
        /// tj. ako je članova a clanarina još uvek aktivna.
        /// </summary>
        public bool ClanarinaAktivna => DatumDo >= DateTime.Now;

        /// <inheritdoc/>
        public string TableName => "Clan";

        /// <inheritdoc/>
        public string InsertColumns => "ime, prezime, telefon, datumOd, datumDo, idClanstvo";

        /// <inheritdoc/>
        public string Values => $"'{Ime}', '{Prezime}', {Telefon}, '{DatumOd:yyyy-MM-dd}', '{DatumDo:yyyy-MM-dd}', {IdClanstva}";

        /// <inheritdoc/>
        public string PrimaryKey => "idClan";

        /// <inheritdoc/>
        public string Join => "";

        /// <inheritdoc/>
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new Clan
                {
                    Id = (long)reader["idClan"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    Telefon = (long)reader["telefon"],
                    DatumOd = (DateTime)reader["datumOd"],
                    DatumDo = (DateTime)reader["datumDo"],
                    IdClanstva = (long)reader["idClanstvo"]
                });
            }
            return lista;
        }

        /// <summary>
        /// Vraća tekstualni prikaz člana u obliku "Ime Prezime (Tel: broj)".
        /// </summary>
        public override string ToString() => $"{Ime} {Prezime} (Tel: {Telefon})";
    }
}
