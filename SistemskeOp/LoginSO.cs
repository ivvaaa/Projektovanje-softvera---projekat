using System;
using System.Collections.Generic;
using System.Linq;
using Domeni;

namespace SistemskeOp
{
    /// <summary>
    /// Sistemska operacija za prijavljivanje bibliotekara u sistem (SK9).
    /// Proverava korisničko ime i lozinku u bazi podataka.
    /// Ako kredencijali nisu ispravni, baca izuzetak i prijava se ne izvršava.
    /// </summary>
    public class LoginSO : SOBase
    {
        private Bibliotekar bibliotekar;

        /// <summary>
        /// Bibliotekar pronađen u bazi nakon uspešne autentifikacije.
        /// Vrednost je <c>null</c> pre izvršavanja operacije.
        /// </summary>
        public Bibliotekar Result { get; private set; }

        /// <summary>
        /// Inicijalizuje operaciju sa kredencijalima bibliotekara koji se prijavljuje.
        /// </summary>
        /// <param name="b">
        /// Bibliotekar sa popunjenim <c>Username</c> i <c>Password</c> poljima.
        /// </param>
        public LoginSO(Bibliotekar b)
        {
            bibliotekar = b;
        }

        /// <inheritdoc/>
        /// <exception cref="Exception">
        /// Baca se ako u bazi ne postoji bibliotekar sa zadatim korisničkim imenom i lozinkom.
        /// </exception>
        //protected override void ExecuteConcreteOperation()
        //{
        //    string condition = $"username = '{bibliotekar.Username}' AND password = '{bibliotekar.Password}'";
        //    List<IEntity> lista = broker.GetByCondition(new Bibliotekar(), condition);
        //    Result = lista.Cast<Bibliotekar>().FirstOrDefault();
        //    if (Result == null)
        //        throw new Exception("Neispravni kredencijali.");
        //}

        protected override void ExecuteConcreteOperation()
        {
            string condition = $"username = '{bibliotekar.Username}' AND password = '{bibliotekar.Password}'";
            Console.WriteLine($">>> Uslov: {condition}");

            List<IEntity> lista = broker.GetByCondition(new Bibliotekar(), condition);
            Console.WriteLine($">>> Rezultata: {lista.Count}");

            Result = lista.Cast<Bibliotekar>().FirstOrDefault();
            if (Result == null)
                throw new Exception("Neispravni kredencijali.");

            Console.WriteLine($">>> Id pronađenog: {Result.Id}");
        }

    }
}
