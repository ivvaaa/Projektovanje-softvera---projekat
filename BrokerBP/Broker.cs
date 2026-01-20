
using Microsoft.Data.SqlClient;
using Domeni;
using System.Reflection.Metadata;

namespace BrokerBP
{
    public class Broker
    {
        private SqlConnection connection;

        public void Connect()
        {
            try
            {
                connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Projekat-Softveri;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
                connection.Open();
                Console.WriteLine("Uspesno uspostavljena veza sa bazom podataka!");

            }
            catch (Exception){
                Console.WriteLine("Nije uspesno uspostavljena veza sa bazom podataka!");
                throw;
            }
        }
        public void Disconnect()
        {
            connection?.Close();
        }

        public Bibliotekar? GetBibliotekarByUserPass(Bibliotekar b)
        {
            try
            {
                string upit = $"select idBibliotekar, ime, prezime, username, password "+
                    "from Bibliotekar where username=@u and password=@p";
                using SqlCommand cmd = new SqlCommand(upit,connection);
                cmd.Parameters.AddWithValue("u",b.Username);
                cmd.Parameters.AddWithValue ("p",b.Password);
                
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    b.Id = reader.GetInt64(0);
                    b.Ime = reader.GetString(1);
                    b.Prezime = reader.GetString(2);
                    return b;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Greska pri radu sa bazom.");
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        //----------------------------- KNJIGA

        public void UbaciKnjigu (Knjiga knjiga)
        {
            try
            {
                string upit = "INSERT INTO Knjiga (naziv,imePisca,prezimePisca) VALUES (@naziv, @imePisca, @prezimePisca)";
                using SqlCommand cmd = new SqlCommand(upit, connection);
                cmd.Parameters.AddWithValue("@naziv", knjiga.Naziv);
                cmd.Parameters.AddWithValue("@imePisca", knjiga.ImePisca);
                cmd.Parameters.AddWithValue("@prezimePisca", knjiga.PrezimePisca);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Knjiga uspesno ubacena!");

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Greska pri ubacivanju knjige!" + ex.Message);
                throw;
            }

        }

        public List<Knjiga> VratiSveKnjige()
        {
            List<Knjiga> lista= new List<Knjiga>();
            try
            {
                string upit = "SELECT idKnjiga, naziv, imePisca, prezimePisca FROM Knjiga";
                using SqlCommand cmd = new SqlCommand(upit,connection);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Knjiga knjiga = new Knjiga
                    {
                        Id = reader.GetInt64(0),
                        Naziv = reader.GetString(1),
                        ImePisca = reader.GetString(2),
                        PrezimePisca = reader.GetString(3)
                    };
                    lista.Add(knjiga);

                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Greska pri vracanju liste knjiga!" + ex.Message);
            }
            return lista;
        }

        public List<Knjiga> PretraziKnjige(string kriterijum)
        {
            List<Knjiga> lista = new List<Knjiga>();
            try
            {
                string upit = "SELECT idKnjiga, naziv, imePisca, prezimePisca FROM Knjiga WHERE naziv LIKE @krit OR imePisca LIKE @krit OR prezimePisca LIKE @krit";
                using SqlCommand cmd = new SqlCommand(upit, connection);
                cmd.Parameters.AddWithValue("@krit", "%"+kriterijum+"%");
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Knjiga knjiga = new Knjiga
                    {
                        Id = reader.GetInt64(0),
                        Naziv = reader.GetString(1),
                        ImePisca = reader.GetString(2),
                        PrezimePisca = reader.GetString(3)
                    };
                    lista.Add(knjiga);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Greska pri pretrazivanju knjige " + ex.Message);
                throw;
            }
            return lista;
        }
        public void IzmeniKnjigu(Knjiga knjiga)
        {
            try
            {
                string upit = "UPDATE Knjiga SET naziv=@naziv, imePisca=@imePisca, prezimePisca=@prezimePisca WHERE idKnjiga=@id";
                using SqlCommand cmd = new SqlCommand(upit, connection);
                cmd.Parameters.AddWithValue("@id", knjiga.Id);
                cmd.Parameters.AddWithValue("@naziv", knjiga.Naziv);
                cmd.Parameters.AddWithValue("@imePisca", knjiga.ImePisca);
                cmd.Parameters.AddWithValue("@prezimePisca", knjiga.PrezimePisca);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Knjiga uspesno izmenjena!");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Greska pri izmeni knjige: " + ex.Message);
                throw;
            }
        }

        public void ObrisiKnjigu(long id)
        {
            try
            {
                string upit = "DELETE FROM Knjiga WHERE idKnjiga=@id";
                using SqlCommand cmd = new SqlCommand(upit, connection);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Knjiga uspesno obrisana!");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Greska pri brisanju knjige: " + ex.Message);
                throw;
            }
        }


