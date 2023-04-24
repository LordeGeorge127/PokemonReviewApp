using Pokemon_Review_App.Models;

namespace Pokemon_Review_App.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
         Review GetReview(int reviewId);
        ICollection<Review> GetReviewsOfAPokemon(int pokeId);
            bool ReviewExists(int id);

    }
}
