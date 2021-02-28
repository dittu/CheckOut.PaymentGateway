using CheckOut.PaymentGateway.Core.Interfaces;
using CheckOut.PaymentGateway.Core.MockBank.Interfaces;
using CheckOut.PaymentGateway.Core.Models;
using CheckOut.PaymentGateway.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paymentsRepo"></param>
        /// <param name="mockBankRepo"></param>
        public PaymentsController(IPaymentsRepository paymentsRepo, IMockBankRepository mockBankRepo)
        {
            _paymentRepo = paymentsRepo;
            _mockBankRepo = mockBankRepo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreatePaymentResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreatePayment([FromBody] CreatePaymentRequest paymentRequest)
        {
            //TODO: Add Validation
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("{identifier:guid}")]
        [ProducesResponseType(typeof(PaymentDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPaymentDetails([FromRoute] Guid identifier)
        {
            return Ok(new BaseResult() { Success = true, Message = "Hello World" });
        }

    }
}
