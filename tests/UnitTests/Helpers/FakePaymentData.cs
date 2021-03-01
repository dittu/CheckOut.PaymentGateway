using CheckOut.PaymentGateway.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Helpers
{
    public class FakePaymentData
    {
        public static PaymentEntry FakePaymentEntryData()
        {
            return new PaymentEntry() { 
                Amount = 100m,
                BankIdentifier = "Bank Identifier",
                BankStatus = CheckOut.PaymentGateway.Core.Enum.PaymentStatus.Authorized,
                CardNumber = "1234586454654546",
                Currency = CheckOut.PaymentGateway.Core.Enum.CurrencyCode.EUR,
                Cvv = "256",
                ExpiryMonth = 12,
                ExpiryYear =2022,
                HolderName = "Fake Payment Data",
                Identifier =Guid.NewGuid(),
                MerchantId = "ajjsdlk",
                RefText = "Ref Text",
                RequestDateTime = DateTime.UtcNow,
                Status = CheckOut.PaymentGateway.Core.Enum.PaymentStatus.Authorized
            };

        }
    }
}
