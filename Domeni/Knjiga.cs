using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Domeni
{
    public class Knjiga : IEntity
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
        public string ImePisca { get; set; }
        public string PrezimePisca { get; set; }
        public int BrojPrimeraka { get; set; } = 1;
        public int BrojSlobodnih { get; set; }

        public bool Dostupna => BrojSlobodnih > 0;

        // IEntity 
        public string TableName => "Knjiga";

        public string InsertColumns => "naziv,imePisca,prezimePisca,brojPrimeraka";

        public string Values => $"'{Naziv}', '{ImePisca}', '{PrezimePisca}', {BrojPrimeraka}";

        public string PrimaryKey => "idKnjiga";

        public string Join => "";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new Knjiga
                {
                    Id = (long)reader["idKnjiga"],
                    Naziv = (string)reader["naziv"],
                    ImePisca = (string)reader["imePisca"],
                    PrezimePisca = (string)reader["prezimePisca"],
                    BrojPrimeraka = (int)reader["brojPrimeraka"]
                });
            }
            return lista;
        }
    }
}
