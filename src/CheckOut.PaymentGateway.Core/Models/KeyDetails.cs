﻿using Amazon.DynamoDBv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.PaymentGateway.Core.Models
{
    public class KeyDetails
    {
        public string ColumnName { get; set; }

        public ScalarAttributeType AttributeType { get; set; }
    }

}
