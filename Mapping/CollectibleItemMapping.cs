using CollectorsHelper.Api.Dtos;
using CollectorsHelper.Api.Entities;

namespace CollectorsHelper.Api.Mapping
{
    public static class CollectibleItemMapping
    {
        public static CollectibleItem ToEntity(this CreateCollectibleItemDto collectibleItem)
        {
            return new CollectibleItem()
            {         
                ItemTypeId = collectibleItem.ItemTypeId,
                Name = collectibleItem.Name,
                CountryId = collectibleItem.CountryId,               
                ProductionYear = collectibleItem.ProductionYear,
                LastEdit = collectibleItem.LastEdit,
                NumberOfCopies = collectibleItem.NumberOfCopies,
                Description = collectibleItem.Description,
                ImageUrl = collectibleItem.ImageUrl,
            };
        }

        public static CollectibleItem ToEntity(this UpdateCollectibleItemDto collectibleItem, int id)
        {
            return new CollectibleItem()
            {
                Id = id,
                ItemTypeId = collectibleItem.ItemTypeId,
                Name = collectibleItem.Name,
                CountryId = collectibleItem.CountryId,
                ProductionYear = collectibleItem.ProductionYear,
                LastEdit = collectibleItem.LastEdit,
                NumberOfCopies = collectibleItem.NumberOfCopies,
                Description = collectibleItem.Description,
                ImageUrl = collectibleItem.ImageUrl,
            };
        }

        public static CollectibleItemSummaryDto ToCollectibleItemSummaryDto(this CollectibleItem collectibleItem)
        {
            {
                return new CollectibleItemSummaryDto(
                    collectibleItem.Id,
                    collectibleItem.ItemType!.Name,
                    collectibleItem.Name,
                    collectibleItem.Country!.Name,
                    collectibleItem.ProductionYear,
                    collectibleItem.LastEdit,
                    collectibleItem.NumberOfCopies
                    );
            }
        }

        public static CollectibleItemDetailDto ToCollectibleItemDetailDto(this CollectibleItem collectibleItem)
        {
            return new(
                collectibleItem.Id,
                collectibleItem.ItemTypeId,
                collectibleItem.Name,
                collectibleItem.CountryId,
                collectibleItem.ProductionYear,
                collectibleItem.LastEdit,
                collectibleItem.NumberOfCopies,
                collectibleItem.Description,
                collectibleItem.ImageUrl
                );
        }
    }
}
