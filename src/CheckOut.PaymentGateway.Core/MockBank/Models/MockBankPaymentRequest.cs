using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.PaymentGateway.Core.MockBank.Models
{
    public class MockBankPaymentRequest
    {
        public string CardNumber { get; set; }

        public string Cvv { get; set; }

        public int ExpiryYear { get; set; }

        public int ExpiryMonth { get; set; }

        public Decimal Amount { get; set; }

        public string HolderName { get; set; }
        public string CurrencyCode { get; set; }
    }
}
