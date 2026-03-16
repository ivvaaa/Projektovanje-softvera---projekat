using Domeni;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekAPI.Controllers
{
    /// <summary>
    /// Operacije nad pozajmicama.
    /// Zamenjuje TCP case-ove: KreirajPozajmicu, PretraziPozajmicu, VratiKnjigu, IzmeniRokPozajmice
    /// iz ClientHandler-a.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PozajmicaController : ControllerBase
    {
        private readonly Kontroler _kontroler;

        public PozajmicaController(Kontroler kontroler)
        {
            _kontroler = kontroler;
        }

        /// <summary>
        /// SK2 — Pretraži pozajmice.
        /// GET /api/pozajmica               → sve pozajmice (sa stavkama, imenima, statusom)
        /// GET /api/pozajmica?q=Petar       → filtrirano po članu/bibliotekaru/knjizi
        /// </summary>
        [HttpGet]
        public IActionResult GetAll([FromQuery] string q = "")
        {
            try
            {
                List<Pozajmica> pozajmice = _kontroler.PretraziPozajmice(q);
                return Ok(new { signal = true, podaci = pozajmice });
            }
            catch (Exception ex)
            {
                return BadRequest(new { signal = false, poruka = ex.Message });
            }
        }

        /// <summary>
        /// SK1 — Kreiraj novu pozajmicu sa stavkama.
        /// POST /api/pozajmica
        /// Body: { "idClan": 1, "idBibliotekar": 1, "datumOd": "2026-03-15",
        ///         "stavke": [{ "idKnjige": 5, "rokPozajmice": "2026-03-30" }] }
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] Pozajmica pozajmica)
        {
            try
            {
                // Uzimamo ID bibliotekara iz sesije
                string? idStr = HttpContext.Session.GetString("bibliotekarId");
                if (long.TryParse(idStr, out long idBib))
                    pozajmica.IdBibliotekar = idBib;

                pozajmica.DatumOd = DateTime.Today;

                long idPozajmice = _kontroler.KreirajPozajmicu(pozajmica);
                return Ok(new { signal = true, poruka = "Pozajmica je uspešno kreirana.", podaci = idPozajmice });
            }
            catch (Exception ex)
            {
                return BadRequest(new { signal = false, poruka = ex.Message });
            }
        }

        /// <summary>
        /// SK3a — Vrati konkretnu knjigu iz pozajmice.
        /// POST /api/pozajmica/{idPozajmica}/vrati/{idKnjiga}
        /// </summary>
        [HttpPost("{idPozajmica}/vrati/{idKnjiga}")]
        public IActionResult VratiKnjigu(long idPozajmica, long idKnjiga)
        {
            try
            {
                _kontroler.VratiKnjigu(idPozajmica, idKnjiga);
                return Ok(new { signal = true, poruka = "Knjiga je uspešno vraćena." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { signal = false, poruka = ex.Message });
            }
        }

        /// <summary>
        /// SK3b — Izmeni rok pozajmice za sve aktivne stavke.
        /// PUT /api/pozajmica/{id}/rok
        /// Body: { "noviRok": "2026-04-15" }
        /// </summary>
        [HttpPut("{id}/rok")]
        public IActionResult IzmeniRok(long id, [FromBody] RokRequest request)
        {
            try
            {
                _kontroler.IzmeniRokPozajmice(id, request.NoviRok);
                return Ok(new { signal = true, poruka = "Rok pozajmice je uspešno izmenjen." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { signal = false, poruka = ex.Message });
            }
        }
    }

    /// <summary>DTO za izmenu roka pozajmice.</summary>
    public class RokRequest
    {
        public DateTime NoviRok { get; set; }
    }
}
