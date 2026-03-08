using Microsoft.Data.SqlClient;

namespace Domeni
{
    /// <summary>
    /// Predstavlja termin smene u biblioteci (npr. "08-12", "12-16", "16-20").
    /// Implementira <see cref="IEntity"/> za pristup tabeli <c>TerminSmene</c> u bazi podataka.
    /// </summary>
    public class TerminSmene : IEntity
    {
        /// <summary>Jedinstveni identifikator termina smene.</summary>
        public long Id { get; set; }

        /// <summary>Tekstualni opis termina smene, npr. <c>"08-12"</c>.</summary>
        public string Termin { get; set; }

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
