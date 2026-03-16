using Domeni;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekAPI.Controllers
{
    /// <summary>
    /// CRUD operacije nad članovima biblioteke.
    /// Zamenjuje TCP case-ove: KreirajClana, PretraziClana, IzmeniClana, ObrisiClana, VratiSvaClanstva
    /// iz ClientHandler-a.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ClanController : ControllerBase
    {
        private readonly Kontroler _kontroler;

        public ClanController(Kontroler kontroler)
        {
            _kontroler = kontroler;
        }

        /// <summary>
        /// SK6/SK7 — Pretraži članove.
        /// GET /api/clan               → svi članovi
        /// GET /api/clan?q=Petar       → filtrirano po imenu/prezimenu/telefonu/tipu članarine
        /// </summary>
        [HttpGet]
        public IActionResult GetAll([FromQuery] string q = "")
        {
            try
            {
                List<Clan> clanovi = _kontroler.PretraziClanove(q);
                return Ok(new { signal = true, podaci = clanovi });
            }
            catch (Exception ex)
            {
                return BadRequest(new { signal = false, poruka = ex.Message });
            }
        }

        /// <summary>
        /// SK5 — Dodaj novog člana.
        /// POST /api/clan
        /// Body: { "ime": "...", "prezime": "...", "telefon": 123456, "datumOd": "2026-01-01", "datumDo": "2027-01-01", "idClanstva": 1 }
        /// </summary>
        [HttpPost]
        public IActionResult Add([FromBody] Clan clan)
        {
            try
            {
                _kontroler.KreirajClana(clan);
                return Ok(new { signal = true, poruka = "Član je uspešno dodat." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { signal = false, poruka = ex.Message });
            }
        }

        /// <summary>
        /// SK7 — Izmeni podatke o članu.
        /// PUT /api/clan/{id}
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Clan clan)
        {
            try
            {
                clan.Id = id;
                _kontroler.IzmeniClana(clan);
                return Ok(new { signal = true, poruka = "Član je uspešno izmenjen." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { signal = false, poruka = ex.Message });
            }
        }

        /// <summary>
        /// SK8 — Obriši člana.
        /// DELETE /api/clan/{id}
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _kontroler.ObrisiClana(id);
                return Ok(new { signal = true, poruka = "Član je uspešno obrisan." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { signal = false, poruka = ex.Message });
            }
        }

        /// <summary>
        /// Pomoćna — vraća sve tipove članstava (preduslov za formu izmene člana).
        /// GET /api/clan/clanstva
        /// </summary>
        [HttpGet("clanstva")]
        public IActionResult GetClanstva()
        {
            try
            {
                List<Clanstvo> clanstva = _kontroler.VratiSvaClanstva();
                return Ok(new { signal = true, podaci = clanstva });
            }
            catch (Exception ex)
            {
                return BadRequest(new { signal = false, poruka = ex.Message });
            }
        }
    }
}
