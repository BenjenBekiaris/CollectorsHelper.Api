using CollectorsHelper.Api.Data;
using CollectorsHelper.Api.Dtos;
using CollectorsHelper.Api.Entities;
using CollectorsHelper.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CollectorsHelper.Api.Endpoints
{
    public static class CollectibleItemsEndpoints
    {
        const string GetCollectibleItemsEndpointName = "GetCollectibleItems";

        public static RouteGroupBuilder MapCollectibleItemsEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("collectible_items").WithParameterValidation();

            group.MapGet("/", async (CollectorsHelperContext dbContext) =>
                await dbContext.CollectibleItems
                    .Include(collectibleItem => collectibleItem.ItemType)
                    .Include(collectibleItem => collectibleItem.Country)
                    .Select(collectibleItem => collectibleItem.ToCollectibleItemSummaryDto())
                    .AsNoTracking()
                    .ToListAsync());

            group.MapGet("/{id}", async (int id, CollectorsHelperContext dbContext) => {
                CollectibleItem? collectibleItem = await dbContext.CollectibleItems.FindAsync(id);

                return collectibleItem is null ? Results.NotFound() : Results.Ok(collectibleItem.ToCollectibleItemDetailDto());
            }).WithName(GetCollectibleItemsEndpointName);

            group.MapPost("/", async (CreateCollectibleItemDto newCollectibleItem, CollectorsHelperContext dbContext) =>
            {
                CollectibleItem collectibleItem = newCollectibleItem.ToEntity();
                collectibleItem.LastEdit = DateOnly.FromDateTime(DateTime.Now);

                dbContext.CollectibleItems.Add(collectibleItem);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute(GetCollectibleItemsEndpointName, new { id = collectibleItem.Id }, collectibleItem.ToCollectibleItemDetailDto());
            });

            group.MapPut("/{id}", async (int id, UpdateCollectibleItemDto updatedCollectibleItem, CollectorsHelperContext dbContext) =>
            {
                var existingGame = await dbContext.CollectibleItems.FindAsync(id);

                if (existingGame is null) return Results.NotFound();

                existingGame.LastEdit = DateOnly.FromDateTime(DateTime.Now);

                dbContext.Entry(existingGame)
                    .CurrentValues
                    .SetValues(updatedCollectibleItem.ToEntity(id));

                await dbContext.SaveChangesAsync();
                return Results.NoContent();
            });

            group.MapDelete("/{id}", async (int id, CollectorsHelperContext dbContext) =>
            {
                await dbContext.CollectibleItems
                    .Where(collectibleItem => collectibleItem.Id == id)
                    .ExecuteDeleteAsync();

                return Results.NoContent();
            });

            return group;
        }
    }
}
