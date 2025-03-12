using CollectorsHelper.Api.Dtos;
using CollectorsHelper.Api.Entities;

namespace CollectorsHelper.Api.Mapping
{
    public static class ItemTypeMapping
    {
        public static ItemTypeDto ToDto(this ItemType itemType)
        {
            return new ItemTypeDto(itemType.Id, itemType.Name);
        }
    }
}
