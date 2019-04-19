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
    public class PatientReadingsController : ControllerBase
    {
        private readonly DiatrackAPIDBContext _context;

        public PatientReadingsController(DiatrackAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/PatientReadings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientReadings>>> GetPatientReadings()
        {
            return await _context.PatientReadings.ToListAsync();
        }

        // GET: api/PatientReadings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientReadings>> GetPatientReadings(int id)
        {
            var patientReadings = await _context.PatientReadings.FindAsync(id);

            if (patientReadings == null)
            {
                return NotFound();
            }

            return patientReadings;
        }

        // PUT: api/PatientReadings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientReadings(int id, PatientReadings patientReadings)
        {
            if (id != patientReadings.PatientId)
            {
                return BadRequest();
            }

            _context.Entry(patientReadings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientReadingsExists(id))
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

        // POST: api/PatientReadings
        [HttpPost]
        public async Task<ActionResult<PatientReadings>> PostPatientReadings(PatientReadings patientReadings)
        {
            _context.PatientReadings.Add(patientReadings);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PatientReadingsExists(patientReadings.PatientId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPatientReadings", new { id = patientReadings.PatientId }, patientReadings);
        }

        // DELETE: api/PatientReadings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PatientReadings>> DeletePatientReadings(int id)
        {
            var patientReadings = await _context.PatientReadings.FindAsync(id);
            if (patientReadings == null)
            {
                return NotFound();
            }

            _context.PatientReadings.Remove(patientReadings);
            await _context.SaveChangesAsync();

            return patientReadings;
        }

        private bool PatientReadingsExists(int id)
        {
            return _context.PatientReadings.Any(e => e.PatientId == id);
        }
    }
}
