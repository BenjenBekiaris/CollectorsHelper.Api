using CollectorsHelper.Api.Dtos;
using CollectorsHelper.Api.Entities;

namespace CollectorsHelper.Api.Mapping
{
    public static class CountryMapping
    {
        public static CountryDto ToDto(this Country country)
        {
            return new CountryDto(country.Id, country.Name);
        }
    }
}
