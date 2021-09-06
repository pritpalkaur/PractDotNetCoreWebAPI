using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IPaymentDetailRepository
    {
        Task<IEnumerable<PaymentDetail>> GetPaymentDetailAsync();
        IList<PaymentDetail> GetPaymentDetailAsync(int Id);
     }
}
