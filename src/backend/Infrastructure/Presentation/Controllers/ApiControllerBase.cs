using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Results;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected ActionResult HandleResult(Result result)
        {
            if (result.IsSuccess)
                return Ok();

            return result.Error.Type switch
            {
                ErrorTypes.NotFound => NotFound(CreateProblemDetails("Not Found", StatusCodes.Status404NotFound, result.Error)),
                ErrorTypes.Validation => BadRequest(CreateProblemDetails("Validation Error", StatusCodes.Status400BadRequest, result.Error)),
                ErrorTypes.Conflict => Conflict(CreateProblemDetails("Conflict", StatusCodes.Status409Conflict, result.Error)),
                ErrorTypes.Unauthorized => Unauthorized(CreateProblemDetails("Unauthorized", StatusCodes.Status401Unauthorized, result.Error)),
                _ => BadRequest(CreateProblemDetails("Bad Request", StatusCodes.Status400BadRequest, result.Error))
            };
        }
        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
                return Ok(result.Value);

            return HandleResult((Result)result);
        }

        private ProblemDetails CreateProblemDetails(string title, int status, Error error)
        {
            return new ProblemDetails
            {
                Title = title,
                Status = status,
                Detail = error.Description,
                Extensions = { { "errorCode", error.Code } }
            };
        }
    }
}


