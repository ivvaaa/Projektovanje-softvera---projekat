using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeni
{
    public class Pozajmica
    {
        public long Id { get; set; }
        public DateOnly DatumOd { get; set; }
        public long IdBibliotekar { get; set; }
        public long IdClan { get; set; }


    }
}
