
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



    }
}
