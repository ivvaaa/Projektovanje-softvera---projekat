using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    public class LoginSO : SOBase
    {
        private Bibliotekar bibliotekar;
        public Bibliotekar Result { get; private set; }

        public LoginSO(Bibliotekar b)
        {
            bibliotekar = b;
        }

        protected override void ExecuteConcreteOperation()
        {
            string condition = $"username = '{bibliotekar.Username}' AND password = '{bibliotekar.Password}'";
            List<IEntity> lista = broker.GetByCondition(new Bibliotekar(), condition);
            Result = lista.Cast<Bibliotekar>().FirstOrDefault();
            if (Result == null)
                throw new Exception("Neispravni kredencijali.");

        }
    }

}
