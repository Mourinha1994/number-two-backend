using NumberTwo.Core.Entities;
using NumberTwo.Core.Interfaces;

namespace NumberTwo.Core.Services;

public class BathroomService
{
    private readonly IUnitOfWork _unitOfWork;

    public BathroomService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Bathroom>> GetBathroomsAsync()
        => await _unitOfWork.BathroomsRepository.GetAllAsync();

    public async Task<Bathroom> GetBathroomByIdAsync(int id)
        => await _unitOfWork.BathroomsRepository.GetByIdAsync(id);

    public async Task AddBathroomAsync(Bathroom bathroom)
    {
        await _unitOfWork.BathroomsRepository.AddAsync(bathroom);
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateBathroomAsync(Bathroom bathroom)
    {
        await _unitOfWork.BathroomsRepository.UpdateAsync(bathroom);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteBathroomAsync(int id)
    {
        await _unitOfWork.BathroomsRepository.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
    }
}
