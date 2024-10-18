using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_TP3.Models.DataManager;
using WebAPI_TP3.Models.EntityFramework;
using WebAPI_TP3.Models.Repository;

namespace WebAPI_TP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        private readonly IDataRepository<Utilisateur> _repository;
        //private readonly PostgresContext _context;

        public UtilisateursController(IDataRepository<Utilisateur> repository)
        {
            _repository = repository;
        }

        // GET: api/Utilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUtilisateurs()
        {
            return Ok(await _repository.GetAllAsync());
        }

        // GET: api/Utilisateurs/5
        [HttpGet]
        [Route("[Action]/{id}")]
        public async Task<ActionResult<Utilisateur>> GetUtilisateurById(int id)
        {
            var utilisateur = await  _repository.GetByIdAsync(id);

            if (utilisateur == null)
            {
                return NotFound("Id utilisateur inconnu");
            }

            return utilisateur;
        }

        [HttpGet]
        [Route("[Action]/{email}")]
        public async Task<ActionResult<Utilisateur>> GetUtilisateurByEmail(string email)
        {
            var utilisateur = await _repository.GetByStringAsync(email);
            if (utilisateur == null)
            {
                return NotFound("Email de l'utilisateur inconnu");
            }

            return utilisateur;
        }

        // PUT: api/Utilisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
        {
            if (id != utilisateur.UtilisateurId)
            {
                return BadRequest("id utilisateur inconnu");
            }

            var userToUpdate = await _repository.GetByIdAsync(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await _repository.Update(userToUpdate, utilisateur);
                return NoContent();
            }
        }

        // POST: api/Utilisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Utilisateur>> PostUtilisateur([FromBody] Utilisateur utilisateur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.Add(utilisateur);
            return CreatedAtAction("GetUtilisateurById", new { id = utilisateur.UtilisateurId },
                utilisateur); // GetById : nom de l’action
        }

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilisateur(int id)
        {
            var utilisateur = await _repository.GetByIdAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            await _repository.Delete(utilisateur);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Utilisateur>> Patch(int id, [FromBody] Utilisateur utilisateur)
        {
            var utilisateurToPatch = await _repository.GetByIdAsync(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != utilisateur.UtilisateurId)
            {
                return BadRequest();
            }
            if (utilisateurToPatch == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _repository.Update(utilisateurToPatch, utilisateur);
            return utilisateur;
        }

        //private bool UtilisateurExists(int id)
        //{
        //    return _context.Utilisateurs.Any(e => e.UtilisateurId == id);
        //}
    }
}
