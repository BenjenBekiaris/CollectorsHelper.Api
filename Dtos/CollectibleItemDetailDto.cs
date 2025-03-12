namespace CollectorsHelper.Api.Dtos
{
    public record class CollectibleItemDetailDto(
        int Id,
        int ItemTypeId,
        string Name,
        int CountryId,     
        int ProductionYear,
        DateOnly LastEdit,
        int NumberOfCopies,
        string? Description,
        string? ImageUrl);
}
