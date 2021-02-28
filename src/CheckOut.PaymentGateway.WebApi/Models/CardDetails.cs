using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOut.PaymentGateway.WebApi.Models
{
    public class CardDetails
    {
        [Required]
        public string CardNumber { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Invalid Month")]
        public int ExpiryMonth { get; set; }

        [Required]
        [Range(2021, 2099, ErrorMessage = "Invalid Year")]
        public int ExpiryYear { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string Cvv { get; set; }
    }
}
