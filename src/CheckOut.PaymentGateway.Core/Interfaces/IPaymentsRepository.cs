using CheckOut.PaymentGateway.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.PaymentGateway.Core.Interfaces
{
    public interface IPaymentsRepository
    {
        public Task<BaseResult> AddPayment(PaymentEntry paymentEntry);

        public Task<GetPaymentEntryResult> GetPaymentEntry(Guid paymentIdentifier);
    }
}
