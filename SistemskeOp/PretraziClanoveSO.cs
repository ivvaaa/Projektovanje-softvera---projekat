using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    //vratiListuClan(kriterijumClan, Lista<Clan>) - SK6/SK7
    //prazan kriterijum = vrati sve clanove
    //tipClanstva = true -> vrati listu clanstava (preduslov SK7)
    public class PretraziClanoveSO : SOBase
    {
        private string kriterijum;
        private bool tipClanstva;

        public List<Clan> Result { get; private set; }
        public List<Clanstvo> ResultClanstva { get; private set; }

        public PretraziClanoveSO(string kriterijum)
        {
            this.kriterijum = kriterijum;
            this.tipClanstva = false;
        }

        //Ucitavanje svih tipova clanstava - preduslov SK7
        public PretraziClanoveSO(bool rezimClanstva) 
        {
            this.kriterijum = "";
            this.tipClanstva = rezimClanstva;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (tipClanstva)
            {
                ResultClanstva = broker.GetAll(new Clanstvo()).Cast<Clanstvo>().ToList();
                return;  //samo ucitava tipove clanstva
            }

            if (string.IsNullOrWhiteSpace(kriterijum))
            {
                Result = broker.GetAll(new Clan()).Cast<Clan>().ToList();
                return; //uzima sve clanove
            }

            //pretraga po clanu (ime, prezime, telefon)
            string conditionClan = $"ime LIKE '%{kriterijum}%' OR prezime LIKE '%{kriterijum}%' OR CAST(telefon AS VARCHAR) LIKE '%{kriterijum}%'";
            List<Clan> poClanovima = broker.GetByCondition(new Clan(), conditionClan).Cast<Clan>().ToList();

            //pretraga po tipu clanstvua
            string conditionClanstvo = $"vrsta LIKE '%{kriterijum}%'";
            List<Clanstvo> clanstva = broker.GetByCondition(new Clanstvo(), conditionClanstvo).Cast<Clanstvo>().ToList();

            List<Clan> poClanstvu = new List<Clan>();
            foreach (var c in clanstva)
            {
                List<Clan> clanoviTipa = broker.GetByCondition(new Clan(), $"idClanstvo = {c.Id}").Cast<Clan>().ToList();
                poClanstvu.AddRange(clanoviTipa);
            }

            //unija
            Result = poClanovima
                .Union(poClanstvu, new ClanIdEqualityComparer())  //nema dupliakta
                .ToList();
        }
    }

    internal class ClanIdEqualityComparer : IEqualityComparer<Clan>
    {
        public bool Equals(Clan x, Clan y) => x?.Id == y?.Id;
        public int GetHashCode(Clan obj) => obj.Id.GetHashCode();
    }
}