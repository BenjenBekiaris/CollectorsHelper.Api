using System.ComponentModel.DataAnnotations;

namespace CollectorsHelper.Api.Dtos
{
    public record class UpdateCollectibleItemDto(
        int ItemTypeId,
        [Required] string Name,
        int CountryId,
        int ProductionYear,
        DateOnly LastEdit,
        int NumberOfCopies,
        string? Description,
        string? ImageUrl);
}