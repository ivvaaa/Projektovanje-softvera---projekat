using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeni
{
    public class StavkaPozajmice
    {
        public long Id { get; set; }
        public long RbPozajmice { get; set; }
        public DateOnly RokPozajmice { get; set; }
        public long IdKnjige { get; set; }

    }
}
