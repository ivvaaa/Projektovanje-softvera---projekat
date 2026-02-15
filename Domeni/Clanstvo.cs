using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Domeni
{
    public class Clanstvo : IEntity
    {
        public long Id { get; set; }
        public long Cena { get; set; }
        public string Vrsta { get; set; }

        public string TableName => "Clanstvo";

        public string InsertColumns => "cena, vrsta";

        public string Values => $"{Cena}, '{Vrsta}'";

        public string PrimaryKey => "idClanstvo";

        public string Join => "";

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

        public override string ToString()
        {
            return $"{Vrsta} ({Cena} RSD)";
        }
    }
}