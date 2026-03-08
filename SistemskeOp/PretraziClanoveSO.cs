using System;
using System.Collections.Generic;
using System.Linq;
using Domeni;

namespace SistemskeOp
{
    /// <summary>
    /// Sistemska operacija za pretragu članova biblioteke (SK6/SK7).
    /// Podržava dva režima rada u zavisnosti od konstruktora koji se koristi:
    /// <list type="bullet">
    ///   <item>Pretraga članova po imenu, prezimenu, telefonu ili tipu članarine.</item>
    ///   <item>Učitavanje svih tipova članarina (preduslov za SK7 — izmenu člana).</item>
    /// </list>
    /// Prazan kriterijum u prvom režimu vraća sve članove.
    /// </summary>
    public class PretraziClanoveSO : SOBase
    {
        private string kriterijum;
        private bool tipClanstva;

        /// <summary>
        /// Lista pronađenih članova. Popunjena u režimu pretrage članova.
        /// </summary>
        public List<Clan> Result { get; private set; }

        /// <summary>
        /// Lista svih tipova članarina. Popunjena samo u režimu <c>rezimClanstva = true</c>.
        /// </summary>
        public List<Clanstvo> ResultClanstva { get; private set; }

        /// <summary>
        /// Inicijalizuje operaciju za pretragu članova po zadatom kriterijumu.
        /// </summary>
        /// <param name="kriterijum">
        /// Tekst za pretragu po imenu, prezimenu, broju telefona ili vrsti članarine.
        /// Prazan string ili <c>null</c> vraća sve članove.
        /// </param>
        public PretraziClanoveSO(string kriterijum)
        {
            this.kriterijum = kriterijum;
            this.tipClanstva = false;
        }

        /// <summary>
        /// Inicijalizuje operaciju za učitavanje svih tipova članarina (preduslov SK7).
        /// U ovom režimu <see cref="ResultClanstva"/> se popunjava, a <see cref="Result"/> ostaje <c>null</c>.
        /// </summary>
        /// <param name="rezimClanstva">
        /// Ako je <c>true</c>, operacija učitava tipove članarina umesto članova.
        /// </param>
        public PretraziClanoveSO(bool rezimClanstva)
        {
            this.kriterijum = "";
            this.tipClanstva = rezimClanstva;
        }

        /// <inheritdoc/>
        protected override void ExecuteConcreteOperation()
        {
            // Režim: učitavanje tipova članarina
            if (tipClanstva)
            {
                ResultClanstva = broker.GetAll(new Clanstvo()).Cast<Clanstvo>().ToList();
                return;
            }

            // Režim: vraćanje svih članova (bez filtera)
            if (string.IsNullOrWhiteSpace(kriterijum))
            {
                Result = broker.GetAll(new Clan()).Cast<Clan>().ToList();
                return;
            }

            // Pretraga po imenu, prezimenu ili telefonu člana
            string conditionClan = $"ime LIKE '%{kriterijum}%' OR prezime LIKE '%{kriterijum}%' " +
                                   $"OR CAST(telefon AS VARCHAR) LIKE '%{kriterijum}%'";
            List<Clan> poClanovima = broker.GetByCondition(new Clan(), conditionClan).Cast<Clan>().ToList();

            // Pretraga po vrsti članarine
            string conditionClanstvo = $"vrsta LIKE '%{kriterijum}%'";
            List<Clanstvo> clanstva = broker.GetByCondition(new Clanstvo(), conditionClanstvo).Cast<Clanstvo>().ToList();

            List<Clan> poClanstvu = new List<Clan>();
            foreach (var c in clanstva)
            {
                List<Clan> clanoviTipa = broker.GetByCondition(new Clan(), $"idClanstvo = {c.Id}").Cast<Clan>().ToList();
                poClanstvu.AddRange(clanoviTipa);
            }

            // Unija rezultata bez duplikata (po ID-u člana)
            Result = poClanovima
                .Union(poClanstvu, new ClanIdEqualityComparer())
                .ToList();
        }
    }

    /// <summary>
    /// Pomoćna klasa za poređenje članova po identifikatoru.
    /// Koristi se za uklanjanje duplikata pri uniji rezultata pretrage.
    /// </summary>
    internal class ClanIdEqualityComparer : IEqualityComparer<Clan>
    {
        /// <inheritdoc/>
        public bool Equals(Clan x, Clan y) => x?.Id == y?.Id;

        /// <inheritdoc/>
        public int GetHashCode(Clan obj) => obj.Id.GetHashCode();
    }
}
