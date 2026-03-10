using Microsoft.Data.SqlClient;

namespace Domeni
{
    /// <summary>
    /// Predstavlja jednu stavku pozajmice — konkretnu knjigu koja je pozajmljena u okviru
    /// jedne <see cref="Pozajmica"/>. Sadrži informacije o roku, statusu vraćanja i kašnjenju.
    /// Implementira <see cref="IEntity"/> za pristup tabeli <c>StavkaPozajmice</c>.
    /// Primarni ključ je složen: <c>idPozajmica + rbStavkaPozajmice</c>.
    /// </summary>
    public class StavkaPozajmice : IEntity
    {
        private long _id;
        private long _idPozajmica;
        private DateTime _rokPozajmice;
        private long _idKnjige;

        /// <summary>
        /// Redni broj stavke unutar pozajmice (<c>rbStavkaPozajmice</c>).
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost manja od ili jednaka nuli.</exception>
        public long Id
        {
            get => _id;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Id mora biti pozitivan broj.");
                _id = value;
            }
        }

        /// <summary>
        /// Identifikator pozajmice kojoj ova stavka pripada.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost manja od ili jednaka nuli.</exception>
        public long IdPozajmica
        {
            get => _idPozajmica;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("IdPozajmica mora biti pozitivan broj.");
                _idPozajmica = value;
            }
        }

        /// <summary>
        /// Datum do kojeg knjiga mora biti vraćena. Mora biti u budućnosti pri kreiranju.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost default (nije postavljena).</exception>
        public DateTime RokPozajmice
        {
            get => _rokPozajmice;
            set
            {
                if (value == default)
                    throw new ArgumentException("RokPozajmice mora biti postavljen.");
                _rokPozajmice = value;
            }
        }

        /// <summary>
        /// Identifikator knjige koja je pozajmljena.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost manja od ili jednaka nuli.</exception>
        public long IdKnjige
        {
            get => _idKnjige;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("IdKnjige mora biti pozitivan broj.");
                _idKnjige = value;
            }
        }

        /// <summary>
        /// Datum kada je knjiga vraćena, ili <c>null</c> ako još nije vraćena.
        /// </summary>
        public DateTime? DatumVracanja { get; set; }

        /// <summary>
        /// Naziv knjige.
        /// Nije kolona u bazi — popunjava se JOIN-om u sistemskim operacijama.
        /// </summary>
        public string NazivKnjige { get; set; }

        /// <summary>
        /// Vraća <c>true</c> ako je knjiga vraćena (datum vraćanja je postavljen).
        /// </summary>
        public bool JeVracena => DatumVracanja.HasValue;

        /// <summary>
        /// Vraća <c>true</c> ako knjiga nije vraćena a rok je istekao.
        /// </summary>
        public bool JeZakasnela => !JeVracena && RokPozajmice < DateTime.Now;

        /// <inheritdoc/>
        public string TableName => "StavkaPozajmice";

        /// <inheritdoc/>
        public string InsertColumns => "idPozajmica, rokPozajmice, idKnjiga";

        /// <inheritdoc/>
        public string Values => $"{IdPozajmica}, '{RokPozajmice:yyyy-MM-dd}', {IdKnjige}";

        /// <inheritdoc/>
        public string PrimaryKey => "idPozajmica, rbStavkaPozajmice";

        /// <inheritdoc/>
        public string Join => "INNER JOIN Knjiga k ON StavkaPozajmice.idKnjiga = k.idKnjiga";

        /// <inheritdoc/>
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new StavkaPozajmice
                {
                    Id = (long)reader["rbStavkaPozajmice"],
                    IdPozajmica = (long)reader["idPozajmica"],
                    RokPozajmice = (DateTime)reader["rokPozajmice"],
                    IdKnjige = (long)reader["idKnjiga"],
                    DatumVracanja = reader["datumVracanja"] == DBNull.Value
                                        ? null
                                        : (DateTime)reader["datumVracanja"],
                    NazivKnjige = reader["naziv"] != DBNull.Value ? (string)reader["naziv"] : ""
                });
            }
            return lista;
        }

        /// <summary>
        /// Vraća tekstualni prikaz stavke sa statusom: "Vraćena", "Zakasnela" ili "Aktivna".
        /// </summary>
        public override string ToString()
        {
            string status = JeVracena ? "Vraćena" : (JeZakasnela ? "Zakasnela" : "Aktivna");
            return $"Stavka: Knjiga ID {IdKnjige} - {status}";
        }
    }
}
