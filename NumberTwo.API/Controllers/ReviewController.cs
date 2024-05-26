using Microsoft.AspNetCore.Mvc;
using NumberTwo.Core.Entities;
using NumberTwo.Core.Services;

namespace NumberTwo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly ReviewService _reviewService;

    public ReviewController(ReviewService reviewService)
        => _reviewService = reviewService;

    [HttpGet("bathroom/{bathroomId}")]
    public async Task<IActionResult> GetReviews(int bathroomId)
    {
        var review = await _reviewService.GetReviewByBathroomIdAsync(bathroomId);
        return Ok(review);
    }

    [HttpPost]
    public async Task<IActionResult> AddReview(Review review)
    {
        await _reviewService.AddReviewAsync(review);
        return CreatedAtAction(nameof(GetReviews), new { bathroom = review.BathroomId }, review);
    }
}
