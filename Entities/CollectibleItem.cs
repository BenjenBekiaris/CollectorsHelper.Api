namespace CollectorsHelper.Api.Entities
{
    public class CollectibleItem
    {
        public int Id { get; set; }
        
        public int ItemTypeId { get; set; }
        
        public ItemType? ItemType { get; set; }
        
        public required string Name { get; set; }
        
        public int CountryId { get; set; }

        public Country? Country { get; set; }
        
        public int ProductionYear { get; set; }
        
        public DateOnly LastEdit { get; set; }
        
        public int NumberOfCopies { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

    }
}
