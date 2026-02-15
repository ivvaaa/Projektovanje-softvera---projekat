using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{

    public class PretraziClanoveSO : SOBase
    {
        private string kriterijum;
        public List<Clan> Result { get; private set; }

        public PretraziClanoveSO(string kriterijum)
        {
            this.kriterijum = kriterijum;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (string.IsNullOrWhiteSpace(kriterijum))
            {
                List<IEntity> lista = broker.GetAll(new Clan());
                Result = lista.Cast<Clan>().ToList();
            }
            else
            {
                string condition = $"ime LIKE '%{kriterijum}%' OR prezime LIKE '%{kriterijum}%'";
                List<IEntity> lista = broker.GetByCondition(new Clan(), condition);
                Result = lista.Cast<Clan>().ToList();
            }
        }
    }
}
