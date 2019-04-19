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
    public class ProviderPatientsController : ControllerBase
    {
        private readonly DiatrackAPIDBContext _context;

        public ProviderPatientsController(DiatrackAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/ProviderPatients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProviderPatients>>> GetProviderPatients()
        {
            return await _context.ProviderPatients.ToListAsync();
        }

        // GET: api/ProviderPatients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProviderPatients>> GetProviderPatients(int id)
        {
            var providerPatients = await _context.ProviderPatients.FindAsync(id);

            if (providerPatients == null)
            {
                return NotFound();
            }

            return providerPatients;
        }

        // PUT: api/ProviderPatients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProviderPatients(int id, ProviderPatients providerPatients)
        {
            if (id != providerPatients.ProviderId)
            {
                return BadRequest();
            }

            _context.Entry(providerPatients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProviderPatientsExists(id))
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

        // POST: api/ProviderPatients
        [HttpPost]
        public async Task<ActionResult<ProviderPatients>> PostProviderPatients(ProviderPatients providerPatients)
        {
            _context.ProviderPatients.Add(providerPatients);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProviderPatientsExists(providerPatients.ProviderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProviderPatients", new { id = providerPatients.ProviderId }, providerPatients);
        }

        // DELETE: api/ProviderPatients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProviderPatients>> DeleteProviderPatients(int id)
        {
            var providerPatients = await _context.ProviderPatients.FindAsync(id);
            if (providerPatients == null)
            {
                return NotFound();
            }

            _context.ProviderPatients.Remove(providerPatients);
            await _context.SaveChangesAsync();

            return providerPatients;
        }

        private bool ProviderPatientsExists(int id)
        {
            return _context.ProviderPatients.Any(e => e.ProviderId == id);
        }
    }
}
