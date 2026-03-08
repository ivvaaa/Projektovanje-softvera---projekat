using Microsoft.Data.SqlClient;

namespace Domeni
{
    /// <summary>
    /// Predstavlja smenu bibliotekara — vezu između bibliotekara, termina smene i konkretnog datuma.
    /// Implementira <see cref="IEntity"/> za pristup tabeli <c>[Bib-Smena]</c> u bazi podataka.
    /// Primarni ključ je složen: <c>idBibliotekar + idTerminSmene + datum</c>.
    /// </summary>
    public class BibSmena : IEntity
    {
        /// <summary>Identifikator bibliotekara koji je raspoređen u smenu.</summary>
        public long IdBibliotekara { get; set; }

        /// <summary>Identifikator termina smene (npr. 08-12, 12-16, 16-20).</summary>
        public long IdTerminSmene { get; set; }

        /// <summary>Datum kada se smena održava.</summary>
        public DateTime Datum { get; set; }

        /// <summary>
        /// Puno ime bibliotekara u obliku "Ime Prezime".
        /// Nije kolona u bazi — popunjava se u sistemskim operacijama JOIN-om.
        /// </summary>
        public string ImeBibliotekara { get; set; }

        /// <summary>
        /// Naziv termina smene (npr. "08-12").
        /// Nije kolona u bazi — popunjava se u sistemskim operacijama JOIN-om.
        /// </summary>
        public string NazivTermina { get; set; }

        /// <inheritdoc/>
        public string TableName => "[Bib-Smena]";

        /// <inheritdoc/>
        public string InsertColumns => "idBibliotekar, idTerminSmene, datum";

        /// <inheritdoc/>
        public string Values => $"{IdBibliotekara}, {IdTerminSmene}, '{Datum:yyyy-MM-dd}'";

        /// <inheritdoc/>
        public string PrimaryKey => "idBibliotekar, idTerminSmene, datum";

        /// <inheritdoc/>
        public string Join => @"INNER JOIN Bibliotekar b ON [Bib-Smena].idBibliotekar = b.idBibliotekar 
                                INNER JOIN TerminSmene t ON [Bib-Smena].idTerminSmene = t.idTerminSmene";

        /// <inheritdoc/>
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

        /// <summary>
        /// Vraća tekstualni prikaz smene u obliku "Smena: dd.MM.yyyy".
        /// </summary>
        public override string ToString() => $"Smena: {Datum:dd.MM.yyyy}";
    }
}
