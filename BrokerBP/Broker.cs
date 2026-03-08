using Microsoft.Data.SqlClient;
using Domeni;
using System.Reflection.Metadata;

namespace BrokerBP
{
    public class Broker
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Projekat-Softveri;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public void OpenConnection()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Konekcija otvorena.");
        }

        public void CloseConnection()
        {
            connection?.Close();
            Console.WriteLine("Konekcija zatvorena.");
        }

        public void BeginTransaction()
        {
            transaction = connection.BeginTransaction();
        }

        public void Commit()
        {
            transaction?.Commit();
        }

        public void Rollback()
        {
            transaction?.Rollback();
        }

        private SqlCommand CreateCommand()
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.Transaction = transaction;
            return cmd;
        }

        public void Add(IEntity entity)
        {
            SqlCommand cmd = CreateCommand();
            cmd.CommandText = $"INSERT INTO {entity.TableName} ({entity.InsertColumns}) VALUES ({entity.Values})";
            cmd.ExecuteNonQuery();
            Console.WriteLine("Dodat entitet u " + entity.TableName);
        }

        public long AddAndGetId(IEntity entity)  //samo za id pozajmice zbog dodavanja stavki
        {
            SqlCommand cmd = CreateCommand();
            cmd.CommandText = $"INSERT INTO {entity.TableName} ({entity.InsertColumns}) VALUES ({entity.Values}); SELECT SCOPE_IDENTITY();";
            object result = cmd.ExecuteScalar();
            long id = Convert.ToInt64(result);
            Console.WriteLine("Dodat entitet u " + entity.TableName + ", ID: " + id);
            return id;
        }

        public List<IEntity> GetAll(IEntity entity)
        {
            SqlCommand cmd = CreateCommand();
            cmd.CommandText = $"SELECT * FROM {entity.TableName} {entity.Join}";
            using SqlDataReader reader = cmd.ExecuteReader();
            List<IEntity> lista = entity.GetReaderList(reader);
            Console.WriteLine("Vraćeno " + lista.Count + " entiteta iz " + entity.TableName);
            return lista;
        }

        public List<IEntity> GetByCondition(IEntity entity, string condition)
        {
            SqlCommand cmd = CreateCommand();
            cmd.CommandText = $"SELECT * FROM {entity.TableName} {entity.Join} WHERE {condition}";
            using SqlDataReader reader = cmd.ExecuteReader();
            List<IEntity> lista = entity.GetReaderList(reader);
            Console.WriteLine("Vraćeno " + lista.Count + " entiteta iz " + entity.TableName + " sa uslovom: " + condition);
            return lista;
        }

        public void Update(IEntity entity, string setClause, string condition)
        {
            SqlCommand cmd = CreateCommand();
            cmd.CommandText = $"UPDATE {entity.TableName} SET {setClause} WHERE {condition}";
            int affected = cmd.ExecuteNonQuery();
            Console.WriteLine("Ažurirano " + affected + " redova u " + entity.TableName);
        }

        public void Delete(IEntity entity, string condition)
        {
            SqlCommand cmd = CreateCommand();
            cmd.CommandText = $"DELETE FROM {entity.TableName} WHERE {condition}";
            int affected = cmd.ExecuteNonQuery();
            Console.WriteLine("Obrisano " + affected + " redova iz " + entity.TableName);
        }

        public List<IEntity> ExecuteQuery(IEntity entity, string fullQuery)
        {
            SqlCommand cmd = CreateCommand();
            cmd.CommandText = fullQuery;
            using SqlDataReader reader = cmd.ExecuteReader();
            return entity.GetReaderList(reader);
        }

        public int ExecuteNonQuery(string query)
        {
            SqlCommand cmd = CreateCommand();
            cmd.CommandText = query;
            return cmd.ExecuteNonQuery();
        }

        public object ExecuteScalar(string query)
        {
            SqlCommand cmd = CreateCommand();
            cmd.CommandText = query;
            return cmd.ExecuteScalar();
        }

    }
}