using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class PaymentDetailRepository : IPaymentDetailRepository
    {
        private readonly AuthenticationContext _context;
        public PaymentDetailRepository(AuthenticationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PaymentDetail>> GetPaymentDetailAsync()
        {
            return await _context.PaymentDetails.ToListAsync();
        }


    }
}
