using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Domeni
{
    public class Pozajmica : IEntity
    {
        public long Id { get; set; }
        public DateTime DatumOd { get; set; }
        public long IdBibliotekar { get; set; }
        public long IdClan { get; set; }
        public List<StavkaPozajmice> Stavke { get; set; } = new List<StavkaPozajmice>();
        public string ImePrezimeClana { get; set; }
        public string ImePrezimeBibliotekar { get; set; }
        public int BrojKnjiga { get; set; }
        public string Status { get; set; }
        public DateTime? DatumVracanja =>
            Stavke != null && Stavke.Count > 0 && Stavke.All(s => s.DatumVracanja.HasValue)
                ? Stavke.Max(s => s.DatumVracanja)
                : null;
        public string TableName => "Pozajmica";

        public string InsertColumns => "datumOd, idBibliotekar, idClan";

        public string Values => $"'{DatumOd:yyyy-MM-dd}', {IdBibliotekar}, {IdClan}";

        public string PrimaryKey => "idPozajmica";

        public string Join => "INNER JOIN Clan c ON Pozajmica.idClan = c.idClan";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new Pozajmica
                {
                    Id = (long)reader["idPozajmica"],
                    DatumOd = (DateTime)reader["datumOd"],
                    IdBibliotekar = (long)reader["idBibliotekar"],
                    IdClan = (long)reader["idClan"]
                });
            }
            return lista;
        }
        public override string ToString()
        {
            return $"Pozajmica #{Id} - {DatumOd:dd.MM.yyyy}";
        }
    }
}