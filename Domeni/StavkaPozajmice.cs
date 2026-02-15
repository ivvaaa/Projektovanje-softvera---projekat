using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Domeni
{
    public class StavkaPozajmice : IEntity
    {
        public long Id { get; set; }    //rbStavkaPozajmice
        public long IdPozajmica { get; set; }     //idPozajmica (FK)
        public DateTime RokPozajmice { get; set; }
        public long IdKnjige { get; set; }
        public DateTime? DatumVracanja { get; set; }
        public string NazivKnjige { get; set; }
        public bool JeVracena => DatumVracanja.HasValue;
        public bool JeZakasnela => !JeVracena && RokPozajmice < DateTime.Now;
        public string TableName => "StavkaPozajmice";
        public string InsertColumns => "idPozajmica, rokPozajmice, idKnjiga";
        public string Values => $"{IdPozajmica}, '{RokPozajmice:yyyy-MM-dd}', {IdKnjige}";
        public string PrimaryKey => "idPozajmica, rbStavkaPozajmice";
        public string Join => "INNER JOIN Knjiga k ON StavkaPozajmice.idKnjiga = k.idKnjiga";
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new StavkaPozajmice
                {
                    Id = (long)reader["rbStavkaPozajmice"],
                    IdPozajmica = (long)reader["idPozajmica"],
                    RokPozajmice = (DateTime)reader["rokPozajmice"],
                    IdKnjige = (long)reader["idKnjiga"],
                    DatumVracanja = reader["datumVracanja"] == DBNull.Value
                                    ? null
                                    : (DateTime)reader["datumVracanja"]
                });
            }
            return lista;
        }

        public override string ToString()
        {
            string status = JeVracena ? "Vraćena" : (JeZakasnela ? "Zakasnela" : "Aktivna");
            return "Stavka: Knjiga ID " + IdKnjige+" - "+ status;
        }
    }
}
