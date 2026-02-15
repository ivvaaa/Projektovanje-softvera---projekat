using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Domeni/BibSmena.cs
using Microsoft.Data.SqlClient;

namespace Domeni
{
    public class BibSmena : IEntity
    {
        public long IdBibliotekara { get; set; }
        public long IdTerminSmene { get; set; }
        public DateTime Datum { get; set; }

        public string ImeBibliotekara { get; set; }
        public string NazivTermina { get; set; }

        public string TableName => "[Bib-Smena]";  //uglasta zbog -

        public string InsertColumns => "idBibliotekar, idTerminSmene, datum";

        public string Values => $"{IdBibliotekara}, {IdTerminSmene}, '{Datum:yyyy-MM-dd}'";

        public string PrimaryKey => "idBibliotekar, idTerminSmene";

        public string Join => @"INNER JOIN Bibliotekar b ON [Bib-Smena].idBibliotekar = b.idBibliotekar 
                                INNER JOIN TerminSmene t ON [Bib-Smena].idTerminSmene = t.idTerminSmene";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(new BibSmena
                {
                    IdBibliotekara = (long)reader["idBibliotekar"],
                    IdTerminSmene = (long)reader["idTerminSmene"],
                    Datum = (DateTime)reader["datum"]
                });
            }
            return lista;
        }

        public override string ToString()
        {
            return $"Smena: {Datum:dd.MM.yyyy}";
        }
    }
}

