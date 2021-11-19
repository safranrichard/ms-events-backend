using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MxcEventsBackEnd.Models;

namespace MxcEventsBackEnd.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MEventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MEvent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> GetMEvents()
        {
            var response = await _context.MEvents.Select(item => new { item.Name, item.Location, item.Capacity, item.Id, item.CreationDate}) //Hide Country Column
                                                 .OrderBy(item => item.Name)
                                                 .ThenBy(item => item.CreationDate)
                                                 .ToListAsync();

            return response;
        }

        // POST: api/MEvent
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MEvent>> PostMEvent(MEvent mEvent)
        {
            mEvent.SetId();
            mEvent.SetCreationDate();

            _context.MEvents.Add(mEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMEvents", new { id = mEvent.Id }, mEvent);
        }

        /*
         
         */

        /*
        // GET: api/MEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MEvent>> GetMEvent(Guid id)
        {
            var mEvent = await _context.MEvents.FindAsync(id);

            if (mEvent == null)
            {
                return NotFound();
            }

            return mEvent;
        }

        // PUT: api/MEvents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMEvent(Guid id, MEvent mEvent)
        {
            if (id != mEvent.Id)
            {
                return BadRequest();
            }

            _context.Entry(mEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MEventExists(id))
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

        // POST: api/MEvents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MEvent>> PostMEvent(MEvent mEvent)
        {
            _context.MEvents.Add(mEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMEvent", new { id = mEvent.Id }, mEvent);
        }

        // DELETE: api/MEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMEvent(Guid id)
        {
            var mEvent = await _context.MEvents.FindAsync(id);
            if (mEvent == null)
            {
                return NotFound();
            }

            _context.MEvents.Remove(mEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MEventExists(Guid id)
        {
            return _context.MEvents.Any(e => e.Id == id);
        }*/
    }
}
