using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOut.PaymentGateway.WebApi.Models
{
    public class GetPaymentDetailsRequest
    {
        public Guid PaymentIdentifier { get; set; }
    }
}
