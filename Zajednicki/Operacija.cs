using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicki
{
    public enum Operacija
    {
        // SK9
        PrijaviBibliotekar,

        //knjige - SK14, SK15, SK16, SK17
        UbaciKnjigu,
        VratiSveKnjige,
        PretraziKnjigu,
        IzmeniKnjigu,
        ObrisiKnjigu,

        //clanovi - SK5, SK6, SK7, SK8
        KreirajClana,
        VratiSveClanova,
        PretraziClana,
        IzmeniClana,
        ObrisiClana,

        // Pozajmice - SK1, SK2, SK3, SK4
        KreirajPozajmicu,
        PretraziPozajmicu,  //prazan kriterijum = sve, uneti kriterijum = filtriraj
        VratiKnjigu,        //PromeniPozajmica - vraćanje knjige (menja StavkaPozajmice)

        //pomoc za popunjavanje formi
        VratiSveBibliotekare,
    }
}
