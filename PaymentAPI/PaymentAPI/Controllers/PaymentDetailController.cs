using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly PaymentDetailContext _context;

        public PaymentDetailController(PaymentDetailContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetail()
        {
          if (_context.PaymentDetail == null)
          {
              return NotFound();
          }
            return await _context.PaymentDetail.ToListAsync();
        }

        // GET: api/PaymentDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
        {
          if (_context.PaymentDetail == null)
          {
              return NotFound();
          }
            var paymentDetail = await _context.PaymentDetail.FindAsync(id);

            if (paymentDetail == null)
            {
                return NotFound();
            }

            return paymentDetail;
        }

        // PUT: api/PaymentDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDetail(int id, PaymentDetail paymentDetail)
        {
            if (id != paymentDetail.PaymentDetailId)
            {
                return BadRequest();
            }

            _context.Entry(paymentDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailExists(id))
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

        // POST: api/PaymentDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail paymentDetail)
        {
          if (_context.PaymentDetail == null)
          {
              return Problem("Entity set 'PaymentDetailContext.PaymentDetail'  is null.");
          }
            _context.PaymentDetail.Add(paymentDetail);
            await _context.SaveChangesAsync();

            return Ok (await _context.PaymentDetail.ToListAsync());
        }

        // DELETE: api/PaymentDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetail(int id)
        {
            if (_context.PaymentDetail == null)
            {
                return NotFound();
            }
            var paymentDetail = await _context.PaymentDetail.FindAsync(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            _context.PaymentDetail.Remove(paymentDetail);
            await _context.SaveChangesAsync();

            return Ok(await _context.PaymentDetail.ToListAsync());
        }

        private bool PaymentDetailExists(int id)
        {
            return (_context.PaymentDetail?.Any(e => e.PaymentDetailId == id)).GetValueOrDefault();
        }
    }
}
