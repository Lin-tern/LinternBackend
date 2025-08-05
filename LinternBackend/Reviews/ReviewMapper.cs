using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinternBackend.Reviews
{
    public static class ReviewMapper
    {
        public static Review ToReview(this CreateReview create)
        {
            return new Review
            {
                ApplicationId = create.ApplicationId,
                ReviewerOrganizationId = create.ReviewerOrganizationId,
                Content = create.Content,
                Rating = create.Rating,
                CreatedAt = DateTime.UtcNow,
            };
        }

        public static ViewReview FromReview(this Review review)
        {
            return new ViewReview
            {
                Id = review.Id,
                ApplicationId = review.ApplicationId,
                ReviewerOrganizationId = review.ReviewerOrganizationId,
                Content = review.Content,
                Rating = review.Rating,
                CreatedAt = review.CreatedAt,
            };
        }
    }
}