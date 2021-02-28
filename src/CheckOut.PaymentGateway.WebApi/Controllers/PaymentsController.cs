using CheckOut.PaymentGateway.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOut.PaymentGateway.WebApi.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/authors")]
    public class PaymentsController : ControllerBase
    {
        private IPaymentsRepository _paymentRepo;

        public PaymentsController(IPaymentsRepository paymentsRepo)
        {
            _paymentRepo = paymentsRepo;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreatePayment(CreatePaymentRequest paymentRequest)
        {

        }
    }
}
