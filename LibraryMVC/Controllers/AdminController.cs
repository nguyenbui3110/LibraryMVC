using AutoMapper;
using LibraryMVC.Constants;
using LibraryMVC.Entity.Enum;
using LibraryMVC.Models;
using LibraryMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.Controllers;

[Authorize(Roles = AppRole.Admin)]
public class AdminController : Controller
{
    private readonly IBorrowService _borrowService;
    private readonly ILibraryService _libraryService;
    private readonly IMapper _mapper;

    public AdminController(ILibraryService libraryService, IBorrowService borrowService, IMapper mapper)
    {
        _borrowService = borrowService;
        _libraryService = libraryService;
        _mapper = mapper;
    }
    // GET: AdminController

    public async Task<ActionResult> Index(int page = 1)
    {
        var libraryItems = await _libraryService.GetLibraryItemsAsync();

        var pagingLibraryItem = new PagingItem<LibraryItemModel>
        {
            CurrentPage = page,
            Items = _mapper.Map<List<LibraryItemModel>>(libraryItems)
        };
        pagingLibraryItem.ApplyPaging();
        return View(pagingLibraryItem);
    }

    public ActionResult AddItem()
    {
        return View();
    }

    public async Task<ActionResult> UpdateItem(int id)
    {
        var libraryItem = await _libraryService.GetLibraryItemAsync(id);
        var result = _mapper.Map<LibraryItemModel>(libraryItem);
        return View(result);
    }

    public async Task<ActionResult> DeleteItem(int id)
    {
        await _libraryService.DeleteItemAsync(id);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<ActionResult> AddItem(LibraryItemModel model)
    {
        await _libraryService.AddLibraryItemAsync(model);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<ActionResult> UpdateItem(LibraryItemModel model)
    {
        await _libraryService.UpdateLibraryItemAsync(model);
        return RedirectToAction("Index");
    }

    public async Task<ActionResult> BorrowManage(int page = 1, BorrowingHistoryStatus? status = null)
    {
        var history = await _borrowService.GetBorrowingHistory(status);
        var result = new PagingItem<HistoryViewModel>
        {
            CurrentPage = page,
            Items = _mapper.Map<List<HistoryViewModel>>(history),
            PageUrl = i => $"?page={i}&status={status}"
        };
        result.ApplyPaging();
        return View(result);
    }
}