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
    public class TblTransactions1Controller : ControllerBase
    {
        private readonly mixradius_radDBContext _context;

        public TblTransactions1Controller(mixradius_radDBContext context)
        {
            _context = context;
        }

        // GET: api/TblTransactions1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblTransactionResponse>>> GetTblTransactions()
        {
            return await _context.TblTransactions.ToListAsync();
        }

        // GET: api/TblTransactions1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblTransactionResponse>> GetTblTransaction(int id)
        {
            var tblTransaction = await _context.TblTransactions.FindAsync(id);

            if (tblTransaction == null)
            {
                return NotFound();
            }

            return tblTransaction;
        }

        // PUT: api/TblTransactions1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblTransaction(int id, TblTransactionResponse tblTransaction)
        {
            if (id != tblTransaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTransactionExists(id))
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

        // POST: api/TblTransactions1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblTransactionResponse>> PostTblTransaction(TblTransactionResponse tblTransaction)
        {
            _context.TblTransactions.Add(tblTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblTransaction", new { id = tblTransaction.Id }, tblTransaction);
        }

        // DELETE: api/TblTransactions1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblTransaction(int id)
        {
            var tblTransaction = await _context.TblTransactions.FindAsync(id);
            if (tblTransaction == null)
            {
                return NotFound();
            }

            _context.TblTransactions.Remove(tblTransaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblTransactionExists(int id)
        {
            return _context.TblTransactions.Any(e => e.Id == id);
        }
    }
}
