using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MxcEventsBackEnd.Models;
using Newtonsoft.Json;

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
        
        // POST: api/MEvents
        [HttpPost]
        public async Task<ActionResult<MEvent>> PostMEvent(MEventBase mEventBase)
        {
            MEvent mEvent = new MEvent(mEventBase);
            _context.MEvents.Add(mEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMEvents", new { id = mEvent.Id }, mEvent);
        }
        

        // PUT: api/MEvents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMEvent(Guid id, MEvent mEvent)
        {
            Console.WriteLine(JsonConvert.SerializeObject(mEvent));
            if (id != mEvent.Id)
            {
                Console.WriteLine(id);
                Console.WriteLine(Convert.ToString(mEvent.Id));

                return BadRequest();
            }

            Console.WriteLine(JsonConvert.SerializeObject(_context.Entry(mEvent)));

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

        private bool MEventExists(Guid id)
        {
            return _context.MEvents.Any(e => e.Id == id);
        }
    }
}
