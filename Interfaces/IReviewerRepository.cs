using Pokemon_Review_App.Models;

namespace Pokemon_Review_App.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers(); 
        Reviewer GetReviewer(int reviewerId);
        ICollection<Review> GetReviewsByReviewer(int reviewerId);
        bool ReviewerExists(int reviewerId);  

    }
}
