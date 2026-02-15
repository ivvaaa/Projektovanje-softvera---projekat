using Microsoft.Data.SqlClient;

namespace Domeni
{
    public class Bibliotekar : IEntity
    {
        public long Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ImePrezime => $"{Ime} {Prezime}";
        public string TableName => "Bibliotekar";

        public string InsertColumns => "ime, prezime, username, password";

        public string Values => $"'{Ime}', '{Prezime}', '{Username}', '{Password}'";

        public string PrimaryKey => "idBibliotekar";

        public string Join => "";

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
        public override string ToString()
        {
            return $"{Ime} {Prezime} ({Username})";
        }
    }
}