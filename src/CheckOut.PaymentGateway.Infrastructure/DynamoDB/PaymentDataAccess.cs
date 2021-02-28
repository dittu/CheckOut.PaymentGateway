using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using CheckOut.PaymentGateway.Core.Interfaces;
using CheckOut.PaymentGateway.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckOut.PaymentGateway.Infrastructure.Database.Convertors;

namespace CheckOut.PaymentGateway.Infrastructure.DynamoDB
{
    public class PaymentDataAccess : IPaymentDataAccess
    {
        public IAmazonDynamoDB _dynamoDB;
        public ITableConfig _paymentConfig;

        public PaymentDataAccess(IAmazonDynamoDB dynamoDB, ITableConfig paymentConfig)
        {
            _dynamoDB = dynamoDB;
            _paymentConfig = paymentConfig;
        }

        public async Task<BaseResult> AddPayment(PaymentEntry paymentEntry)
        {
            BaseResult res = new BaseResult();

            PutItemRequest putRequest = new PutItemRequest
            {
                TableName = _paymentConfig.TableName,
                Item = paymentEntry.ConvertToDynamoDocument().ToAttributeMap()
            };


            var response = await _dynamoDB.PutItemAsync(putRequest);

            //TODO: When usage increases make a common extension method to determine success of dynamoresponse consumer
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                res.Success = true;
            else
                res.Success = false;

            res.Message = $"DynamoDB Response HttpStatusCode: {response.HttpStatusCode}";

            return res;

        }

        public async Task<GetPaymentEntryResult> GetPaymentEntry(string paymentIdentifier)
        {
            GetPaymentEntryResult res = new GetPaymentEntryResult();

            QueryRequest request = new QueryRequest
            {
                TableName = _paymentConfig.TableName,
                KeyConditions = new Dictionary<string, Condition> {
                    {
                      _paymentConfig.HashKey.ColumnName,
                        new Condition {
                            ComparisonOperator = ComparisonOperator.EQ,
                            AttributeValueList = new List<AttributeValue> { new AttributeValue { S = paymentIdentifier } }
                        }

                    }

                },
            };

            var queryResponse = await _dynamoDB.QueryAsync(request);

            if (queryResponse.HttpStatusCode == System.Net.HttpStatusCode.OK)
                res.Success = true;
                if (queryResponse.Items.Count > 0)
                    res.PaymentEntry = PaymentEntryExtensions.ConvertToPaymentEntry(queryResponse.Items.First());

            res.Message = $"DynamoDB Response HttpStatusCode: {queryResponse.HttpStatusCode}. ItemCount: {queryResponse.Items.Count}";

            return res;
        }
    }
}
