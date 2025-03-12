using CollectorsHelper.Api.Data;
using CollectorsHelper.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CollectorsHelper.Api.Endpoints
{
    public static class CountriesEndpoints
    {
        public static RouteGroupBuilder MapCountriesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("countries");

            group.MapGet("/", async (CollectorsHelperContext dbContext) =>
                await dbContext.Countries
                    .Select(country => country.ToDto())
                    .AsNoTracking()
                    .ToListAsync());

            return group;
        }
    }
}
