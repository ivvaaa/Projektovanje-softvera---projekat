
using Microsoft.Data.SqlClient;

namespace BrokerBP
{
    public class Broker
    {
        private SqlConnection connection;

        public void Connect()
        {
            try
            {
                connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Projekat-Softveri;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
                connection.Open();
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



    }
}
