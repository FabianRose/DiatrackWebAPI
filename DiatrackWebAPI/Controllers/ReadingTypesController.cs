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
    public class ReadingTypesController : ControllerBase
    {
        private readonly DiatrackAPIDBContext _context;

        public ReadingTypesController(DiatrackAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/ReadingTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadingTypes>>> GetReadingTypes()
        {
            return await _context.ReadingTypes.ToListAsync();
        }

        // GET: api/ReadingTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadingTypes>> GetReadingTypes(string id)
        {
            var readingTypes = await _context.ReadingTypes.FindAsync(id);

            if (readingTypes == null)
            {
                return NotFound();
            }

            return readingTypes;
        }

        // PUT: api/ReadingTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReadingTypes(string id, ReadingTypes readingTypes)
        {
            if (id != readingTypes.ReadingTypeId)
            {
                return BadRequest();
            }

            _context.Entry(readingTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReadingTypesExists(id))
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

        // POST: api/ReadingTypes
        [HttpPost]
        public async Task<ActionResult<ReadingTypes>> PostReadingTypes(ReadingTypes readingTypes)
        {
            _context.ReadingTypes.Add(readingTypes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReadingTypesExists(readingTypes.ReadingTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReadingTypes", new { id = readingTypes.ReadingTypeId }, readingTypes);
        }

        // DELETE: api/ReadingTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReadingTypes>> DeleteReadingTypes(string id)
        {
            var readingTypes = await _context.ReadingTypes.FindAsync(id);
            if (readingTypes == null)
            {
                return NotFound();
            }

            _context.ReadingTypes.Remove(readingTypes);
            await _context.SaveChangesAsync();

            return readingTypes;
        }

        private bool ReadingTypesExists(string id)
        {
            return _context.ReadingTypes.Any(e => e.ReadingTypeId == id);
        }
    }
}
