using CheckOut.PaymentGateway.WebApi.Models;

namespace UnitTests.Helpers
{
    public class FakeCardData
    {
        public static CardDetails FakeValidVisaCard()
        {
            return new CardDetails()
            {
                HolderName = "Fake Valid Visa",
                CardNumber = "4613976229878",
                Cvv = "456",
                ExpiryMonth = 12,
                ExpiryYear = 2023
            };
        }

        public static CardDetails FakeValidMasterCard()
        {
            return new CardDetails()
            {
                HolderName = "Fake Valid Master",
                CardNumber = "2535556134706580",
                Cvv = "852",
                ExpiryMonth = 07,
                ExpiryYear = 2022
            };
        }
    }
}
