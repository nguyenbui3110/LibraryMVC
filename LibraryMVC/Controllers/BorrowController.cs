using AutoMapper;
using LibraryMVC.Common;
using LibraryMVC.Entity.Enum;
using LibraryMVC.Models;
using LibraryMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.Controllers;

public class BorrowController : Controller
{
    private readonly IBorrowService _borrowService;
    private readonly IcurrentUser _currentUser;
    private readonly IMapper _mapper;

    public BorrowController(IcurrentUser currentUser, IBorrowService borrowService, IMapper mapper)
    {
        _currentUser = currentUser;
        _borrowService = borrowService;
        _mapper = mapper;
    }

    // GET: BorrowController
    public async Task<ActionResult> Index(int page = 1, BorrowingHistoryStatus status = BorrowingHistoryStatus.Borrowed)
    {
        int.TryParse(_currentUser.UserId, out var userId);
        var history = await _borrowService.GetBorrowingHistory(userId, status);
        var result = new PagingItem<HistoryViewModel>
        {
            Items = _mapper.Map<List<HistoryViewModel>>(history),
            CurrentPage = page,
            PageUrl = i=> Url.Action("Index", new {page = i, status})
        };
        result.ApplyPaging();
        return View(result);
    }

    [HttpPost]
    public ActionResult Index(BorrowingHistoryStatus status = BorrowingHistoryStatus.Borrowed)
    {
        return RedirectToAction("Index", new { status });
    }

    [HttpPost]
    public async Task<ActionResult> Borrow(int itemId)
    {
        int.TryParse(_currentUser.UserId, out var userId);
        try
        {
            await _borrowService.BorrowItem(itemId, userId);
        }
        catch (Exception e)
        {
            TempData["Error"] = e.Message;
        }


        return RedirectToAction("Index");
    }

    public async Task<ActionResult> Return(int HistoryId)
    {
        try
        {
            await _borrowService.ReturnItem(HistoryId);
        }
        catch (Exception e)
        {
            TempData["Error"] = e.Message;
        }

        return RedirectToAction("Index");
    }
}