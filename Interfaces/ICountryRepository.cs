using Pokemon_Review_App.Models;

namespace Pokemon_Review_App.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country>GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int OwnerId);
        ICollection<Owner> GetOwnerFromACountry(int countryId);
        bool CountryExists(int id);

    }
}
