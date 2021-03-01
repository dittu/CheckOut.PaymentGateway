using CheckOut.PaymentGateway.Core.Interfaces;
using CheckOut.PaymentGateway.Core.MockBank.Interfaces;
using CheckOut.PaymentGateway.Core.Models;
using CheckOut.PaymentGateway.WebApi.Dtos;
using CheckOut.PaymentGateway.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOut.PaymentGateway.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private IPaymentsRepository _paymentRepo;
        private IMockBankRepository _mockBankRepo;
        private ILogger _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paymentsRepo"></param>
        /// <param name="mockBankRepo"></param>
        /// <param name="logger"></param>
        public PaymentsController(IPaymentsRepository paymentsRepo,
                                  IMockBankRepository mockBankRepo,
                                  ILogger<PaymentsController> logger)
        {
            _paymentRepo = paymentsRepo ?? throw new ArgumentNullException(nameof(paymentsRepo));
            _mockBankRepo = mockBankRepo ?? throw new ArgumentNullException(nameof(mockBankRepo));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreatePaymentResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentRequest paymentRequest)
        {
            //TODO: Add Validation
            var paymentEntry = paymentRequest.ConvertToPaymentEntry();

            await _paymentRepo.AddPayment(paymentEntry);

            var bankRequest = paymentRequest.ConvertToMockPaymentRequest();

            var requestPaymentResponse = _mockBankRepo.RequestPayment(bankRequest);

            paymentEntry.Status = requestPaymentResponse.Status;
            paymentEntry.BankIdentifier = requestPaymentResponse.Identifier;
            paymentEntry.BankStatus = requestPaymentResponse.Status;

            //TODO: Replace with partial update
            await _paymentRepo.AddPayment(paymentEntry);

            return CreatedAtAction(nameof(CreatePayment), new CreatePaymentResponse()
            {
                Identifier = paymentEntry.Identifier.ToString(),
                Status = paymentEntry.Status
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(PaymentDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPaymentDetails([FromBody] GetPaymentDetailsRequest paymentDetailsRequest)
        {
            throw new Exception("Unable to fetch data.");
            _logger.LogInformation($"GetPaymentDetails requested");

            var res = await _paymentRepo.GetPaymentEntry(paymentDetailsRequest.PaymentIdentifier);

            if (res.Success)
            {
                if (res.PaymentEntry == null)
                    return NotFound();
                else
                    return Ok(res.PaymentEntry.ConvertToPaymentDetails());
            }
            else
                throw new Exception("Unable to fetch data.");
        }

    }
}
