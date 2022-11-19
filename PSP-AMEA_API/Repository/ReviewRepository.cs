using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
	public class ReviewRepository : IReviewRepository
	{
		private readonly List<Review> reviews = new();

		public void CreateReview(Review review)
		{
			reviews.Add(review);
		}

		public void DeleteReview(Guid itemId, Guid userId)
		{
			reviews.RemoveAll(r => r.ItemId == itemId && r.UserId == userId);
		}

		public IEnumerable<Review> GetItemReviews(Guid itemId)
		{
			return reviews.Where(r => r.ItemId == itemId);
		}

		public Review GetReview(Guid itemId, Guid userId)
		{
			return reviews.First(r => r.ItemId == itemId && r.UserId == userId);
		}

		public IEnumerable<Review> GetUserReviews(Guid userId)
		{
			return reviews.Where(r => r.UserId == userId);
		}

		public void UpdateReview(Review review)
		{
			var idx = reviews.FindIndex(r => r.UserId == review.UserId && r.ItemId == review.ItemId);
			reviews[idx] = review;
		}
	}
}
