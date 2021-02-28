using CheckOut.PaymentGateway.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOut.PaymentGateway.WebApi.Models
{
    public class CreatePaymentResponse
    {
        public string Identifier { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
