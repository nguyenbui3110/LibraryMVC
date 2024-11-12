using System.Diagnostics;
using AutoMapper;
using LibraryMVC.Enums;
using LibraryMVC.Models;
using LibraryMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILibraryService _libraryService;
    private readonly ILogger<HomeController> _logger;
    private readonly IMapper _mapper;

    public HomeController(ILogger<HomeController> logger, ILibraryService libraryService, IMapper mapper)
    {
        _mapper = mapper;
        _logger = logger;
        _libraryService = libraryService;
    }


    public async Task<IActionResult> Index(int page = 1)
    {
        var result = await _libraryService.GetLibraryItemsAsync();
        var pagingLibraryItem = new PagingItem<LibraryItemModel>
        {
            CurrentPage = page,
            Items = _mapper.Map<List<LibraryItemModel>>(result)
        };
        pagingLibraryItem.ApplyPaging();

        return View(pagingLibraryItem);
    }

    [Route("search")]
    [HttpGet]
    public async Task<IActionResult> Search(string searchParam, int page = 1)
    {
        var result = await _libraryService.SearchLibraryItemAsync(searchParam);
        var pagingLibraryItem = new PagingItem<LibraryItemModel>
        {
            Items = _mapper.Map<List<LibraryItemModel>>(result),
            CurrentPage = page,
            PageUrl = i => $"?page={i}&searchParam={searchParam}"
        };
        pagingLibraryItem.ApplyPaging();
        return View("Index", pagingLibraryItem);
    }

    [HttpPost]
    [Route("search")]
    public IActionResult Search(string searchParam)
    {
        return RedirectToAction("Search", new { searchParam });
    }

    [Route("detail/{id:int}")]
    public async Task<IActionResult> Detail(int id)
    {
        var result = await _libraryService.GetLibraryItemAsync(id);
        return View(result);
    }

    [HttpPost]
    [Route("filter")]
    public IActionResult Filter(ItemType itemType, int page = 1)
    {
        return RedirectToAction("Filter", new { itemType, page });
    }

    [HttpGet]
    [Route("filter")]
    public async Task<IActionResult> Filter(ItemType? itemType, int page = 1)
    {
        if (itemType == null) return RedirectToAction("Index");
        var result = await _libraryService.GetItemsByTypeAsync(itemType.Value);
        var pagingLibraryItem = new PagingItem<LibraryItemModel>
        {
            CurrentPage = page,
            PageUrl = i => $"?page={i}&itemType={itemType}",
            Items = _mapper.Map<List<LibraryItemModel>>(result)
        };
        pagingLibraryItem.ApplyPaging();
        return View("Index", pagingLibraryItem);
        // Use itemType to fetch any data or render the view accordingly
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}