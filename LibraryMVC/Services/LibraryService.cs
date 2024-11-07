using System;
using AutoMapper;
using LibraryMVC.Entity;
using LibraryMVC.Enums;
using LibraryMVC.Models;
using LibraryMVC.Repo;

namespace LibraryMVC.Services;
public interface ILibraryService
{
    Task<IEnumerable<LibraryItem>> GetLibraryItemsAsync();
    Task<LibraryItem> GetLibraryItemAsync(int id);
    Task<IEnumerable<LibraryItem>> SearchLibraryItemAsync(string searchParam);
    Task<IEnumerable<LibraryItem>> GetItemsByTypeAsync(ItemType itemType);
    Task AddLibraryItemAsync(LibraryItemModel model);
    Task DeleteItemAsync(int id);
    Task UpdateLibraryItemAsync(LibraryItemModel model);



}

public class LibraryService : ILibraryService      
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly LibraryRepo _libraryRepo;
    private readonly IMapper _mapper;

    public LibraryService(LibraryRepo libraryRepo, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _libraryRepo = libraryRepo;
        _mapper = mapper;
    }


    public async Task<IEnumerable<LibraryItem>> GetItemsByTypeAsync(ItemType itemType)
    {
        return itemType switch
        {
            ItemType.Book => await _libraryRepo.GetBooksAsync(),
            ItemType.Magazine => await _libraryRepo.GetMagazinesAsync(),
            ItemType.Dvd =>  await _libraryRepo.GetDvdsAsync(),
            _ => throw new NotImplementedException()
        };
    }

    public async Task<LibraryItem> GetLibraryItemAsync(int id)
    {
        return await _libraryRepo.GetLibraryItemAsync(id);
    }

    public async Task<IEnumerable<LibraryItem>> GetLibraryItemsAsync()
    {
        return await _libraryRepo.GetAllAsync();


    }

    public async Task<IEnumerable<LibraryItem>> SearchLibraryItemAsync(string searchParam)
    {
        return await _libraryRepo.SearchLibraryItemAsync(searchParam);
    }
    public async Task AddLibraryItemAsync(LibraryItemModel model)
    {
        switch (model.Type)
        {
            case ItemType.Book:
                _libraryRepo.Add(_mapper.Map<Book>(model));
                break;
            case ItemType.Magazine:
                _libraryRepo.Add(_mapper.Map<Magazine>(model));
                break;
            case ItemType.Dvd:
                _libraryRepo.Add(_mapper.Map<Dvd>(model));
                break;
            default:
                return;
        }
        await _unitOfWork.SaveChangesAsync();
    }
    public async Task DeleteItemAsync(int id)
    {
        var libraryItem = await _libraryRepo.GetLibraryItemAsync(id);
        _libraryRepo.Delete(libraryItem);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateLibraryItemAsync(LibraryItemModel model)
    {
    
        var existingItem = await _libraryRepo.GetLibraryItemAsync(model.Id);
        if (existingItem == null)
        {
            throw new Exception("Item not found");
        }
        _mapper.Map(model, existingItem);
        await _unitOfWork.SaveChangesAsync();
        return;

    }
}
