using Domeni;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly Kontroler _kontroler;

        public AuthController(Kontroler kontroler)
        {
            _kontroler = kontroler;
        }

        // DTO — jednostavan objekat bez validacije, samo za prijem podataka
        public class LoginRequest
        {
            public string Username { get; set; } = "";
            public string Password { get; set; } = "";
        }

        /// <summary>
        /// SK9 — Prijava bibliotekara.
        /// POST /api/auth/login
        /// </summary>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { signal = false, poruka = "Unesite korisničko ime i lozinku." });
            }

            try
            {
                // Kreiramo Bibliotekar objekat tek ovde, nakon validacije
                var bibliotekar = new Bibliotekar
                {
                    Username = request.Username,
                    Password = request.Password
                };

                Bibliotekar ulogovan = _kontroler.PrijaviBibliotekara(bibliotekar);

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
                return Ok(new { signal = false, poruka = ex.Message });
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