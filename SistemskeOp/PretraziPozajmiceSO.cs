using Domeni;

namespace SistemskeOp
{
    //vratiListuPozajmica(kriterijumClan, Lista<Pozajmica>)
    //prazan kriterijum = vrati sve (pocetno punjenje forme)
    public class PretraziPozajmiceSO : SOBase
    {
        private string kriterijum;
        public List<Pozajmica> Result { get; private set; }

        public PretraziPozajmiceSO(string kriterijum)
        {
            this.kriterijum = kriterijum;
        }

        protected override void ExecuteConcreteOperation()
        {
            //ucitavanje clanova svih ili po kriterijumu
            List<Clan> clanovi;
            if (string.IsNullOrWhiteSpace(kriterijum))
            {
                clanovi = broker.GetAll(new Clan()).Cast<Clan>().ToList();
            }
            else
            {
                string conditionClan = $"ime LIKE '%{kriterijum}%' OR prezime LIKE '%{kriterijum}%'";
                clanovi = broker.GetByCondition(new Clan(), conditionClan).Cast<Clan>().ToList();
            }

            //poz za zvakog
            List<Pozajmica> svePozajmice = new List<Pozajmica>();
            foreach (var clan in clanovi)
            {
                List<Pozajmica> pozajmicaClana = broker.GetByCondition(new Pozajmica(), $"Pozajmica.idClan = {clan.Id}")
                                                                        .Cast<Pozajmica>().ToList();
                svePozajmice.AddRange(pozajmicaClana);
            }

            //za svaku poz stavke
            foreach (var pozajmica in svePozajmice)
            {
                List<StavkaPozajmice> stavke = broker.GetByCondition(new StavkaPozajmice(), $"StavkaPozajmice.idPozajmica = {pozajmica.Id}")
                                                                      .Cast<StavkaPozajmice>().ToList();
                pozajmica.Stavke = stavke;

                //ime i prez iz vec ucitanih
                Clan clan = clanovi.FirstOrDefault(c => c.Id == pozajmica.IdClan);
                pozajmica.ImePrezimeClana = clan != null ? $"{clan.Ime} {clan.Prezime}" : "";

                pozajmica.BrojKnjiga = stavke.Count;

                bool imaAktivnih = stavke.Any(s => s.DatumVracanja == null);
                bool imaZakasnelih = stavke.Any(s => s.DatumVracanja == null && s.RokPozajmice < DateTime.Today);

                pozajmica.Status = !imaAktivnih ? "Vraceno"
                                 : imaZakasnelih ? "Zakasnelo"
                                 : "Aktivna";
            }

            Result = svePozajmice;
        }
    }
}
