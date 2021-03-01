﻿using CheckOut.PaymentGateway.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOut.PaymentGateway.WebApi.Middleware.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(k => k.Key, v => v.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

                var errorResponse = new ErrorResponse();

                foreach(var error in errorsInModelState)
                {
                    foreach(var subError in error.Value)
                    {
                        var errorModel = new ErrorModel()
                        {
                            FieldName = error.Key,
                            Message = subError
                        };

                        errorResponse.Errors.Add(errorModel);

                    }
                }

                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }

            await next();
        }
    }
}
