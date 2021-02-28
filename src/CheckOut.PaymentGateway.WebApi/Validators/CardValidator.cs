using CheckOut.PaymentGateway.WebApi.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOut.PaymentGateway.WebApi.Validators
{
    public class CardValidator : AbstractValidator<CardDetails>
    {
        public CardValidator()
        {
            //this.RuleFor(x=>x.ExpiryMonth)
        }
    }
}
