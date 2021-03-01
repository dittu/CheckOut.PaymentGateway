using CheckOut.PaymentGateway.WebApi.Models;
using CheckOut.PaymentGateway.WebApi.Validators;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Validators
{
    [TestFixture]
    public class CardDetailsValidatorTests
    {
        public CardDetailsValidator CardDetailsValidator { get; set; }

        [SetUp]
        public void Setup()
        {
            CardDetailsValidator = new CardDetailsValidator();
        }

        [Test]
        public void VisaCardTest()
        {
            CardDetails visaCard = new CardDetails() { 
                HolderName= "Visa Card",
                ExpiryMonth = 12,
                ExpiryYear = 2021,
                CardNumber = "4613976229878",
                Cvv = "456"
            };

           var res = CardDetailsValidator.Validate(visaCard);

            Assert.IsTrue(res.IsValid);
        }


        [Test]
        public void MasterCardTest()
        {
            CardDetails masterCard = new CardDetails()
            {
                HolderName = "Master Card",
                ExpiryMonth = 12,
                ExpiryYear = 2021,
                CardNumber = "2486977978816328",
                Cvv = "456"
            };

            var res = CardDetailsValidator.Validate(masterCard);

            Assert.IsTrue(res.IsValid);
        }

        [Test]
        public void ExpiredMonthDateTest()
        {
            CardDetails visaCard = new CardDetails()
            {
                HolderName = "Visa Card",
                ExpiryMonth = 1,
                ExpiryYear = 2021,
                CardNumber = "2486977978816328",
                Cvv = "456"
            };

            var res = CardDetailsValidator.Validate(visaCard);

            Assert.IsFalse(res.IsValid);
        }


        [Test]
        public void ExpiredYearTest()
        {
            CardDetails visaCard = new CardDetails()
            {
                HolderName = "Visa Card",
                ExpiryMonth = 10,
                ExpiryYear = 2020,
                CardNumber = "2486977978816328",
                Cvv = "456"
            };

            var res = CardDetailsValidator.Validate(visaCard);

            Assert.IsFalse(res.IsValid);
        }

        //571072310402
        [Test]
        public void MaestroCard()
        {
            CardDetails maestroCard = new CardDetails()
            {
                HolderName = "Maestro Card",
                ExpiryMonth = 12,
                ExpiryYear = 2021,
                CardNumber = "571072310402",
                Cvv = "456"
            };

            var res = CardDetailsValidator.Validate(maestroCard);

            Assert.IsFalse(res.IsValid);
        }

        [Test]
        public void InValidCardLuhnTest ()
        {
            CardDetails visaCard = new CardDetails()
            {
                HolderName = "Visa Card",
                ExpiryMonth = 12,
                ExpiryYear = 2021,
                CardNumber = "2486977978316328",
                Cvv = "456"
            };

            var res = CardDetailsValidator.Validate(visaCard);

            Assert.IsFalse(res.IsValid);
        }

    }
}
