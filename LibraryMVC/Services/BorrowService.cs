using AutoMapper;
using LibraryMVC.Entity;
using LibraryMVC.Entity.Enum;
using LibraryMVC.Repo;

namespace LibraryMVC.Services;

public interface IBorrowService
{
    public Task BorrowItem(int itemId, int userId);
    public Task ReturnItem(int HistoryId);
    public Task<IEnumerable<LibraryItem?>> GetBorrowedItem(int userId);

    public Task<IEnumerable<BorrowingHistory>> GetBorrowingHistory(int userId,
        BorrowingHistoryStatus status = BorrowingHistoryStatus.Borrowed);

    public Task<IEnumerable<BorrowingHistory>> GetBorrowingHistory(BorrowingHistoryStatus? status);
}

public class BorrowService : IBorrowService
{
    private readonly LibraryRepo _libraryRepo;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly BorrowingHistoryRepo _borrowingHistoryRepo;

    public BorrowService(BorrowingHistoryRepo borrowingHistoryRepo, LibraryRepo libraryRepo, IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _borrowingHistoryRepo = borrowingHistoryRepo;
        _libraryRepo = libraryRepo;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LibraryItem?>> GetBorrowedItem(int userId)
    {
        var history = await _borrowingHistoryRepo.GetBorrowingHistoryByUserIdAsync(userId);
        return history.Where(h => h.Status == BorrowingHistoryStatus.Borrowed).Select(h => h.LibraryItem);
    }

    public async Task<IEnumerable<BorrowingHistory>> GetBorrowingHistory(int userId,
        BorrowingHistoryStatus status = BorrowingHistoryStatus.Borrowed)
    {
        return (await _borrowingHistoryRepo.GetBorrowingHistoryByUserIdAsync(userId)).Where(h => h.Status == status);
    
    }

    public async Task<IEnumerable<BorrowingHistory>> GetBorrowingHistory(BorrowingHistoryStatus? status)
    {
        if (status == null) return await _borrowingHistoryRepo.GetBorrowingHistoryAsync();
        return (await _borrowingHistoryRepo.GetBorrowingHistoryAsync()).Where(h => h.Status == status);
    }


    public async Task BorrowItem(int itemId, int userId)
    {
        var history = await _borrowingHistoryRepo.GetBorrowingHistoryByUserIdAsync(userId);
        var temp = history.Where(h => h.Status == BorrowingHistoryStatus.Borrowed && h.LibraryItemId == itemId)
            .ToList();

        if (temp.Count() > 0) throw new Exception("You have already borrowed this item");
        var item = await _libraryRepo.GetLibraryItemAsync(itemId);
        if (item.Quantity > 0)
        {
            item.Quantity--;
            var borrowingHistory = new BorrowingHistory
            {
                BorrowerId = userId,
                LibraryItemId = itemId,
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7)
            };
            _borrowingHistoryRepo.Add(borrowingHistory);
            await _unitOfWork.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Item not available");
        }
    }

    public async Task ReturnItem(int borrowingHistoryId)
    {
        var borrowingHistory = await _borrowingHistoryRepo.GetByIdAsync(borrowingHistoryId);
        if (borrowingHistory != null)
        {
            borrowingHistory.ReturnDate = DateTime.Now;
            borrowingHistory.Status = BorrowingHistoryStatus.Returned;
            _borrowingHistoryRepo.Update(borrowingHistory);
            var item = await _libraryRepo.GetLibraryItemAsync(borrowingHistory.LibraryItemId);
            item.Quantity++;
            await _unitOfWork.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Borrowing history not found");
        }
    }
}