using NumberTwo.Core.Entities;

namespace NumberTwo.Core.Interfaces;

public interface IUnitOfWork
{
    IBaseRepository<User> UsersRepository { get; }
    IBaseRepository<Bathroom> BathroomsRepository { get; }
    IBaseRepository<Review> ReviewsRepository { get; }
    Task<int> CommitAsync();
}
