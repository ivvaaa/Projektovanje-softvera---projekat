using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Domeni
{
    public class Clan : IEntity
    {
        public long Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public long Telefon { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public long IdClanstva { get; set; }
        public string ImePrezime => $"{Ime} {Prezime}";
        public bool ClanarinaAktivna => DatumDo >= DateTime.Now;
        public string TableName => "Clan";

        public string InsertColumns => "ime, prezime, telefon, datumOd, datumDo, idClanstvo";

        public string Values => $"'{Ime}', '{Prezime}', {Telefon}, '{DatumOd:yyyy-MM-dd}', '{DatumDo:yyyy-MM-dd}', {IdClanstva}";

        public string PrimaryKey => "idClan";

        public string Join => "";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new Clan
                {
                    Id = (long)reader["idClan"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    Telefon = (long)reader["telefon"],
                    DatumOd = (DateTime)reader["datumOd"],
                    DatumDo = (DateTime)reader["datumDo"],
                    IdClanstva = (long)reader["idClanstvo"]
                });
            }
            return lista;
        }

        public override string ToString()
        {
            return $"{Ime} {Prezime} (Tel: {Telefon})";
        }
    }
}
