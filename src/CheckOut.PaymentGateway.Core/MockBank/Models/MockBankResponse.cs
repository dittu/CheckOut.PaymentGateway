using CheckOut.PaymentGateway.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.PaymentGateway.Core.MockBank.Models
{
    public class MockBankResponse
    {
        public HttpStatusCode HttpStatus { get; set; }
        public string Identifier { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
