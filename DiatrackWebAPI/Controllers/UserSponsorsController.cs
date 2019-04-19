using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiatrackWebAPI.Model;

namespace DiatrackWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSponsorsController : ControllerBase
    {
        private readonly DiatrackAPIDBContext _context;

        public UserSponsorsController(DiatrackAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/UserSponsors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSponsor>>> GetUserSponsor()
        {
            return await _context.UserSponsor.ToListAsync();
        }

        // GET: api/UserSponsors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserSponsor>> GetUserSponsor(int id)
        {
            var userSponsor = await _context.UserSponsor.FindAsync(id);

            if (userSponsor == null)
            {
                return NotFound();
            }

            return userSponsor;
        }

        // PUT: api/UserSponsors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserSponsor(int id, UserSponsor userSponsor)
        {
            if (id != userSponsor.SponsorId)
            {
                return BadRequest();
            }

            _context.Entry(userSponsor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSponsorExists(id))
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

        // POST: api/UserSponsors
        [HttpPost]
        public async Task<ActionResult<UserSponsor>> PostUserSponsor(UserSponsor userSponsor)
        {
            _context.UserSponsor.Add(userSponsor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserSponsorExists(userSponsor.SponsorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserSponsor", new { id = userSponsor.SponsorId }, userSponsor);
        }

        // DELETE: api/UserSponsors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserSponsor>> DeleteUserSponsor(int id)
        {
            var userSponsor = await _context.UserSponsor.FindAsync(id);
            if (userSponsor == null)
            {
                return NotFound();
            }

            _context.UserSponsor.Remove(userSponsor);
            await _context.SaveChangesAsync();

            return userSponsor;
        }

        private bool UserSponsorExists(int id)
        {
            return _context.UserSponsor.Any(e => e.SponsorId == id);
        }
    }
}
