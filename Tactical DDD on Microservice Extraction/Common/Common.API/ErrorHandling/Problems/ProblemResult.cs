

using Common.Domain.BusinessRules;
using ErrorOr;
using Microsoft.AspNetCore.Http;

namespace Common.API.ErrorHandling.Problems
{   
    // Necemo vise koristiti Exception, vec Result type
    public static class ProblemResult
    {
        public static IResult ToProblem(this IReadOnlyCollection<Error> errors)
        {
            var error = errors.First();
            var statusCode = error.NumericType switch
            {
                BusinessRuleError.Type => StatusCodes.Status409Conflict,
                (int)ErrorType.Conflict => StatusCodes.Status409Conflict,
                (int)ErrorType.Validation => StatusCodes.Status400BadRequest,
                (int)ErrorType.NotFound => StatusCodes.Status404NotFound,
                (int)ErrorType.Failure => StatusCodes.Status500InternalServerError,
                (int)ErrorType.Unexpected => StatusCodes.Status500InternalServerError,
                (int)ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                (int)ErrorType.Forbidden => StatusCodes.Status403Forbidden,
                _ => StatusCodes.Status500InternalServerError
            };

            var errorMessage = GetErrorMessage(errors);

            var results = Results.Problem(errorMessage, statusCode: statusCode);

            return results;
        }
        private const string? Separator = ", ";
        private static string GetErrorMessage(IEnumerable<Error> errors)
        {
            return string.Join(Separator, errors.Select(error => error.Description));
        }
    }
}
