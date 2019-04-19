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
    public class MealsController : ControllerBase
    {
        private readonly DiatrackAPIDBContext _context;

        public MealsController(DiatrackAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Meals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meals>>> GetMeals()
        {
            return await _context.Meals.ToListAsync();
        }

        // GET: api/Meals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Meals>> GetMeals(int id)
        {
            var meals = await _context.Meals.FindAsync(id);

            if (meals == null)
            {
                return NotFound();
            }

            return meals;
        }

        // PUT: api/Meals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeals(int id, Meals meals)
        {
            if (id != meals.UserId)
            {
                return BadRequest();
            }

            _context.Entry(meals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealsExists(id))
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

        // POST: api/Meals
        [HttpPost]
        public async Task<ActionResult<Meals>> PostMeals(Meals meals)
        {
            _context.Meals.Add(meals);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MealsExists(meals.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMeals", new { id = meals.UserId }, meals);
        }

        // DELETE: api/Meals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Meals>> DeleteMeals(int id)
        {
            var meals = await _context.Meals.FindAsync(id);
            if (meals == null)
            {
                return NotFound();
            }

            _context.Meals.Remove(meals);
            await _context.SaveChangesAsync();

            return meals;
        }

        private bool MealsExists(int id)
        {
            return _context.Meals.Any(e => e.UserId == id);
        }
    }
}
