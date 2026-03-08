using System.ComponentModel;
using Microsoft.Data.SqlClient;

namespace Domeni
{
    /// <summary>
    /// Predstavlja knjigu u biblioteci sa podacima o piscu i broju dostupnih primeraka.
    /// Implementira <see cref="IEntity"/> za pristup tabeli <c>Knjiga</c> u bazi podataka.
    /// </summary>
    public class Knjiga : IEntity
    {
        /// <summary>Jedinstveni identifikator knjige u bazi podataka.</summary>
        public long Id { get; set; }

        /// <summary>Naziv (naslov) knjige.</summary>
        public string Naziv { get; set; }

        /// <summary>Ime autora knjige.</summary>
        public string ImePisca { get; set; }

        /// <summary>Prezime autora knjige.</summary>
        public string PrezimePisca { get; set; }

        /// <summary>
        /// Ukupan broj primeraka knjige u biblioteci.
        /// Podrazumevano <c>1</c>.
        /// </summary>
        public int BrojPrimeraka { get; set; } = 1;

        /// <summary>
        /// Broj slobodnih (ne pozajmljenih) primeraka.
        /// Izračunava se u <see cref="SistemskeOp.PretraziKnjigeSO"/> — nije kolona u bazi.
        /// </summary>
        public int BrojSlobodnih { get; set; }

        /// <summary>
        /// Vraća <c>true</c> ako ima najmanje jedan slobodan primerak.
        /// </summary>
        public bool Dostupna => BrojSlobodnih > 0;

        /// <inheritdoc/>
        [Browsable(false)]
        public string TableName => "Knjiga";

        /// <inheritdoc/>
        [Browsable(false)]
        public string InsertColumns => "naziv,imePisca,prezimePisca,brojPrimeraka";

        /// <inheritdoc/>
        [Browsable(false)]
        public string Values => $"'{Naziv}', '{ImePisca}', '{PrezimePisca}', {BrojPrimeraka}";

        /// <inheritdoc/>
        [Browsable(false)]
        public string PrimaryKey => "idKnjiga";

        /// <inheritdoc/>
        [Browsable(false)]
        public string Join => "";

        /// <inheritdoc/>
        [Browsable(false)]
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
