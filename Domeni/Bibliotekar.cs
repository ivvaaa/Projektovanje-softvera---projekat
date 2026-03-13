using Microsoft.Data.SqlClient;
using System.Text.Json.Serialization;


namespace Domeni
{
    /// <summary>
    /// Predstavlja bibliotekara — zaposlenog koji upravlja pozajmicama, knjigama i smenama.
    /// Implementira <see cref="IEntity"/> za pristup tabeli <c>Bibliotekar</c> u bazi podataka.
    /// </summary>
    public class Bibliotekar : IEntity
    {
        private long _id;
        private string _ime;
        private string _prezime;
        private string _username;
        private string _password;

        /// <summary>
        /// Jedinstveni identifikator bibliotekara u bazi podataka.
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
        /// Ime bibliotekara.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost null ili prazna.</exception>
        public string Ime { get; set; }

        //public string Ime
        //{
        //    get => _ime;
        //    set
        //    {
        //        if (string.IsNullOrWhiteSpace(value))
        //            throw new ArgumentException("Ime ne sme biti prazno.");
        //        _ime = value;
        //    }
        //}

        /// <summary>
        /// Prezime bibliotekara.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost null ili prazna.</exception>
        public string Prezime { get; set; }
        //public string Prezime
        //{
        //    get => _prezime;
        //    set
        //    {
        //        if (string.IsNullOrWhiteSpace(value))
        //            throw new ArgumentException("Prezime ne sme biti prazno.");
        //        _prezime = value;
        //    }
        //}

        /// <summary>
        /// Korisničko ime za prijavljivanje u sistem.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost null ili prazna.</exception>
        public string Username
        {
            get => _username;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Username ne sme biti prazan.");
                _username = value;
            }
        }

        /// <summary>
        /// Lozinka za prijavljivanje u sistem.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost null ili prazna.</exception>
        public string Password
        {
            get => _password;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Password ne sme biti prazan.");
                _password = value;
            }
        }

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
                    Id = Convert.ToInt64(reader["idBibliotekar"]),
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
