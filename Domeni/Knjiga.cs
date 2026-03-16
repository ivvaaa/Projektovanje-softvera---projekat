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
        private long _id;
        private string _naziv;
        private string _imePisca;
        private string _prezimePisca;
        private int _brojPrimeraka = 1;

        /// <summary>
        /// Jedinstveni identifikator knjige u bazi podataka.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost manja od ili jednaka nuli.</exception>
        public long Id
        {
            get => _id;
            set
            {
                if (value <0)
                    throw new ArgumentException("Id mora biti pozitivan broj.");
                _id = value;
            }
        }

        /// <summary>
        /// Naziv (naslov) knjige.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost null ili prazna.</exception>
        public string Naziv
        {
            get => _naziv;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Naziv ne sme biti prazan.");
                _naziv = value;
            }
        }

        /// <summary>
        /// Ime autora knjige.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost null ili prazna.</exception>
        public string ImePisca
        {
            get => _imePisca;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ime pisca ne sme biti prazno.");
                _imePisca = value;
            }
        }

        /// <summary>
        /// Prezime autora knjige.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost null ili prazna.</exception>
        public string PrezimePisca
        {
            get => _prezimePisca;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Prezime pisca ne sme biti prazno.");
                _prezimePisca = value;
            }
        }

        /// <summary>
        /// Ukupan broj primeraka knjige u biblioteci. Mora biti najmanje 1.
        /// Podrazumevano <c>1</c>.
        /// </summary>
        /// <exception cref="ArgumentException">Baca se ako je vrednost manja od 1.</exception>
        public int BrojPrimeraka
        {
            get => _brojPrimeraka;
            set
            {
                if (value < 1)
                    throw new ArgumentException("Broj primeraka mora biti najmanje 1.");
                _brojPrimeraka = value;
            }
        }

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
