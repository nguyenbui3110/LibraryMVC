using AutoMapper;
using LibraryMVC.Constants;
using LibraryMVC.Models;
using LibraryMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.Controllers
{
    [Authorize(Roles = AppRole.Admin)]
    public class AdminController : Controller
    {
        private readonly ILibraryService _libraryService;
        private readonly IMapper _mapper;

        public AdminController(ILibraryService libraryService, IMapper mapper)
        {
            _libraryService = libraryService;
            _mapper = mapper;
        }
        // GET: AdminController
        
        public async Task<ActionResult> Index(int page = 1)
        {
            var PageSize = 8;
            var libraryItems = await _libraryService.GetLibraryItemsAsync();
            var pagedLibraryItems = libraryItems
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            var pagingLibraryItem = new PagingLibraryItem
            {
                CurrentPage = page,
                CountPages = (int)Math.Ceiling(libraryItems.Count() / (double)PageSize),
                LibraryItems = _mapper.Map<List<LibraryItemModel>>(pagedLibraryItems)
            };
            // var results = _mapper.Map<List<LibraryItemModel>>(libraryItems); 
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

    }
}
