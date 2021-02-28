using Amazon.DynamoDBv2;
using CheckOut.PaymentGateway.Core.Interfaces;
using CheckOut.PaymentGateway.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOut.PaymentGateway.Infrastructure.Database.Config
{
    public class PaymentTableConfig : ITableConfig
    {
        private string _tableName;
        private KeyDetails _hashKey;
        private KeyDetails _rangeKey;

        public PaymentTableConfig()
        {
            _tableName = "Payments";
            _hashKey = new KeyDetails()
            {
                AttributeType = ScalarAttributeType.S,
                ColumnName = "Identifier"
            };
            _rangeKey = null;

        }

        public string TableName { get { return _tableName; } }
        public KeyDetails HashKey { get { return _hashKey; } }
        public KeyDetails RangeKey { get { return _rangeKey; } }
    }
}
