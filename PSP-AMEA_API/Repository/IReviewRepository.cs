using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
	public interface IReviewRepository
	{
		void CreateReview(Review review);
		void UpdateReview(Review review);
		void DeleteReview(Guid itemId, Guid userId);
		IEnumerable<Review> GetItemReviews(Guid itemId);
		IEnumerable<Review> GetUserReviews(Guid userId);
		Review GetReview(Guid itemId, Guid userId);
	}
}
