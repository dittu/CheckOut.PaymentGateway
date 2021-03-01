using CheckOut.PaymentGateway.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Helpers
{
   public class FakeCreatePaymentData
    {
        public static CreatePaymentRequest FakeCreatePaymentRequest()
        {
            return new CreatePaymentRequest() { 
                Amount = 100m,
                CardDetails = FakeCardData.FakeValidVisaCard(),
                Currency = CheckOut.PaymentGateway.Core.Enum.CurrencyCode.EUR,
                Reference = "Sample"
            };
        }
    }
}
