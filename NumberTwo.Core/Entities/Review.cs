namespace NumberTwo.Core.Entities;

public class Review : BaseEntity
{
    public int BathroomId { get; set; }
    public int UserId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public bool IsAnonymous { get; set; }
    public Bathroom? Bathroom { get; set; }
    public User? User { get; set; }
}
