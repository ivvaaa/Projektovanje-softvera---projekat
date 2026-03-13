using Microsoft.Data.SqlClient;

namespace Domeni
{
    /// <summary>
    /// Predstavlja člana biblioteke koji može pozajmljivati knjige.
    /// Implementira <see cref="IEntity"/> za pristup tabeli <c>Clan</c> u bazi podataka.
    /// </summary>
    public class Clan : IEntity
    {
        private long _id;
        private string _ime;
        private string _prezime;
        private long _telefon;
        private DateTime _datumOd;
        private DateTime _datumDo;
        private long _idClanstva;

        /// <summary>
        /// Jedinstveni identifikator člana u bazi podataka.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost manja od ili jednaka nuli.</exception>
        public long Id
        {
            get => _id;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Id mora biti pozitivan broj.");
                _id = value;
            }
        }

        /// <summary>
        /// Ime člana.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost null ili prazna.</exception>
        public string Ime
        {
            get => _ime;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ime ne sme biti prazno.");
                _ime = value;
            }
        }

        /// <summary>
        /// Prezime člana.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost null ili prazna.</exception>
        public string Prezime
        {
            get => _prezime;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Prezime ne sme biti prazno.");
                _prezime = value;
            }
        }

        /// <summary>
        /// Kontakt telefon člana.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost manja od ili jednaka nuli.</exception>
        public long Telefon
        {
            get => _telefon;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Telefon mora biti pozitivan broj.");
                _telefon = value;
            }
        }

        /// <summary>
        /// Datum od kada važi aktivno članstvo.
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
        /// Datum do kada važi aktivno članstvo.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost default ili pre datuma <see cref="DatumOd"/>.</exception>
        public DateTime DatumDo
        {
            get => _datumDo;
            set
            {
                if (value == default)
                    throw new ArgumentException("DatumDo mora biti postavljen.");
                if (_datumOd != default && value <= _datumOd)
                    throw new ArgumentException("DatumDo mora biti posle DatumOd.");
                _datumDo = value;
            }
        }

        /// <summary>
        /// Identifikator tipa članarine koji član ima (strani ključ ka tabeli <c>Clanstvo</c>).
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost manja od ili jednaka nuli.</exception>
        public long IdClanstva
        {
            get => _idClanstva;
            set
            {
                if (value < 0)
                    throw new ArgumentException("IdClanstva mora biti pozitivan broj.");
                _idClanstva = value;
            }
        }

        /// <summary>Vraća puno ime u obliku "Ime Prezime".</summary>
        public string ImePrezime => $"{Ime} {Prezime}";

        /// <summary>
        /// Vraća <c>true</c> ako je datum isteka članarine u budućnosti ili danas.
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
