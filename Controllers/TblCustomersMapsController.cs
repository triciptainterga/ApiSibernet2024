using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiReport.Models;

namespace WebApiReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblCustomersMapsController : ControllerBase
    {
        private readonly mixradius_radDBContext _context;

        public TblCustomersMapsController(mixradius_radDBContext context)
        {
            _context = context;
        }

        // GET: api/TblCustomersMaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCustomersMap>>> GetTblCustomersMaps()
        {
            return await _context.TblCustomersMaps.ToListAsync();
        }

        // GET: api/TblCustomersMaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCustomersMap>> GetTblCustomersMap(int id)
        {
            var tblCustomersMap = await _context.TblCustomersMaps.FindAsync(id);

            if (tblCustomersMap == null)
            {
                return NotFound();
            }

            return tblCustomersMap;
        }
        [HttpGet("GetTblCustomersMapByCustomerId")]
        public async Task<ActionResult<TblCustomersMap>> GetTblCustomersMapByCustomerId(int CustomerId)
        {
            var tblCustomersMap = await _context.TblCustomersMaps.FindAsync(CustomerId);

            if (tblCustomersMap == null)
            {
                return NotFound();
            }

            return tblCustomersMap;
        }

        // PUT: api/TblCustomersMaps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCustomersMap(int id, TblCustomersMap tblCustomersMap)
        {
            if (id != tblCustomersMap.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblCustomersMap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCustomersMapExists(id))
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

        // POST: api/TblCustomersMaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCustomersMap>> PostTblCustomersMap(TblCustomersMap tblCustomersMap)
        {
            _context.TblCustomersMaps.Add(tblCustomersMap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCustomersMap", new { id = tblCustomersMap.Id }, tblCustomersMap);
        }

        // DELETE: api/TblCustomersMaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCustomersMap(int id)
        {
            var tblCustomersMap = await _context.TblCustomersMaps.FindAsync(id);
            if (tblCustomersMap == null)
            {
                return NotFound();
            }

            _context.TblCustomersMaps.Remove(tblCustomersMap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblCustomersMapExists(int id)
        {
            return _context.TblCustomersMaps.Any(e => e.Id == id);
        }
    }
}
