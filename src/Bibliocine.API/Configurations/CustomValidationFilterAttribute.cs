using Bibliocine.Core.DTO;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Bibliocine.API.Configurations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

public class CustomValidationFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = new List<string>();

            foreach (var value in context.ModelState.Values)
            {
                foreach (var error in value.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }

            var result = new BaseResponse()
            {
                HttpCode = 400,
                Message = "Um ou mais erros de validações encontrado.",
                Success = false,
                Result = errors
            };
            
            context.Result = new BadRequestObjectResult(result);
        }

        base.OnActionExecuting(context);
    }
}
