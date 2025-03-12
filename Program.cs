using CollectorsHelper.Api.Data;
using CollectorsHelper.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("CollectorsHelper");
builder.Services.AddSqlite<CollectorsHelperContext>(connString);

var app = builder.Build();

app.MapCollectibleItemsEndpoints();
app.MapItemTypesEndpoints();
app.MapCountriesEndpoints();

await app.MigrateDbAsync();

app.Run();
