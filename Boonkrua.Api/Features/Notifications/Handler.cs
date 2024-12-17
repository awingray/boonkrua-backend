using Boonkrua.Api.Features.Notifications.Requests;
using Boonkrua.Api.Helpers;
using Boonkrua.Service.Features.Configs.Interfaces;
using static Microsoft.AspNetCore.Http.Results;

namespace Boonkrua.Api.Features.Notifications;

internal static class Handler
{
    internal static async Task<IResult> GetByUserId(string userId, IService service)
    {
        var result = await service.GetByUserIdAsync(userId);
        return result.Match(Ok, NotFound);
    }

    internal static async Task<IResult> Create(
        CreateRequest request,
        IService service,
        HttpContext context
    ) =>
        await UserContextHelper
            .GetUserId(context)
            .Match(
                async userId =>
                {
                    var dto = request.ToDto(userId);
                    var result = await service.CreateAsync(dto);
                    return result.Match(Ok, BadRequest);
                },
                Task.FromResult
            );
}
