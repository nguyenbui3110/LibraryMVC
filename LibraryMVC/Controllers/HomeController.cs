using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LibraryMVC.Models;
using LibraryMVC.Data;
using LibraryMVC.Services;
using LibraryMVC.Enums;
using AutoMapper;

namespace LibraryMVC.Controllers;

public class HomeController : Controller
{
    private readonly IMapper _mapper;
    private readonly ILogger<HomeController> _logger;
    private readonly ILibraryService _libraryService;

    public HomeController(ILogger<HomeController> logger, ILibraryService libraryService,IMapper mapper)
    {
        _mapper = mapper;
        _logger = logger;
        _libraryService = libraryService;
    }
        

    
    public async Task<IActionResult> Index(int page = 1)
    {
        var result = await _libraryService.GetLibraryItemsAsync();
        var PageSize = 8;
        var pagedLibraryItems = result
            .Skip((page - 1) * PageSize)
            .Take(PageSize)
            .ToList();
        var pagingLibraryItem = new PagingLibraryItem
        {
            CurrentPage = page,
            CountPages = (int)Math.Ceiling(result.Count() / (double)PageSize),
            LibraryItems = _mapper.Map<List<LibraryItemModel>>(pagedLibraryItems)
        };

        return View(pagingLibraryItem);
    }
    [Route("search")]
    public async Task<IActionResult> Search(string searchParam)
    {
        var result = await _libraryService.SearchLibraryItemAsync(searchParam);
        var pagingLibraryItem = new PagingLibraryItem
        {
            LibraryItems = _mapper.Map<List<LibraryItemModel>>(result)
        };
        return View("Index", pagingLibraryItem);
    }
    [Route("detail/{id:int}")]
    public async Task<IActionResult> Detail(int id)
    {
        var result = await _libraryService.GetLibraryItemAsync(id);
        return View(result);
    }
    [HttpPost]
    [Route("filter")]
    public async Task<IActionResult> Filter(ItemType itemType,int page = 1)
    {
        return RedirectToAction("Filter", new { itemType = itemType, page = page });
        
    }
    [HttpGet]
    [Route("filter")]
    public async Task<IActionResult> Filter(ItemType? itemType,int page = 1)
    {
        if (itemType == null)
        {
            return RedirectToAction("Index");
        }
        var result = await _libraryService.GetItemsByTypeAsync(itemType.Value);
        var pagingLibraryItem = new PagingLibraryItem
        {
            CurrentPage = page,
            CountPages = (int)Math.Ceiling(result.Count() / (double)8),
            PageUrl = i => $"?page={i}&itemType={itemType}",
            LibraryItems = _mapper.Map<List<LibraryItemModel>>(result.Skip((page - 1) * 8).Take(8))
        };
        return View("Index", pagingLibraryItem);
        // Use itemType to fetch any data or render the view accordingly

    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}