using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domeni;

namespace SistemskeOp
{
    // vratiListuClan(kriterijumClan, Lista<Clan>) - SK6/SK7
    // prazan kriterijum = vrati sve clanove
    // rezimClanstva = true -> vrati listu clanstava (preduslov SK7)
    public class PretraziClanoveSO : SOBase
    {
        private string kriterijum;
        private bool rezimClanstva;

        public List<Clan> Result { get; private set; }
        public List<Clanstvo> ResultClanstva { get; private set; }

        // Pretraga clanova (prazan = svi)
        public PretraziClanoveSO(string kriterijum)
        {
            this.kriterijum = kriterijum;
            this.rezimClanstva = false;
        }

        // Ucitavanje svih clanstava - preduslov SK7
        public PretraziClanoveSO(bool rezimClanstva)
        {
            this.kriterijum = "";
            this.rezimClanstva = rezimClanstva;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (rezimClanstva)
            {
                ResultClanstva = broker.GetAll(new Clanstvo()).Cast<Clanstvo>().ToList();
                return;
            }

            if (string.IsNullOrWhiteSpace(kriterijum))
            {
                Result = broker.GetAll(new Clan()).Cast<Clan>().ToList();
                return;
            }

            // a) pretraga po clanu (ime, prezime, telefon)
            string conditionClan = $"ime LIKE '%{kriterijum}%' OR prezime LIKE '%{kriterijum}%' OR CAST(telefon AS VARCHAR) LIKE '%{kriterijum}%'";
            List<Clan> poClanovima = broker.GetByCondition(new Clan(), conditionClan).Cast<Clan>().ToList();

            // b) pretraga po clanstvu (vrsta)
            string conditionClanstvo = $"vrsta LIKE '%{kriterijum}%'";
            List<Clanstvo> clanstva = broker.GetByCondition(new Clanstvo(), conditionClanstvo).Cast<Clanstvo>().ToList();

            List<Clan> poClanstvu = new List<Clan>();
            foreach (var c in clanstva)
            {
                List<Clan> clanoviTipa = broker.GetByCondition(new Clan(), $"idClanstvo = {c.Id}").Cast<Clan>().ToList();
                poClanstvu.AddRange(clanoviTipa);
            }

            // Unija bez duplikata
            Result = poClanovima
                .Union(poClanstvu, new ClanIdEqualityComparer())
                .ToList();
        }
    }

    internal class ClanIdEqualityComparer : IEqualityComparer<Clan>
    {
        public bool Equals(Clan x, Clan y) => x?.Id == y?.Id;
        public int GetHashCode(Clan obj) => obj.Id.GetHashCode();
    }
}