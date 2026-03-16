using Domeni;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekAPI.Controllers
{
    /// <summary>
    /// Autentifikacija bibliotekara.
    /// Zamenjuje TCP socket logiku iz ClientHandler-a za operaciju PrijaviBibliotekar.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly Kontroler _kontroler;

        public AuthController(Kontroler kontroler)
        {
            _kontroler = kontroler;
        }

        /// <summary>
        /// SK9 — Prijava bibliotekara.
        /// POST /api/auth/login
        /// Body: { "username": "...", "password": "..." }
        /// </summary>
        [HttpPost("login")]
        public IActionResult Login([FromBody] Bibliotekar bibliotekar)
        {
            try
            {
                Bibliotekar ulogovan = _kontroler.PrijaviBibliotekara(bibliotekar);

                // Čuvamo ID u sesiji (kao što je ClientHandler čuvao referencu)
                HttpContext.Session.SetString("bibliotekarId", ulogovan.Id.ToString());
                HttpContext.Session.SetString("bibliotekarIme", ulogovan.ImePrezime);

                return Ok(new
                {
                    signal = true,
                    poruka = "Prijava uspešna.",
                    podaci = new { ulogovan.Id, ulogovan.Ime, ulogovan.Prezime, ulogovan.Username }
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { signal = false, poruka = ex.Message });
            }
        }

        /// <summary>
        /// Odjava bibliotekara.
        /// POST /api/auth/logout
        /// </summary>
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            string? idStr = HttpContext.Session.GetString("bibliotekarId");
            if (long.TryParse(idStr, out long id))
                _kontroler.OdjaviSe(id);

            HttpContext.Session.Clear();
            return Ok(new { signal = true, poruka = "Odjava uspešna." });
        }

        /// <summary>
        /// Provjera da li je bibliotekar prijavljen.
        /// GET /api/auth/status
        /// </summary>
        [HttpGet("status")]
        public IActionResult Status()
        {
            string? idStr = HttpContext.Session.GetString("bibliotekarId");
            string? ime = HttpContext.Session.GetString("bibliotekarIme");

            if (string.IsNullOrEmpty(idStr))
                return Ok(new { ulogovan = false });

            return Ok(new { ulogovan = true, ime });
        }
    }
}
