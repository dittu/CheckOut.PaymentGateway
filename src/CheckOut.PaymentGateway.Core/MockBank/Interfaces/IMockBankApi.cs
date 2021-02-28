using CheckOut.PaymentGateway.Core.MockBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.PaymentGateway.Core.MockBank.Interfaces
{
    public interface IMockBankApi
    {
        public MockBankResponse RequestPayment(MockBankPaymentRequest request);
    }
}
