using Domeni;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekAPI.Controllers
{
    /// <summary>
    /// Operacije nad smenama bibliotekara.
    /// Zamenjuje TCP case-ove: PretraziSmene, DodajSmenu, IzmeniSmenu, VratiSveTermine
    /// iz ClientHandler-a.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SmenaController : ControllerBase
    {
        private readonly Kontroler _kontroler;

        public SmenaController(Kontroler kontroler)
        {
            _kontroler = kontroler;
        }

        /// <summary>
        /// Pretraži smene.
        /// GET /api/smena               → sve smene
        /// GET /api/smena?q=Iva         → filtrirano po imenu/prezimenu bibliotekara
        /// </summary>
        [HttpGet]
        public IActionResult GetAll([FromQuery] string q = "")
        {
            try
            {
                List<BibSmena> smene = _kontroler.PretraziSmene(q);
                return Ok(new { signal = true, podaci = smene });
            }
            catch (Exception ex)
            {
                return BadRequest(new { signal = false, poruka = ex.Message });
            }
        }

        /// <summary>
        /// Dodaj novu smenu.
        /// POST /api/smena
        /// Body: { "idBibliotekara": 1, "idTerminSmene": 16, "datum": "2026-03-20" }
        /// </summary>
        [HttpPost]
        public IActionResult Add([FromBody] BibSmena smena)
        {
            try
            {
                _kontroler.DodajSmenu(smena);
                return Ok(new { signal = true, poruka = "Smena je uspešno dodata." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { signal = false, poruka = ex.Message });
            }
        }

        /// <summary>
        /// Izmeni postojeću smenu.
        /// PUT /api/smena
        /// Body: { "stara": { ... }, "nova": { ... } }
        /// </summary>
        [HttpPut]
        public IActionResult Update([FromBody] SmenaUpdateRequest request)
        {
            try
            {
                _kontroler.IzmeniSmenu(request.Stara, request.Nova);
                return Ok(new { signal = true, poruka = "Smena je uspešno izmenjena." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { signal = false, poruka = ex.Message });
            }
        }

        /// <summary>
        /// Učitaj sve dostupne termine smena.
        /// GET /api/smena/termini
        /// </summary>
        [HttpGet("termini")]
        public IActionResult GetTermini()
        {
            try
            {
                List<TerminSmene> termini = _kontroler.VratiSveTermine();
                return Ok(new { signal = true, podaci = termini });
            }
            catch (Exception ex)
            {
                return BadRequest(new { signal = false, poruka = ex.Message });
            }
        }
    }

    /// <summary>DTO za izmenu smene (stara + nova).</summary>
    public class SmenaUpdateRequest
    {
        public BibSmena Stara { get; set; } = null!;
        public BibSmena Nova { get; set; } = null!;
    }
}
