using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Domeni
{
    /// <summary>
    /// Interfejs koji moraju implementirati sve domenske klase kako bi bile kompatibilne
    /// sa generičkim <see cref="BrokerBP.Broker"/> slojem za pristup bazi podataka.
    /// Definiše metapodatke potrebne za automatsko generisanje SQL upita.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Naziv tabele u bazi podataka kojoj ova klasa odgovara.
        /// </summary>
        string TableName { get; }

        /// <summary>
        /// SQL fragment sa vrednostima za INSERT upit, npr. <c>'Ime', 'Prezime', 123</c>.
        /// </summary>
        string Values { get; }

        /// <summary>
        /// SQL fragment sa nazivima kolona za INSERT upit, npr. <c>ime, prezime, telefon</c>.
        /// </summary>
        string InsertColumns { get; }

        /// <summary>
        /// Naziv kolone (ili kolona) koje čine primarni ključ tabele, npr. <c>idBibliotekar</c>.
        /// </summary>
        string PrimaryKey { get; }

        /// <summary>
        /// SQL fragment za JOIN klauzulu koja se dodaje uz SELECT upit, ukoliko je potrebno
        /// učitati podatke iz povezanih tabela. Prazna vrednost znači da nema JOIN-a.
        /// </summary>
        string Join { get; }

        /// <summary>
        /// Čita redove iz <see cref="SqlDataReader"/>-a i vraća listu entiteta odgovarajućeg tipa.
        /// </summary>
        /// <param name="reader">Otvoreni <see cref="SqlDataReader"/> sa rezultatima upita.</param>
        /// <returns>Lista entiteta popunjenih podacima iz čitača.</returns>
        List<IEntity> GetReaderList(SqlDataReader reader);
    }
}
