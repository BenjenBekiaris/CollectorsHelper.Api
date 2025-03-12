using CollectorsHelper.Api.Data;
using CollectorsHelper.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CollectorsHelper.Api.Endpoints
{
    public static class ItemTypesEndpoints
    {
        public static RouteGroupBuilder MapItemTypesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("item_types");

            group.MapGet("/", async (CollectorsHelperContext dbContext) =>
                await dbContext.ItemTypes
                    .Select(itemType => itemType.ToDto())
                    .AsNoTracking()
                    .ToListAsync());

            return group;
        }
    }
}
