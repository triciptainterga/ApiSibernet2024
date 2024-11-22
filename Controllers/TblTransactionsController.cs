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
    public class TblTransactionsController : ControllerBase
    {
        private readonly mixradius_radDBContext _context;

        public TblTransactionsController(mixradius_radDBContext context)
        {
            _context = context;
        }

        // GET: api/TblTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblTransactionResponse>>> GetTblTransactions()
        {
            return await _context.TblTransactions.ToListAsync();
        }
        [HttpGet("GetTblTransactionsByUserName")]
        public async Task<ActionResult<IEnumerable<TblTransactionResponse>>> GetTblTransactionsByUserName(string username)
        {
            return await _context.TblTransactions.Where(x => x.Username == username).ToListAsync();
        }

        // GET: api/TblTransactions/5
        [HttpGet("type/{type}")]
        public async Task<ActionResult<IEnumerable<TblTransactionResponse>>> GetTblTransactionsByTpe(string  type)
        {
            var tblTransaction = await _context.TblTransactions.Where(x => x.Type == type).ToListAsync();

            if (tblTransaction == null)
            {
                return StatusCode(404,NotFound());
            }

            return tblTransaction;
        }

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

        // PUT: api/TblTransactions/5
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

        // POST: api/TblTransactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblTransactionResponse>> PostTblTransaction(TblTransactionResponse tblTransaction)
        {
            _context.TblTransactions.Add(tblTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblTransaction", new { id = tblTransaction.Id }, tblTransaction);
        }

        // DELETE: api/TblTransactions/5
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
