using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOut.PaymentGateway.Core.DBRepo.Interfaces
{
    public interface IDynamoSerialiser<T>
    {
        Document ToDynamoDocument();

        T ConvertToObject(Dictionary<string, AttributeValue> attributeMap);


    }
}
