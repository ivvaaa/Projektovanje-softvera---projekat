using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeni
{
    public class Clan
    {
        public long Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public long Telefon { get; set; }
        public DateOnly DatumOd { get; set; }
        public DateOnly DatumDo { get; set; }
        public long IdClanstva { get; set; }


    }
}
