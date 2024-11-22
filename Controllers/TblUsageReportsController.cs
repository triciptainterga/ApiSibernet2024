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
    public class TblUsageReportsController : ControllerBase
    {
        private readonly mixradius_radDBContext _context;

        public TblUsageReportsController(mixradius_radDBContext context)
        {
            _context = context;
        }

        // GET: api/TblUsageReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUsageReport>>> GetTblUsageReports()
        {
            return await _context.TblUsageReports.Where(x => x.Method == "MEMBER" ).ToListAsync();
        }


        // GET: api/TblUsageReports/5
        [HttpGet("UserName/{username}")]
        public async Task<ActionResult<IEnumerable<TblUsageReport>>> GetTblUsageReportByUserName( string username)
        {
            var tblUsageReport = await _context.TblUsageReports.Where(x => x.Method == "MEMBER"  && x.Username == username).ToListAsync();

            if (tblUsageReport == null)
            {
                return NotFound();
            }

            return tblUsageReport;
        }
        // GET: api/TblUsageReports/5
        [HttpGet("type/{type}")]
        public async Task<ActionResult<IEnumerable<TblUsageReport>>> GetTblUsageReportByType(string type,string username)
        {
            var tblUsageReport = await _context.TblUsageReports.Where(x => x.Method == "MEMBER" && x.Type == type && x.Username == username).ToListAsync();

            if (tblUsageReport == null)
            {
                return NotFound();
            }

            return tblUsageReport;
        }

        // PUT: api/TblUsageReports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblUsageReport(int id, TblUsageReport tblUsageReport)
        {
            if (id != tblUsageReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblUsageReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUsageReportExists(id))
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

        // POST: api/TblUsageReports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblUsageReport>> PostTblUsageReport(TblUsageReport tblUsageReport)
        {
            _context.TblUsageReports.Add(tblUsageReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblUsageReport", new { id = tblUsageReport.Id }, tblUsageReport);
        }

        // DELETE: api/TblUsageReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblUsageReport(int id)
        {
            var tblUsageReport = await _context.TblUsageReports.FindAsync(id);
            if (tblUsageReport == null)
            {
                return NotFound();
            }

            _context.TblUsageReports.Remove(tblUsageReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblUsageReportExists(int id)
        {
            return _context.TblUsageReports.Any(e => e.Id == id);
        }
    }
}
