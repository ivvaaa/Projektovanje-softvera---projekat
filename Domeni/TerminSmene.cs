using Microsoft.Data.SqlClient;

namespace Domeni
{
    /// <summary>
    /// Predstavlja termin smene u biblioteci (npr. "08-12", "12-16", "16-20").
    /// Implementira <see cref="IEntity"/> za pristup tabeli <c>TerminSmene</c> u bazi podataka.
    /// </summary>
    public class TerminSmene : IEntity
    {
        private long _id;
        private string _termin;

        /// <summary>
        /// Jedinstveni identifikator termina smene.
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
        /// Tekstualni opis termina smene, npr. <c>"08-12"</c>.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost null ili prazna.</exception>
        public string Termin
        {
            get => _termin;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Termin ne sme biti prazan.");
                _termin = value;
            }
        }

        /// <inheritdoc/>
        public string TableName => "TerminSmene";

        /// <inheritdoc/>
        public string InsertColumns => "termin";

        /// <inheritdoc/>
        public string Values => $"'{Termin}'";

        /// <inheritdoc/>
        public string PrimaryKey => "idTerminSmene";

        /// <inheritdoc/>
        public string Join => "";

        /// <inheritdoc/>
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new TerminSmene
                {
                    Id = (long)reader["idTerminSmene"],
                    Termin = (string)reader["termin"]
                });
            }
            return lista;
        }

        /// <summary>
        /// Vraća tekstualni prikaz termina smene (npr. <c>"08-12"</c>).
        /// Koristi se za prikaz u ComboBox kontrolama.
        /// </summary>
        public override string ToString() => Termin;
    }
}
