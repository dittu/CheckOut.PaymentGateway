using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using CheckOut.PaymentGateway.Core.DBRepo.Interfaces;
using CheckOut.PaymentGateway.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOut.PaymentGateway.Core.DBRepo.Models
{
    public class PaymentEntry : IDynamoSerialiser<PaymentEntry>
    {
        public string CardNumber { get; set; }

        public int ExpiryMonth { get; set; }

        public int ExpiryYear { get; set; }

        public int Cvv { get; set; }

        public CurrencyCode Currency { get; set; }

        public decimal Amount { get; set; }

        public string Identifier { get; set; }

        public string MerchantId { get; set; }

        public DateTime RequestDateTime { get; set; }

        public PaymentStatus Status { get; set; }

        public PaymentEntry ConvertToObject(Dictionary<string, AttributeValue> attributeMap)
        {
            throw new NotImplementedException();
        }

        public Document ToDynamoDocument()
        {
            throw new NotImplementedException();
        }
    }
}
