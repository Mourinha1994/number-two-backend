using NumberTwo.Core.Entities;
using NumberTwo.Core.Interfaces;

namespace NumberTwo.Core.Services;

public class AuthService
{
    private readonly IUnitOfWork _unitOfWork;
    public AuthService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<User?> RegisterAsync(string username, string email, string password)
    {
        var user = new User
        {
            Username = username,
            Email = email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
        };
        
        await _unitOfWork.UsersRepository.AddAsync(user);
        await _unitOfWork.CommitAsync();

        return user;
    }

    public async Task<User?> LoginAsync(string email, string password)
    {
        var user = (await _unitOfWork.UsersRepository.GetAllAsync()).FirstOrDefault(u => u.Email == email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            return null;
        }

        return user;
    }
}
