using System.Security.Claims;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Api.Helpers;

internal static class UserContextHelper
{
    internal static Result<string, IResult> GetUserId(HttpContext context)
    {
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return userId.IsNullOrEmpty()
            ? Result<string, IResult>.Err(Results.Unauthorized())
            : userId!;
    }
}
