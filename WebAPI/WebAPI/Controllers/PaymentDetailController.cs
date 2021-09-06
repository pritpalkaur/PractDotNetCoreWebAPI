using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly AuthenticationContext _context;
        private readonly IPaymentDetailRepository repository;
        public PaymentDetailController(AuthenticationContext context, IPaymentDetailRepository repository)
        {
            this.repository = repository;
            _context = context;
        }

        // GET: api/PaymentDetail
        [HttpGet]
        public async Task<IEnumerable<PaymentDetail>> GetPaymentDetails()
        {
            var PaymentDetail = await repository.GetPaymentDetailAsync();
            return PaymentDetail;
        }


        // PUT: api/PaymentDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDetail(int id, PaymentDetail paymentDetail)
        {
            if (id != paymentDetail.PMId)
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

        // GET: api/PaymentDetail/5
        [HttpGet("{id}")]
        //[Authorize(Roles = "Customer")]
        //[Route("ForCustomer")]
        public IList<PaymentDetail> GetPaymentDetail(int id)
        {
            IList<PaymentDetail> listPaymentDestails;
            try
            {
                listPaymentDestails = repository.GetPaymentDetailAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listPaymentDestails;
        }

        // POST: api/PaymentDetail
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        //[Route("ForAdmin")]
        public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail paymentDetail)
        {
            _context.PaymentDetails.Add(paymentDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentDetail", new { id = paymentDetail.PMId }, paymentDetail);
        }

        // DELETE: api/PaymentDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentDetail>> DeletePaymentDetail(int id)
        {
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            _context.PaymentDetails.Remove(paymentDetail);
            await _context.SaveChangesAsync();

            return paymentDetail;
        }

        private bool PaymentDetailExists(int id)
        {
            return _context.PaymentDetails.Any(e => e.PMId == id);
        }
    }
}