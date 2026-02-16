using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicki
{
    public enum Operacija
    {
        PrijaviBibliotekara,

        UbaciKnjigu,
        PretraziKnjigu,
        IzmeniKnjigu,
        ObrisiKnjigu,

        KreirajClana,
        PretraziClana,
        IzmeniClana,
        ObrisiClana,

        KreirajPozajmicu,
        PretraziPozajmicu,
        IzmeniPozajmicu,

        PretraziKnjigeZaPozajmicu,
        PretraziClanoveZaPozajmicu,

        GetStavkePozajmice,
        VratiKnjigu

    }
}
