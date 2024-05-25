using NumberTwo.Core.Entities;
using NumberTwo.Core.Interfaces;
using NumberTwo.Infrastructure.Data;

namespace NumberTwo.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        UsersRepository = new Repository<User>(context);
        BathroomsRepository = new Repository<Bathroom>(context);
        ReviewsRepository = new Repository<Review>(context);
    }

    public IBaseRepository<User> UsersRepository { get; private set; }

    public IBaseRepository<Bathroom> BathroomsRepository { get; private set; }

    public IBaseRepository<Review> ReviewsRepository { get; private set; }

    public async Task<int> CommitAsync()
        => await _context.SaveChangesAsync();
}
