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
        private long _idBibliotekara;
        private long _idTerminSmene;
        private DateTime _datum;

        /// <summary>
        /// Identifikator bibliotekara koji je raspoređen u smenu.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost manja od ili jednaka nuli.</exception>
        public long IdBibliotekara
        {
            get => _idBibliotekara;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("IdBibliotekara mora biti pozitivan broj.");
                _idBibliotekara = value;
            }
        }

        /// <summary>
        /// Identifikator termina smene (npr. 08-12, 12-16, 16-20).
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost manja od ili jednaka nuli.</exception>
        public long IdTerminSmene
        {
            get => _idTerminSmene;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("IdTerminSmene mora biti pozitivan broj.");
                _idTerminSmene = value;
            }
        }

        /// <summary>
        /// Datum kada se smena održava.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost default (nije postavljena).</exception>
        public DateTime Datum
        {
            get => _datum;
            set
            {
                if (value == default)
                    throw new ArgumentException("Datum mora biti postavljen.");
                _datum = value;
            }
        }

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
