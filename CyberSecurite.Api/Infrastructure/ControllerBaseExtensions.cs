using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Patterns.Results;

namespace CyberSecurite.Api.Infrastructure
{
    public static class ControllerBaseExtensions
    {
        extension(ControllerBase controllerBase)
        {
            public IActionResult FromResult(Result result)
            {
                return result.IsSuccess ? controllerBase.Ok(result) : controllerBase.BadRequest(result);
            }

            public IActionResult FromResult<TData>(Result<TData> result)
            {
                return result.IsSuccess ? controllerBase.Ok(result) : controllerBase.BadRequest(result);
            }
        }
    }
}
