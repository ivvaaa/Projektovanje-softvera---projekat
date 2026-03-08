using Microsoft.Data.SqlClient;

namespace Domeni
{
    /// <summary>
    /// Predstavlja tip/vrstu članarine u biblioteci (npr. "Godišnja", "Mesečna").
    /// Implementira <see cref="IEntity"/> za pristup tabeli <c>Clanstvo</c> u bazi podataka.
    /// </summary>
    public class Clanstvo : IEntity
    {
        /// <summary>Jedinstveni identifikator tipa članarine.</summary>
        public long Id { get; set; }

        /// <summary>Cena članarine u dinarima (RSD).</summary>
        public long Cena { get; set; }

        /// <summary>Naziv vrste članarine (npr. "Godišnja", "Mesečna").</summary>
        public string Vrsta { get; set; }

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