        //----------------------------- CLAN

        public bool KreirajClana(Clan clan)
        {
            try
            {
                string upit = "INSERT INTO Clan (ime, prezime, telefon, datumOd, datumDo, idClanstva) VALUES (@ime, @prezime, @telefon, @datumOd, @datumDo, @idClanstva)";
                using SqlCommand cmd = new SqlCommand(upit, connection);
                cmd.Parameters.AddWithValue("@ime", clan.Ime);
                cmd.Parameters.AddWithValue("@prezime", clan.Prezime);
                cmd.Parameters.AddWithValue("@telefon", clan.Telefon);
                cmd.Parameters.AddWithValue("@datumOd", clan.DatumOd.ToDateTime(TimeOnly.MinValue));
                cmd.Parameters.AddWithValue("@datumDo", clan.DatumDo.ToDateTime(TimeOnly.MinValue));
                cmd.Parameters.AddWithValue("@idClanstva", clan.IdClanstva);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Greska pri kreiranju clana: " + ex.Message);
                throw;
            }
        }

        public List<Clan> PretraziClanove(string kriterijum)
        {
            List<Clan> lista = new List<Clan>();
            try
            {
                string upit = "SELECT idClan, ime, prezime, telefon, datumOd, datumDo, idClanstva FROM Clan";
                if (!string.IsNullOrWhiteSpace(kriterijum))
                {
                    upit += " WHERE ime LIKE @krit OR prezime LIKE @krit OR CAST(telefon AS VARCHAR) LIKE @krit";
                }

                using SqlCommand cmd = new SqlCommand(upit, connection);
                if (!string.IsNullOrWhiteSpace(kriterijum))
                {
                    cmd.Parameters.AddWithValue("@krit", "%" +kriterijum+ "%");
                }

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Clan
                    {
                        Id = reader.GetInt64(0),
                        Ime = reader.GetString(1),
                        Prezime = reader.GetString(2),
                        Telefon = reader.GetInt64(3),
                        DatumOd = DateOnly.FromDateTime(reader.GetDateTime(4)),
                        DatumDo = DateOnly.FromDateTime(reader.GetDateTime(5)),
                        IdClanstva = reader.GetInt64(6)
                    });
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Greska pri pretrazi clanova: " + ex.Message);
                throw;
            }
            return lista;
        }

        public bool IzmeniClana(Clan clan)
        {
            try
            {
                string upit = "UPDATE Clan SET ime=@ime, prezime=@prezime, telefon=@telefon, datumOd=@datumOd, datumDo=@datumDo, idClanstva=@idClanstva WHERE idClan=@id";
                using SqlCommand cmd = new SqlCommand(upit, connection);
                cmd.Parameters.AddWithValue("@id", clan.Id);
                cmd.Parameters.AddWithValue("@ime", clan.Ime);
                cmd.Parameters.AddWithValue("@prezime", clan.Prezime);
                cmd.Parameters.AddWithValue("@telefon", clan.Telefon);
                cmd.Parameters.AddWithValue("@datumOd", clan.DatumOd.ToDateTime(TimeOnly.MinValue));
                cmd.Parameters.AddWithValue("@datumDo", clan.DatumDo.ToDateTime(TimeOnly.MinValue));
                cmd.Parameters.AddWithValue("@idClanstva", clan.IdClanstva);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Greska pri izmeni clana: " + ex.Message);
                throw;
            }
        }

        public bool ObrisiClana(long id)
        {
            try
            {
                string upit = "DELETE FROM Clan WHERE idClan=@id";
                using SqlCommand cmd = new SqlCommand(upit, connection);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Greska pri brisanju clana: " + ex.Message);
                throw;
            }
        }

        public Clan? GetClanById(long id)
        {
            try
            {
                string upit = "SELECT idClan, ime, prezime, telefon, datumOd, datumDo, idClanstva FROM Clan WHERE idClan=@id";
                using SqlCommand cmd = new SqlCommand(upit, connection);
                cmd.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Clan
                    {
                        Id = reader.GetInt64(0),
                        Ime = reader.GetString(1),
                        Prezime = reader.GetString(2),
                        Telefon = reader.GetInt64(3),
                        DatumOd = DateOnly.FromDateTime(reader.GetDateTime(4)),
                        DatumDo = DateOnly.FromDateTime(reader.GetDateTime(5)),
                        IdClanstva = reader.GetInt64(6)
                    };
                }
                return null;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Greska pri dohvatanju clana: " + ex.Message);
                throw;
            }
        }



    }
}
