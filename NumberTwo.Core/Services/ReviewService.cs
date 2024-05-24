using NumberTwo.Core.Entities;
using NumberTwo.Core.Interfaces;

namespace NumberTwo.Core.Services;

public class ReviewService
{
    private readonly IUnitOfWork _unitOfWork;

    public ReviewService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Review>> GetReviewByBathroomIdAsync(int bathroomId)
        => (await _unitOfWork.ReviewsRepository.GetAllAsync()).Where(r => r.Id == bathroomId).ToList();

    public async Task AddReviewAsync(Review review)
    {
        await _unitOfWork.ReviewsRepository.AddAsync(review);
        await _unitOfWork.CommitAsync();
    }
}
