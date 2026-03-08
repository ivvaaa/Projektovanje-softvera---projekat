using Microsoft.Data.SqlClient;

namespace Domeni
{
    /// <summary>
    /// Predstavlja bibliotekara — zaposlenog koji upravlja pozajmicama, knjigama i smenama.
    /// Implementira <see cref="IEntity"/> za pristup tabeli <c>Bibliotekar</c> u bazi podataka.
    /// </summary>
    public class Bibliotekar : IEntity
    {
        /// <summary>Jedinstveni identifikator bibliotekara u bazi podataka.</summary>
        public long Id { get; set; }

        /// <summary>Ime bibliotekara.</summary>
        public string Ime { get; set; }

        /// <summary>Prezime bibliotekara.</summary>
        public string Prezime { get; set; }

        /// <summary>Korisničko ime za prijavljivanje u sistem.</summary>
        public string Username { get; set; }

        /// <summary>Lozinka za prijavljivanje u sistem.</summary>
        public string Password { get; set; }

        /// <summary>
        /// Označava da li je bibliotekar trenutno prijavljen u sistem.
        /// Podrazumevano <c>false</c>.
        /// </summary>
        public bool Ulogovan { get; set; } = false;

        /// <summary>Vraća puno ime u obliku "Ime Prezime".</summary>
        public string ImePrezime => $"{Ime} {Prezime}";

        /// <inheritdoc/>
        public string TableName => "Bibliotekar";

        /// <inheritdoc/>
        public string InsertColumns => "ime, prezime, username, password";

        /// <inheritdoc/>
        public string Values => $"'{Ime}', '{Prezime}', '{Username}', '{Password}'";

        /// <inheritdoc/>
        public string PrimaryKey => "idBibliotekar";

        /// <inheritdoc/>
        public string Join => "";

        /// <inheritdoc/>
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new Bibliotekar
                {
                    Id = (long)reader["idBibliotekar"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    Username = (string)reader["username"],
                    Password = (string)reader["password"]
                });
            }
            return lista;
        }

        /// <summary>
        /// Vraća tekstualni prikaz bibliotekara u obliku "Ime Prezime (username)".
        /// </summary>
        public override string ToString() => $"{Ime} {Prezime} ({Username})";
    }
}
