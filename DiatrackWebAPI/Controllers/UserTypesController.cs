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
    public class UserTypesController : ControllerBase
    {
        private readonly DiatrackAPIDBContext _context;

        public UserTypesController(DiatrackAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/UserTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTypes>>> GetUserTypes()
        {
            return await _context.UserTypes.ToListAsync();
        }

        // GET: api/UserTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTypes>> GetUserTypes(string id)
        {
            var userTypes = await _context.UserTypes.FindAsync(id);

            if (userTypes == null)
            {
                return NotFound();
            }

            return userTypes;
        }

        // PUT: api/UserTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTypes(string id, UserTypes userTypes)
        {
            if (id != userTypes.UserTypeId)
            {
                return BadRequest();
            }

            _context.Entry(userTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTypesExists(id))
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

        // POST: api/UserTypes
        [HttpPost]
        public async Task<ActionResult<UserTypes>> PostUserTypes(UserTypes userTypes)
        {
            _context.UserTypes.Add(userTypes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserTypesExists(userTypes.UserTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserTypes", new { id = userTypes.UserTypeId }, userTypes);
        }

        // DELETE: api/UserTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserTypes>> DeleteUserTypes(string id)
        {
            var userTypes = await _context.UserTypes.FindAsync(id);
            if (userTypes == null)
            {
                return NotFound();
            }

            _context.UserTypes.Remove(userTypes);
            await _context.SaveChangesAsync();

            return userTypes;
        }

        private bool UserTypesExists(string id)
        {
            return _context.UserTypes.Any(e => e.UserTypeId == id);
        }
    }
}
