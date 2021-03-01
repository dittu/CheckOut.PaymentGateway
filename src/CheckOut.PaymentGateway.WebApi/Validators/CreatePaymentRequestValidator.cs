﻿using CheckOut.PaymentGateway.Core.Enum;
using CheckOut.PaymentGateway.WebApi.Models;
using FluentValidation;
//using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOut.PaymentGateway.WebApi.Validators
{
    public class CreatePaymentRequestValidator : AbstractValidator<CreatePaymentRequest>
    {
        public CreatePaymentRequestValidator()
        {
            CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Amount)
                  .GreaterThan(0m).WithMessage("Invalid Amount");
            RuleFor(x => x.Currency).IsInEnum().WithMessage("Invalid Currency");
            RuleFor(x => x.Reference).NotEmpty().WithMessage("Invalid Reference");
            RuleFor(x => x.CardDetails).NotNull().SetValidator(new CardDetailsValidator());
        }
    }
}
