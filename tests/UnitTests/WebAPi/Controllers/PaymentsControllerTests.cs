using CheckOut.PaymentGateway.Core.Interfaces;
using CheckOut.PaymentGateway.Core.MockBank.Interfaces;
using CheckOut.PaymentGateway.Core.MockBank.Models;
using CheckOut.PaymentGateway.Core.Models;
using CheckOut.PaymentGateway.WebApi.Controllers;
using CheckOut.PaymentGateway.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Helpers;

namespace UnitTests.WebAPi.Controllers
{
    [TestFixture]
    public class PaymentsControllerTests
    {

        public PaymentsController Controller { get; set; }

        public Mock<IPaymentsRepository> MockPaymentsRepository { get; set; }

        public Mock<IMockBankRepository> MockBankRepository { get; set; }

        public Mock<ILogger<PaymentsController>> MockLogger { get; set; }

        [SetUp]
        public void Setup()
        {
            this.MockPaymentsRepository = new Mock<IPaymentsRepository>();
            this.MockBankRepository = new Mock<IMockBankRepository>();
            this.MockLogger = new Mock<ILogger<PaymentsController>>();
            this.Controller = new PaymentsController(MockPaymentsRepository.Object, MockBankRepository.Object, MockLogger.Object);
        }

        [Test]
        public async Task GetPaymentsWithOutAnyExistingShouldHaveResponse()
        {
            MockPaymentsRepository.Setup(x => x.GetPaymentEntry(It.IsAny<Guid>())).ReturnsAsync(new GetPaymentEntryResult() { Success = true, PaymentEntry = null });
            var response = await this.Controller.GetPaymentDetails(new GetPaymentDetailsRequest(){ PaymentIdentifier = Guid.NewGuid()}) as NotFoundResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(404, response.StatusCode);
        }

        [Test]
        public async Task GetPaymentsWithExistingPaymentsShouldReturnData()
        {
            MockPaymentsRepository.Setup(x => x.GetPaymentEntry(It.IsAny<Guid>())).ReturnsAsync(new GetPaymentEntryResult() { Success = true, PaymentEntry = FakePaymentData.FakePaymentEntryData() });
            var response = await this.Controller.GetPaymentDetails(new GetPaymentDetailsRequest() { PaymentIdentifier = Guid.NewGuid()}) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public async Task CreatePaymentRequestShouldReturn201Response()
        {
            MockPaymentsRepository.Setup(x => x.AddPayment(It.IsAny<PaymentEntry>())).ReturnsAsync(new BaseResult() { Success = true, Message = "example message" });
            
            MockBankRepository.Setup(x => x.RequestPayment(It.IsAny<MockBankPaymentRequest>())).Returns(new MockBankResponse() { Identifier = Guid.NewGuid().ToString(), Status = CheckOut.PaymentGateway.Core.Enum.PaymentStatus.Authorized });

            var response = await this.Controller.CreatePayment(FakeCreatePaymentData.FakeCreatePaymentRequest()) as CreatedAtActionResult;


            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(201, response.StatusCode);
        }


    }
}
