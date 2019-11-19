using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CriAdmin.Models;

namespace CriAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriQnsController : ControllerBase
    {
        private readonly CriQnContext _context;

        public CriQnsController(CriQnContext context)
        {
            _context = context;
        }

        // GET: api/CriQns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CriQn>>> GetCriQn()
        {
            return await _context.CriQn.ToListAsync();
        }

        [HttpGet]
        [Route("countries")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return await _context.Country.ToListAsync();
        }

        [HttpGet]
        [Route("tiers")]
        public async Task<ActionResult<IEnumerable<Tier>>> GetTiers()
        {
            return await _context.Tier.ToListAsync();
        }

        // GET: api/CriQns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CriQn>> GetCriQn(int id)
        {
            var criQn = await _context.CriQn.FindAsync(id);

            if (criQn == null)
            {
                return NotFound();
            }

            return criQn;
        }

        // PUT: api/CriQns/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCriQn(int id, CriQn criQn)
        {
            if (id != criQn.QnId)
            {
                return BadRequest();
            }

            _context.Entry(criQn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CriQnExists(id))
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

        // POST: api/CriQns
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CriQn>> PostCriQn(CriQn criQn)
        {
            criQn.ModifiedDate = DateTime.Now;
            criQn = ParseWeight(criQn);
            try
            {
                _context.CriQn.Add(criQn);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
           

            return CreatedAtAction("GetCriQn", new { id = criQn.QnId }, criQn);
        }

        private CriQn ParseWeight(CriQn criQn)
        {
            var Opt1Split = criQn.Opt1.Split(',');
            criQn.Opt1 = Opt1Split[0];
            criQn.Weight1 = Convert.ToInt32(Opt1Split[1]);

            var Opt2Split = criQn.Opt2.Split(',');
            criQn.Opt2 = Opt2Split[0];
            criQn.Weight2 = Convert.ToInt32(Opt2Split[1]);

            var Opt3Split = criQn.Opt3.Split(',');
            criQn.Opt3 = Opt3Split[0];
            criQn.Weight3 = Convert.ToInt32(Opt3Split[1]);

            var Opt4Split = criQn.Opt4.Split(',');
            criQn.Opt4 = Opt4Split[0];
            criQn.Weight4 = Convert.ToInt32(Opt4Split[1]);

            return criQn;
        }

        // DELETE: api/CriQns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CriQn>> DeleteCriQn(int id)
        {
            var criQn = await _context.CriQn.FindAsync(id);
            if (criQn == null)
            {
                return NotFound();
            }

            _context.CriQn.Remove(criQn);
            await _context.SaveChangesAsync();

            return criQn;
        }

        private bool CriQnExists(int id)
        {
            return _context.CriQn.Any(e => e.QnId == id);
        }
    }
}
