using Boonkrua.Api.Features.Configs.Requests;
using Boonkrua.Api.Helpers;
using Boonkrua.Services.Features.Configs.Interfaces;
using static Microsoft.AspNetCore.Http.Results;

namespace Boonkrua.Api.Features.Configs;

internal static class Handler
{
    internal static async Task<IResult> GetByUserId(string userId, IConfigService configService)
    {
        var result = await configService.GetByUserIdAsync(userId);
        return result.Match(Ok, NotFound);
    }

    internal static async Task<IResult> Create(
        CreateRequest request,
        IConfigService configService,
        HttpContext context
    ) =>
        await UserContextHelper
            .GetUserId(context)
            .Match(
                async userId =>
                {
                    var dto = request.ToDto(userId);
                    var result = await configService.CreateAsync(dto);
                    return result.Match(Ok, BadRequest);
                },
                Task.FromResult
            );
}
