using Microsoft.Data.SqlClient;

namespace Domeni
{
    /// <summary>
    /// Predstavlja tip/vrstu članarine u biblioteci (npr. "Godišnja", "Mesečna").
    /// Implementira <see cref="IEntity"/> za pristup tabeli <c>Clanstvo</c> u bazi podataka.
    /// </summary>
    public class Clanstvo : IEntity
    {
        private long _id;
        private long _cena;
        private string _vrsta;

        /// <summary>
        /// Jedinstveni identifikator tipa članarine.
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
        /// Cena članarine u dinarima (RSD). Mora biti veća od nule.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost manja od ili jednaka nuli.</exception>
        public long Cena
        {
            get => _cena;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Cena mora biti pozitivan broj.");
                _cena = value;
            }
        }

        /// <summary>
        /// Naziv vrste članarine (npr. "Godišnja", "Mesečna").
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost null ili prazna.</exception>
        public string Vrsta
        {
            get => _vrsta;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Vrsta ne sme biti prazna.");
                _vrsta = value;
            }
        }

        /// <inheritdoc/>
        public string TableName => "Clanstvo";

        /// <inheritdoc/>
        public string InsertColumns => "cena, vrsta";

        /// <inheritdoc/>
        public string Values => $"{Cena}, '{Vrsta}'";

        /// <inheritdoc/>
        public string PrimaryKey => "idClanstvo";

        /// <inheritdoc/>
        public string Join => "";

        /// <inheritdoc/>
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new Clanstvo
                {
                    Id = (long)reader["idClanstvo"],
                    Cena = (long)reader["cena"],
                    Vrsta = (string)reader["vrsta"]
                });
            }
            return lista;
        }

        /// <summary>
        /// Vraća tekstualni prikaz članarine u obliku "Vrsta (cena RSD)".
        /// </summary>
        public override string ToString() => $"{Vrsta} ({Cena} RSD)";
    }
}
