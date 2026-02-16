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

        public long AddAndGetId(IEntity entity)
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

        public List<Pozajmica> GetPozajmiceSaStatusom(string kriterijum = "")
        {
            List<Pozajmica> lista = new List<Pozajmica>();

            string upit = @"
                SELECT 
                    p.idPozajmica, 
                    p.datumOd, 
                    p.idBibliotekar, 
                    p.idClan, 
                    c.ime + ' ' + c.prezime as ImePrezimeClana,
                    COUNT(sp.idKnjiga) as BrojKnjiga,
                    CASE 
                        WHEN COUNT(CASE WHEN sp.datumVracanja IS NULL THEN 1 END) = 0 THEN 'Vraceno'
                        WHEN MIN(CASE WHEN sp.datumVracanja IS NULL THEN sp.rokPozajmice END) < CAST(GETDATE() AS DATE) THEN 'Zakasnelo'
                        ELSE 'Aktivna'
                    END as Status
                FROM Pozajmica p
                INNER JOIN Clan c ON p.idClan = c.idClan
                LEFT JOIN StavkaPozajmice sp ON p.idPozajmica = sp.idPozajmica";

            if (!string.IsNullOrWhiteSpace(kriterijum))
            {
                upit += $" WHERE c.ime LIKE '%{kriterijum}%' OR c.prezime LIKE '%{kriterijum}%'";
            }

            upit += " GROUP BY p.idPozajmica, p.datumOd, p.idBibliotekar, p.idClan, c.ime, c.prezime ORDER BY p.datumOd DESC";

            SqlCommand cmd = CreateCommand();
            cmd.CommandText = upit;
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Pozajmica
                {
                    Id = (long)reader["idPozajmica"],
                    DatumOd = (DateTime)reader["datumOd"],
                    IdBibliotekar = (long)reader["idBibliotekar"],
                    IdClan = (long)reader["idClan"],
                    ImePrezimeClana = (string)reader["ImePrezimeClana"],
                    BrojKnjiga = (int)reader["BrojKnjiga"],
                    Status = (string)reader["Status"]
                });
            }

            return lista;
        }

        public List<StavkaPozajmice> GetStavkePozajmice(long idPozajmice)
        {
            List<StavkaPozajmice> lista = new List<StavkaPozajmice>();

            string upit = @"
                SELECT 
                    sp.rbStavkaPozajmice, 
                    sp.idPozajmica, 
                    sp.rokPozajmice, 
                    sp.idKnjiga, 
                    k.naziv as NazivKnjige,
                    sp.datumVracanja
                FROM StavkaPozajmice sp
                INNER JOIN Knjiga k ON sp.idKnjiga = k.idKnjiga
                WHERE sp.idPozajmica = " + idPozajmice;

            SqlCommand cmd = CreateCommand();
            cmd.CommandText = upit;
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new StavkaPozajmice
                {
                    Id = (long)reader["rbStavkaPozajmice"],
                    IdPozajmica = (long)reader["idPozajmica"],
                    RokPozajmice = (DateTime)reader["rokPozajmice"],
                    IdKnjige = (long)reader["idKnjiga"],
                    NazivKnjige = (string)reader["NazivKnjige"],
                    DatumVracanja = reader["datumVracanja"] == DBNull.Value ? null : (DateTime)reader["datumVracanja"]
                });
            }

            return lista;
        }

        public List<Knjiga> GetKnjigeSaSlobodnim(string kriterijum = "")
        {
            List<Knjiga> lista = new List<Knjiga>();

            string upit = @"
                SELECT 
                    k.idKnjiga, 
                    k.naziv, 
                    k.imePisca, 
                    k.prezimePisca, 
                    k.brojPrimeraka,
                    k.brojPrimeraka - ISNULL(
                        (SELECT COUNT(*) 
                         FROM StavkaPozajmice sp 
                         WHERE sp.idKnjiga = k.idKnjiga 
                         AND sp.datumVracanja IS NULL), 0
                    ) AS BrojSlobodnih
                FROM Knjiga k";

            if (!string.IsNullOrWhiteSpace(kriterijum))
            {
                upit += $" WHERE k.naziv LIKE '%{kriterijum}%' OR k.imePisca LIKE '%{kriterijum}%' OR k.prezimePisca LIKE '%{kriterijum}%'";
            }

            SqlCommand cmd = CreateCommand();
            cmd.CommandText = upit;
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Knjiga
                {
                    Id = (long)reader["idKnjiga"],
                    Naziv = (string)reader["naziv"],
                    ImePisca = (string)reader["imePisca"],
                    PrezimePisca = (string)reader["prezimePisca"],
                    BrojPrimeraka = (int)reader["brojPrimeraka"],
                    BrojSlobodnih = (int)reader["BrojSlobodnih"]
                });
            }

            return lista;
        }

        public int GetBrojSlobodnihPrimeraka(long idKnjige)
        {
            string upit = @"
                SELECT 
                    k.brojPrimeraka - ISNULL(
                        (SELECT COUNT(*) 
                         FROM StavkaPozajmice sp 
                         WHERE sp.idKnjiga = k.idKnjiga 
                         AND sp.datumVracanja IS NULL), 0
                    )
                FROM Knjiga k
                WHERE k.idKnjiga = " + idKnjige;

            SqlCommand cmd = CreateCommand();
            cmd.CommandText = upit;
            object result = cmd.ExecuteScalar();
            return Convert.ToInt32(result);
        }

        public int GetBrojPozajmljenihPrimeraka(long idKnjige)
        {
            string upit = @"
                SELECT COUNT(*) 
                FROM StavkaPozajmice 
                WHERE idKnjiga = " + idKnjige + @" 
                AND datumVracanja IS NULL";

            SqlCommand cmd = CreateCommand();
            cmd.CommandText = upit;
            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public bool KnjigaPostoji(long idKnjige)
        {
            string upit = "SELECT COUNT(*) FROM Knjiga WHERE idKnjiga = " + idKnjige;
            SqlCommand cmd = CreateCommand();
            cmd.CommandText = upit;
            object result = cmd.ExecuteScalar();
            return result != null && Convert.ToInt32(result) > 0;
        }
    }
}