using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Domeni
{
    public class TerminSmene : IEntity
    {
        public long Id { get; set; }
        public string Termin { get; set; }

        public string TableName => "TerminSmene";
        public string InsertColumns => "termin";

        public string Values => $"'{Termin}'";

        public string PrimaryKey => "idTerminSmene";

        public string Join => "";
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new TerminSmene
                {
                    Id = (long)reader["idTerminSmene"],
                    Termin = (string)reader["termin"]
                });
            }
            return lista;
        }
        public override string ToString()
        {
            return Termin;
        }
    }
}
