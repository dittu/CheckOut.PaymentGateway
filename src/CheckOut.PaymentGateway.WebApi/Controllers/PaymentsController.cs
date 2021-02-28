using CheckOut.PaymentGateway.Core.Interfaces;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paymentsRepo"></param>
        public PaymentsController(IPaymentsRepository paymentsRepo)
        {
            _paymentRepo = paymentsRepo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreatePayment(CreatePaymentRequest paymentRequest)
        {
            return NotFound();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetHelloWorld()
        {
            return Ok(new BaseResult() { Success = true, Message = "Hello World" });
        }

    }
}
