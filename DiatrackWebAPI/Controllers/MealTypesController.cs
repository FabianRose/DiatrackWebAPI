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
    public class MealTypesController : ControllerBase
    {
        private readonly DiatrackAPIDBContext _context;

        public MealTypesController(DiatrackAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/MealTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealTypes>>> GetMealTypes()
        {
            return await _context.MealTypes.ToListAsync();
        }

        // GET: api/MealTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MealTypes>> GetMealTypes(string id)
        {
            var mealTypes = await _context.MealTypes.FindAsync(id);

            if (mealTypes == null)
            {
                return NotFound();
            }

            return mealTypes;
        }

        // PUT: api/MealTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMealTypes(string id, MealTypes mealTypes)
        {
            if (id != mealTypes.MealTypeId)
            {
                return BadRequest();
            }

            _context.Entry(mealTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealTypesExists(id))
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

        // POST: api/MealTypes
        [HttpPost]
        public async Task<ActionResult<MealTypes>> PostMealTypes(MealTypes mealTypes)
        {
            _context.MealTypes.Add(mealTypes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MealTypesExists(mealTypes.MealTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMealTypes", new { id = mealTypes.MealTypeId }, mealTypes);
        }

        // DELETE: api/MealTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MealTypes>> DeleteMealTypes(string id)
        {
            var mealTypes = await _context.MealTypes.FindAsync(id);
            if (mealTypes == null)
            {
                return NotFound();
            }

            _context.MealTypes.Remove(mealTypes);
            await _context.SaveChangesAsync();

            return mealTypes;
        }

        private bool MealTypesExists(string id)
        {
            return _context.MealTypes.Any(e => e.MealTypeId == id);
        }
    }
}
