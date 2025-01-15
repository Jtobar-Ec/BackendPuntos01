using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuntosRecompensasAPI.Data;

namespace PuntosRecompensasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuntosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PuntosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Puntos
        [HttpGet("getPuntosUsuario")]
        public async Task<ActionResult<IEnumerable<object>>> GetPuntos()
        {
            // Devuelve todos los usuarios con sus puntos
            var puntos = await _context.TfaUsers
                .Select(u => new { u.UsersId, u.UserName, u.UserPoints })
                .ToListAsync();

            return Ok(puntos);
        }

        // GET: api/Puntos/5
        [HttpGet("getPuntosUsuarioById/{id}")]
        public async Task<ActionResult<object>> GetPuntos(int id)
        {
            var user = await _context.TfaUsers
                .Where(u => u.UsersId == id)
                .Select(u => new { u.UsersId, u.UserName, u.UserPoints })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Puntos/5
        [HttpPut("updatePuntosUsuario/{id}")]
        public async Task<IActionResult> UpdatePuntos(int id, int puntos)
        {
            if (puntos < 0)
            {
                return BadRequest("Los puntos no pueden ser negativos.");
            }

            var user = await _context.TfaUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.UserPoints = puntos;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Puntos
        [HttpPost("addPuntosUsuario")]
        public async Task<ActionResult<object>> PostPuntos(int id, int puntos)
        {
            if (puntos < 0)
            {
                return BadRequest("Los puntos no pueden ser negativos.");
            }

            var user = await _context.TfaUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.UserPoints += puntos;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetPuntos), new { id = user.UsersId }, new { user.UsersId, user.UserName, user.UserPoints });
        }

        private bool UserExists(int id)
        {
            return _context.TfaUsers.Any(e => e.UsersId == id);
        }
    }
}
