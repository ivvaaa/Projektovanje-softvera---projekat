using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicki
{
    public enum Operacija
    {
        //SK9
        PrijaviBibliotekar,

        //Knjige - SK14, SK15, SK16, SK17
        UbaciKnjigu,
        PretraziKnjigu,     // prazan kriterijum = sve knjige
        IzmeniKnjigu,
        ObrisiKnjigu,

        //Clanovi - SK5, SK6, SK7, SK8
        KreirajClana,
        PretraziClana,      // prazan kriterijum = svi clanovi
        IzmeniClana,
        ObrisiClana,
        VratiSvaClanstva,   // pomocna - ucitavanje liste clanstava za forme (SK7 preduslov)

        //Pozajmice - SK1, SK2
        KreirajPozajmicu,
        PretraziPozajmicu,  //prazan kriterijum = sve
        VratiKnjigu,        //PromeniPozajmica - vracanje knjige
        IzmeniRokPozajmice, //SK3 - promena roka pozajmice (stavke)

    }
}