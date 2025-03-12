namespace CollectorsHelper.Api.Dtos
{
    public record class CollectibleItemSummaryDto(
        int Id,
        string ItemType,
        string Name,
        string Country,
        int ProductionYear,
        DateOnly LastEdit,
        int NumberOfCopies);
}
