using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mee_Mee.Model;

namespace Mee_Mee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly MeeMeeContext _context;

        public ClientsController(MeeMeeContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clients>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clients>> GetClients(int id)
        {
            var clients = await _context.Clients.FindAsync(id);

            if (clients == null)
            {
                return NotFound();
            }

            return clients;
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClients(int id, Clients clients)
        {
            if (id != clients.ClientId)
            {
                return BadRequest();
            }

            _context.Entry(clients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientsExists(id))
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

        // POST: api/Clients
        [HttpPost]
        public async Task<ActionResult<Clients>> PostClients(Clients clients)
        {
            _context.Clients.Add(clients);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClients", new { id = clients.ClientId }, clients);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clients>> DeleteClients(int id)
        {
            var clients = await _context.Clients.FindAsync(id);
            if (clients == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(clients);
            await _context.SaveChangesAsync();

            return clients;
        }

        private bool ClientsExists(int id)
        {
            return _context.Clients.Any(e => e.ClientId == id);
        }
    }
}
