using Pokemon_Review_App.Models;

namespace Pokemon_Review_App.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category>GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonCategory(int categoryId);
        bool CategoryExists(int id);
    }
}
