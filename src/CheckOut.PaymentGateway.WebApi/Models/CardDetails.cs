using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOut.PaymentGateway.WebApi.Models
{
    public class CardDetails
    {
        public string HolderName { get; set; }
        public string CardNumber { get; set; }

        public int ExpiryMonth { get; set; }

        public int ExpiryYear { get; set; }

        public string Cvv { get; set; }
    }
}
