using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace registrationapp.DTO;

public class ProvincesByCountryDto
{
    [BindRequired]
    public int CountryId { get; set; }
}