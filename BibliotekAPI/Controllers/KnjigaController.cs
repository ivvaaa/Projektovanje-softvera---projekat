using Domeni;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekAPI.Controllers
{
    /// <summary>
    /// CRUD operacije nad knjigama.
    /// Zamenjuje TCP case-ove: UbaciKnjigu, PretraziKnjigu, IzmeniKnjigu, ObrisiKnjigu
    /// iz ClientHandler-a.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class KnjigaController : ControllerBase
    {
        private readonly Kontroler _kontroler;

        public KnjigaController(Kontroler kontroler)
        {
            _kontroler = kontroler;
        }

        /// <summary>
        /// SK10/SK15 — Pretraži knjige.
        /// GET /api/knjiga                  → sve knjige
        /// GET /api/knjiga?q=Tolkien        → filtrirano
        /// </summary>
        [HttpGet]
        public IActionResult GetAll([FromQuery] string q = "")
        {
            try
            {
                List<Knjiga> knjige = _kontroler.PretraziKnjige(q);
                return Ok(new { signal = true, podaci = knjige });
            }
            catch (Exception ex)
            {
                return BadRequest(new { signal = false, poruka = ex.Message });
            }
        }

        /// <summary>
        /// SK14 — Dodaj novu knjigu.
        /// POST /api/knjiga
        /// Body: { "naziv": "...", "imePisca": "...", "prezimePisca": "...", "brojPrimeraka": 3 }
        /// </summary>
        [HttpPost]
        public IActionResult Add([FromBody] Knjiga knjiga)
        {
            try
            {
                _kontroler.UbaciKnjigu(knjiga);
                return Ok(new { signal = true, poruka = "Knjiga je uspešno dodata." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { signal = false, poruka = ex.Message });
            }
        }

        /// <summary>
        /// SK16 — Izmeni podatke o knjizi.
        /// PUT /api/knjiga/{id}
        /// Body: { "id": 1, "naziv": "...", "imePisca": "...", "prezimePisca": "...", "brojPrimeraka": 3 }
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Knjiga knjiga)
        {
            try
            {
                knjiga.Id = id;
                _kontroler.IzmeniKnjigu(knjiga);
                return Ok(new { signal = true, poruka = "Knjiga je uspešno izmenjena." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { signal = false, poruka = ex.Message });
            }
        }

        /// <summary>
        /// SK17 — Obriši knjigu.
        /// DELETE /api/knjiga/{id}
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _kontroler.ObrisiKnjigu(id);
                return Ok(new { signal = true, poruka = "Knjiga je uspešno obrisana." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { signal = false, poruka = ex.Message });
            }
        }
    }
}
